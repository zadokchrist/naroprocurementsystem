var map;
function getMap() {
    var jsonstring = "";
    var lat = 6.5244, longi = 3.3792;
    var jstomers = $(".jstomers").val();
    var json = JSON.parse(jstomers);
    require([
          "esri/map",
          "esri/InfoTemplate",
          "esri/layers/ArcGISDynamicMapServiceLayer",
          "esri/layers/ImageParameters",
          "esri/layers/FeatureLayer",
          "esri/dijit/Legend",
          "dojo/_base/array",
          "dojo/parser",
          "dijit/layout/BorderContainer",
          "dijit/layout/ContentPane",
          "dijit/layout/AccordionContainer",
          "esri/toolbars/draw",
        "esri/symbols/SimpleMarkerSymbol", "esri/symbols/SimpleLineSymbol",
        "esri/symbols/PictureFillSymbol", "esri/symbols/CartographicLineSymbol",
        "esri/graphic",
          "dojo/domReady!"],
          function (Map, InfoTemplate, ArcGISDynamicMapServiceLayer, ImageParameters, FeatureLayer, Legend,
          arrayUtils, parser, PictureMarkerSymbol) {
              parser.parse();
              map = new Map("map", {
                  center: [longi, lat], // longitude, latitude
                  basemap: "hybrid",
                  zoom: 10
              });
              //Create legend layer array
              var legendLayers = [];

              //Reference the baselayer map service.
              var baseLayers = new ArcGISDynamicMapServiceLayer("http://165.3.4.5:8080/MapServer", {
                  "imageParameters": imageParameters
              });

              legendLayers.push({ layer: baseLayers, title: 'Base Layers' });
              map.addLayers([baseLayers]);

              var imageParameters = new ImageParameters();
              imageParameters.format = "jpeg"; //set the image type to PNG24, note default is PNG8.

              //Reference the pending jobs feature layer
              map.on("load", initOperationalLayer);

              function initOperationalLayer() {
                  //var infoTemplate = new InfoTemplate("CallRef ${CallRef}: ${Description}");
                  var infoSymbol = new esri.symbol.PictureMarkerSymbol({
                      "angle": 0,
                      "xoffset": 0,
                      "yoffset": 12,
                      "type": "esriPMS",
                      "url": "../gis/map.png",
                      "contentType": "image/png",
                      "width": 24,
                      "height": 24
                  });
                 
                  $.each(json, function (key, data) {
                      var latitude = data.Latitude;
                      var customer = data.cust_fullname;
                      var number = data.CustRef;
                      var longitude = data.Longitude;
                      var location = data.Address;
                      var acc = data.AccountBalance;
                      var tarriff = data.TarrifName;
                      var zone = data.ZoneName;
                     
                      var symbol = new esri.symbol.SimpleMarkerSymbol().setSize(20).setColor(new dojo.Color([255, 0, 0]));
                      var point = new esri.geometry.Point(longitude, latitude);
                      var graphic = new esri.Graphic(point, infoSymbol);
                      var infoTemplate1 = new esri.InfoTemplate();
                      infoTemplate1.setTitle(customer + " From " + location);
                      infoTemplate1.setContent("<a href='#' id='close'>close</a><br/><b>Customer</b> "
                      + customer + "<b><br/>Account Number</b> "
                      + number + "<br/> <b>latitude</b> " + latitude + " <br/> <b>longitude</b> "
                       + longitude + "<br/><b>Zone</b> " + zone + " <br/>"
                      + "<b>Tarriff</b> " + tarriff + " <br/>" + "<b>Account Balance</b> " + acc + " <br/>");
                      graphic.setInfoTemplate(infoTemplate1);
                      map.graphics.add(graphic);

                  });
                  // alert("outside");
              }
          });
    $("#map").click(function (e) {
        map.infoWindow.hide();
    });
}
function locationPicker()
{
    $('#loc_picker').locationpicker({
        location: { latitude: 46.15242437752303, longitude: 2.7470703125 },
        radius: 300,
        inputBinding: {
            latitudeInput: $('#us2-lat'),
            longitudeInput: $('#us2-lon'),
            radiusInput: $('#us2-radius'),
            locationNameInput: $('#address')
        },
        enableAutocomplete: true
    });
}