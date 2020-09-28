package com.example.h3projekt;


import android.app.DownloadManager;
import android.content.Context;
import android.util.Log;
import android.widget.Toast;

import com.android.volley.NetworkResponse;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class ApiCall {

    ArrayList<ApiWatcher> watchers = new ArrayList<ApiWatcher>();
    public ApiCall() {
    }

    public  void addListener(ApiWatcher watcher){
        watchers.add((watcher));
    }
    public  void removeListener(ApiWatcher watcher){
        watchers.remove(watcher);
    }

    public void call(Context context,final String number){
        String url = "http://projektdns.westeurope.cloudapp.azure.com/api/NumberPlateLocations/" + number;
        RequestQueue queue = Volley.newRequestQueue(context);
        JsonArrayRequest  jsonObjectRequest = new JsonArrayRequest
                (Request.Method.GET, url, null, new Response.Listener<JSONArray>() {


                    @Override
                    public void onResponse(JSONArray response) {
                        try {
                            JSONObject obj = response.getJSONObject(response.length() - 1);

                            //plate = new NumberPlate("a", response.getDouble("xLocation"), response.getDouble("yLocation"));
                            //NumberPlate plate = new NumberPlate(number, 55.67594, 12.56553);
                            NumberPlate plate = new NumberPlate(number, obj.getDouble("xLocation"), obj.getDouble("yLocation"));
                            //NumberPlate plate = new NumberPlate(number, 55.67594, 12.56553);

                            for (ApiWatcher watcher : watchers){
                                watcher.onApiResponse(plate);
                            }

                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                }, new Response.ErrorListener() {

                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // TODO: Handle error
                        for (ApiWatcher watcher : watchers){
                            int errorCode = error.networkResponse.statusCode;
                            if(errorCode == 404)
                                watcher.onApiError("Number plate doesn't exists");
                            else
                                watcher.onApiError("Error with service");
                        }

                    }
                });
        queue.add(jsonObjectRequest);
    }


    public void post(Context context){
        String url = "https://httpbin.org/post";

        StringRequest request = new StringRequest(Request.Method.POST, url, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                for (ApiWatcher watcher : watchers){
                    //watcher.onApiResponse(response);
                }
            }
    }, new Response.ErrorListener() {
        @Override
        public void onErrorResponse(VolleyError error) {
            for (ApiWatcher watcher : watchers){
                //watcher.onApiResponse(error.getMessage());
            }        }
    }){
//This is how you will send the data to API
        @Override
        protected Map<String, String> getParams(){
            Map<String,String> map = new HashMap<>();
            map.put("name", "username");
            map.put("password","password");
            return map;
        }
    };
     RequestQueue requestQueue = Volley.newRequestQueue(context);
        requestQueue.add(request);
    }
}
