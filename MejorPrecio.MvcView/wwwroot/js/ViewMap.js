var map;
var productId = document.getElementById('productId').innerHTML;
function initMap() {
  map = new google.maps.Map(document.getElementById('map'), {
    center: {lat: -34.6083, lng: -58.3712},
    zoom: 15
  });                 
var infowindow = new google.maps.InfoWindow();          
}

$(document).ready(function() {

  $.get('/price/viewmapprices',{ idProd: productId },
  function(serverResponse){
    console.log(serverResponse);
    var infowindow = new google.maps.InfoWindow();

    map.setOptions({
        center: {lat:serverResponse[0]["latitude"], lng: serverResponse[0]["longitude"]},
        zoom: 15
    });
    
    
    var markers = [];
    $.each(serverResponse, function(index) {
      var marker = new google.maps.Marker({
        position: {lat: serverResponse[index]["latitude"], lng: serverResponse[index]["longitude"]},
        map: map,
        label: (index+1) + ""
      });
    //markers.push(marker);
    if(index == 0)
    {
      marker.setIcon('http://maps.google.com/mapfiles/ms/icons/green-dot.png');
    }

      $.get('/price/viewmapuseremail',{ userId: serverResponse[index]["idUser"] },
      function(serverResponse2){
          console.log(serverResponse2);
    
          $.get('/price/viewmapproductdata',{ userId: serverResponse[index]["idProduct"] },
          function(serverResponse3){
            console.log(serverResponse3);
    
            var dateTime = serverResponse[index]["date"].split("T");
            var date = dateTime[0].split("-");
            var time = dateTime[1].split(":");
            date = date[2] + "-" + date[1] + "-" + date[0];
            time = time[0] + ":" + time[1]; 
            
            marker.addListener('click', function() {
              if (infowindow) {
                  infowindow.close();
              }
              infowindow = infowindow = new google.maps.InfoWindow({
                  content: "Producto: " + serverResponse3 + "</br>Precio: $" + serverResponse[index]["priceEffective"] + "</br> Subido por " + serverResponse2 + "</br> Fecha: " + date + "</br> Hora: " + time
              });
              infowindow.open(map, marker);
            });
          });
      });

    }); 

  });   
});     
