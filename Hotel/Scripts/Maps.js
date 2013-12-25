function initialize() {
    //https://developers.google.com/maps/documentation/javascript/markers
    var myLatlng = new google.maps.LatLng(-1.399121, -78.420589);

    var mapOptions = {
        center: myLatlng,
        zoom: 15
    };
    var map = new google.maps.Map(document.getElementById("map-canvas"),
        mapOptions);

    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: "Hostal El Eden"
    });
}
google.maps.event.addDomListener(window, 'load', initialize);
