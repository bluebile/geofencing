package com.phonegap.geofencing;


import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.location.Location;
import android.os.Bundle;
import android.util.Log;

import org.json.JSONException;
import org.json.JSONObject;

import static com.phonegap.geofencing.DGGeofencing.TAG;

public class ProximityReceiver extends BroadcastReceiver {

  @Override
  public void onReceive(Context context, Intent intent) {
    String id = (String) intent.getExtras().get("id");
    Log.d(TAG, "received proximity alert for region " + id);

    //start activity
//    Intent i = new Intent();
//    i.setClassName("br.com.mbamobi.geo", "br.com.mbamobi.geo.MainActivity");
//    i.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//    context.startActivity(i);

    Bundle b = intent.getExtras();
    Location location = (Location)b.get(android.location.LocationManager.KEY_LOCATION_CHANGED);

    try {
      if (location != null) {
        String prefix = "Geofencing";
        JSONObject object = new JSONObject();
        object.put(prefix + "_timestamp", location.getTime());
        object.put(prefix + "_speed", location.getSpeed());
        object.put(prefix + "_course", location.getBearing());
        object.put(prefix + "_verticalAccuracy", location.getAccuracy());
        object.put(prefix + "_horizontalAccuracy", location.getAccuracy());
        object.put(prefix + "_altitude", location.getAltitude());
        object.put(prefix + "_latitude", location.getLatitude());
        object.put(prefix + "_longitude", location.getLongitude());
        Log.v("SystemWebChromeClient", object.toString());
      }
    } catch (JSONException ex)
      {
        throw new RuntimeException("location could not be serialized to json", ex);
      }

//    DGGeofencing.getInstance().fireLocationChangedEvent(location);
  }
}
