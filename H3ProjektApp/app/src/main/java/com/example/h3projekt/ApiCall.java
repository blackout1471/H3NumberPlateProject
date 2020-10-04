package com.example.h3projekt;


import android.app.DownloadManager;
import android.content.Context;
import android.util.Log;
import android.widget.Toast;

import com.android.volley.AuthFailureError;
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

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class ApiCall {

    ArrayList<ApiGetWatchable> getWatchers = new ArrayList<ApiGetWatchable>();
    ArrayList<ApiPostWatchable> postWatchers = new ArrayList<ApiPostWatchable>();

    public ApiCall() {
    }

    public  void addGetListener(ApiGetWatchable watcher){
        getWatchers.add(watcher);
    }
    public  void removeGetListener(ApiGetWatchable watcher){
        getWatchers.remove(watcher);
    }

    public  void addPostListener(ApiPostWatchable watcher){
        postWatchers.add(watcher);
    }
    public  void removePostGetListener(ApiPostWatchable watcher){
        postWatchers.remove(watcher);
    }

    public void getRequest(Context context,final String number){
        String url = "http://projektdns.westeurope.cloudapp.azure.com:81/api/NumberPlateLocations/" + number;
        RequestQueue queue = Volley.newRequestQueue(context);
        JsonArrayRequest  jsonObjectRequest = new JsonArrayRequest
                (Request.Method.GET, url, null, new Response.Listener<JSONArray>() {


                    @Override
                    public void onResponse(JSONArray response) {
                        try {
                            JSONObject obj = response.getJSONObject(response.length() - 1);

                            //plate = new NumberPlate("a", response.getDouble("xLocation"), response.getDouble("yLocation"));
                            //NumberPlate plate = new NumberPlate(number, 55.67594, 12.56553);
                            NumberPlate plate = new NumberPlate(number, obj.getDouble("xLocation"), obj.getDouble("yLocation"), obj.getString("timeSpotted"));
                            //NumberPlate plate = new NumberPlate(number, 55.67594, 12.56553);

                            for (ApiGetWatchable watcher : getWatchers){
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
                        for (ApiGetWatchable watcher : getWatchers){
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

    public boolean checkIfStolen(Context context, final String numberPlate) {
        /*
        String url = "https://data4.nummerplade.net/efterlyst.php?stelnr="+numberPlate;
        RequestQueue queue = Volley.newRequestQueue(context);
        JsonObjectRequest  jsonObjectRequest = new JsonObjectRequest
                (Request.Method.GET, url, null, new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        for (ApiWatcher watcher : watchers){
                            //watcher.onApiPost("response: " + response);
                        }
                    }
                }, new Response.ErrorListener() {

                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // TODO: Handle error
                        for (ApiWatcher watcher : watchers){
                            //watcher.onApiError("Error: " +  error);
                        }

                    }
                });
        queue.add(jsonObjectRequest);
        */

        return false;
    }


    public void postRequest(Context context){
        String url = "http://projektdns.westeurope.cloudapp.azure.com:81/api/NumberPlateLocations/";

        JSONObject js = new JSONObject();
        try {
            js.put("NumberPlateNumber", "abcde");
            js.put("xLocation", "55.442");
            js.put("yLocation","11.786");
        } catch (JSONException e) {
            e.printStackTrace();
        }


        // Make request for JSONObject
        JsonObjectRequest jsonObjReq = new JsonObjectRequest(
                Request.Method.POST, url, js,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                       for (ApiPostWatchable _watcher : postWatchers){
                           _watcher.onApiPost(response.toString());
                       }
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                for (ApiPostWatchable _watcher : postWatchers){
                    _watcher.onApiPost(error.getMessage());
                }
            }
        }) {

            /**
             * Passing some request headers
             */
            @Override
            public Map<String, String> getHeaders() throws AuthFailureError {
                HashMap<String, String> headers = new HashMap<String, String>();
                headers.put("Content-Type", "application/json; charset=utf-8");
                return headers;
            }

        };
        Volley.newRequestQueue(context).add(jsonObjReq);
    }
}
