function initMap() {

  //Posicion por defecto por si el usuario no tiene geolocalizacion en el navegador
  var defaultCenter = { lat: -34.608433, lng: -58.37251 };
  //inicializamos el mapa
  var map = new google.maps.Map(document.getElementById('map'), {
    center: defaultCenter,
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
      //Si falla algo en obtener la geolocalizacion del usuario cae en esta funcion
      handleLocationError();
    });

  }

  else {
    // El navegador no soporta la geolocalización
    handleLocationError();
  }

  function handleLocationError() {
    //Posicionamos el centro del mapa en la posicion por defecto
    map.setCenter(defaultCenter);

    //Posicionamos el marcador en el mapa en la ubicacion por defect
    var marker = new google.maps.Marker({
      position: defaultCenter,
      map: map,
      draggable: true,
      title: 'Elegir ubicación del producto'
    });


    //Variables para obtener la direccion del lugar donde apunta el usuario con el marcador
    let address = new google.maps.LatLng(defaultCenter.lat, defaultCenter.lng);
    //Inicializamos la geolocalizacion reversa
    let geocoder = new google.maps.Geocoder();

    geocoder.geocode({
      location: address
    }, function (geocoderResults) {
      document.getElementById("addr").value = geocoderResults[0].address_components[1].short_name + ' ' + geocoderResults[0].address_components[0].long_name;
    });

    //Rellenamos los inputs de direccion con la latitud y longitud
    document.getElementById("lat").value = defaultCenter.lat;

    document.getElementById("lng").value = defaultCenter.lng;

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

  }
}
