/**
 * Geofencing.js
 *
 * Phonegap Geofencing Plugin
 * Copyright (c) Dov Goldberg 2014
 * http://www.ogonium.com
 * dov.goldberg@ogonium.com
 *
 */


var DGGeofencing = function() {};


DGGeofencing.prototype = {
    /*
     Params:
     NONE
    */
    initCallbackForRegionMonitoring: function (params, success, fail) {
        return cordova.exec(success, fail, "DGGeofencing", "initCallbackForRegionMonitoring", params);
    },

    /*
     Params:
     #define KEY_REGION_ID       @"fid"
     #define KEY_REGION_LAT      @"latitude"
     #define KEY_REGION_LNG      @"longitude"
     #define KEY_REGION_RADIUS   @"radius"
     //#define KEY_REGION_ACCURACY @"accuracy" // not implemented!
     */
    startMonitoringRegion: function (params, success, fail) {
        return cordova.exec(success, fail, "DGGeofencing", "startMonitoringRegion", params);
    },

    /*
     Params:
     #define KEY_REGION_ID      @"fid"
     #define KEY_REGION_LAT     @"latitude"
     #define KEY_REGION_LNG     @"longitude"
     */
    stopMonitoringRegion: function (params, success, fail) {
        return cordova.exec(success, fail, "DGGeofencing", "stopMonitoringRegion", params);
    },

    /*
     Params:
     NONE
     */
    startMonitoringSignificantLocationChanges: function (success, fail) {
        alert('aqui');
        return cordova.exec(success, fail, "DGGeofencing", "startMonitoringSignificantLocationChanges", []);
    },

    /*
     Params:
     NONE
     */
    stopMonitoringSignificantLocationChanges: function (success, fail) {
        return cordova.exec(success, fail, "DGGeofencing", "stopMonitoringSignificantLocationChanges", []);
    }
};

var plugin  = new DGGeofencing();

module.exports = plugin;