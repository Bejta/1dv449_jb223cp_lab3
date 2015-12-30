
    var gmarkers = [];
    

    function Initialize(data) {

        google.maps.visualRefresh = true;

        var Sweden = new google.maps.LatLng(61.02, 14.38);

        var mapOptions = {
            zoom: 5,
            center: { lat: 61.39, lng: 15.35 },
            mapTypeId: google.maps.MapTypeId.ROADMAP,
        };

        // This makes the div with id "map_canvas" a google map
        var map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);

        var marker, i;

        var infowindow = new google.maps.InfoWindow();
        // This shows adding a simple pin "marker" 
        //var myLatlng = new google.maps.LatLng(61.02, 14.38);
        google.maps.event.addListener(map, 'click', function () {
            infowindow.close();
        });

        for (i = 0; i < data.length; i++) {
            marker = new google.maps.Marker({
                position: new google.maps.LatLng(data[i]["Latitude"], data[i]["Longitude"]),
                map: map,
                title: data[i]['title']
            });
            if (data[i]["Category"] == 0) {
                marker.setIcon('http://maps.google.com/mapfiles/ms/icons/green-dot.png')
            }
            else if (data[i]["Category"] == 1) {
                marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png')
            }
            else if (data[i]["Category"] == 2) {
                marker.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png')
            }
            else {
                marker.setIcon('http://maps.google.com/mapfiles/ms/icons/yellow-dot.png')
            }
            gmarkers.push(marker);


            google.maps.event.addListener(marker, 'click', (function (marker, i) {

                return function () {
                    infowindow.setContent("<div class='infoDivo'><p><strong>Exakt läge: </strong>" + data[i]["ExactLocation"] + "</p>" + "<p><strong>Kategori: </strong>" + data[i]["SubCategory"] + "</p>" + "<p><strong>Tid: </strong>" + data[i]["CreatedDate"] + "<p><strong>Beskrivning: </strong>" + data[i]["Description"] + "</p></div>");
                    map.setZoom(15);
                    map.setCenter(marker.getPosition());
                    infowindow.open(map, marker);
                }
            })(marker, i));
        }
    }
    //google.maps.event.addDomListener(window, 'load', Initialize);

    function myClick(sentId) {
        for (var i = 0; i < data.length; i++) {
            if (data[i]["id"] === sentId) {
                google.maps.event.trigger(gmarkers[i], 'click');
            }
        }
    }



