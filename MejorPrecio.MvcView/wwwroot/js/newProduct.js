function initMap() {
  //inicializamos el mapa
  var map = new google.maps.Map(document.getElementById('map'), {
    center: { lat: -34.608433, lng: -58.37251 },
    zoom: 17
  });

  // Intentamos obtener la geolocalizacion mediante html5
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(function (position) {
      var pos = {
        lat: position.coords.latitude,
        lng: position.coords.longitude
      };

      //Posicionamos el centro del mapa en la posicion del usuario
      map.setCenter(pos);

      //Posicionamos el marcador en el mapa en la ubicacion del usuario
      var marker = new google.maps.Marker({
        position: pos,
        map: map,
        draggable: true,
        title: 'Ubicación del producto'
      });

      //Variables para obtener la direccion del lugar donde apunta el usuario con el marcador
      let address = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
      //Inicializamos la geolocalizacion reversa
      let geocoder = new google.maps.Geocoder();

      geocoder.geocode({
        location: address
      }, function (geocoderResults) {
        document.getElementById("addr").value = geocoderResults[0].address_components[1].short_name + ' ' + geocoderResults[0].address_components[0].long_name;
      });

      //Rellenamos los inputs de direccion con la latitud y longitud
      document.getElementById("lat").value = position.coords.latitude;

      document.getElementById("lng").value = position.coords.longitude;

      //Rellenamos los inputs esta vez cuando el usuario mueve el marcador
      google.maps.event.addListener(marker, 'dragend', function (event) {

        geocoder.geocode({
          location: new google.maps.LatLng(event.latLng.lat(), event.latLng.lng())
        }, function (geocoderResults) {
          document.getElementById("addr").value = geocoderResults[0].address_components[1].short_name + ' ' + geocoderResults[0].address_components[0].long_name;
        });

        document.getElementById("lat").value = event.latLng.lat();

        document.getElementById("lng").value = event.latLng.lng();

      });

    }, function () {
      handleLocationError(true, infoWindow, map.getCenter());
    });

  }

  else {
    // El navegador no soporta la geolocalización
    handleLocationError(false, infoWindow, map.getCenter());
  }


  function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
      'Error: El servicio de geolocalizacion fallo.' :
      'Error: Tu navegador no soporta geolocalizacion.');
  }
}
