              
   function Initialize() {

       google.maps.visualRefresh = true;
       var Sweden = new google.maps.LatLng(61.02, 14.38);

               
        var mapOptions = {
            zoom: 5,
            center: Sweden,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
        };
                
        // This makes the div with id "map_canvas" a google map
        var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
        //var yourJavaScriptArray = @Html.Raw(Json.Encode(Model.YourDotNetArray));


        //marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png')
   }

   //function AddMarker(lat, lot, title) {
   //    google.maps.visualRefresh = true;
   //    var Sweden = new google.maps.LatLng(61.02, 14.38);


   //    var mapOptions = {
   //        zoom: 5,
   //        center: Sweden,
   //        mapTypeId: google.maps.MapTypeId.ROADMAP,
   //    };

   //    var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
       
   //    // This shows adding a simple pin "marker" - this happens to be the Tate Gallery in Liverpool!
   //    var myLatlng = new google.maps.LatLng(lat, lot);

   //    var marker = new google.maps.Marker({
   //        position: myLatlng,
   //        map: map,
   //        title: title
   //    });

   //    // You can make markers different colors...  google it up!
   //    marker.setIcon('http://maps.google.com/mapfiles/ms/icons/green-dot.png')
  // }

  
