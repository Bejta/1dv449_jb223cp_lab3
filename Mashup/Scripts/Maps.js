//function GetMap() {
//    var mapOptions = {
//        credentials: "Ar7yrfT4Hux1-O7311-MEO-utjJJKIpiZbUwuZsxA3KhUU-UT5Oisz1kmxE9EnOQ",
//    }
//    var map = new Microsoft.Maps.Map(document.getElementById("mapDiv"), mapOptions);
//    var viewBoundaries = Microsoft.Maps.LocationRect.fromLocations(new Microsoft.Maps.Location(62.02, 15.38), new Microsoft.Maps.Location(47.620700, -122.347584), new Microsoft.Maps.Location(47.622052, -122.345869));

//    map.setView({ bounds: viewBoundaries });
//    //map.focus.
//}

<!-- This code tells the browser to execute the "Initialize" method 
only when the complete document model has been loaded. -->
$(document).ready(function () {
    Initialize(); 
});  