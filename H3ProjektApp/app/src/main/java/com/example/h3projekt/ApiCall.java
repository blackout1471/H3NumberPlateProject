package com.example.h3projekt;


import android.app.DownloadManager;
import android.content.Context;
import android.util.Log;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

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

    public void call(Context context){
        String url = "https://jsonplaceholder.typicode.com/todos/1";
        RequestQueue queue = Volley.newRequestQueue(context);
        JsonObjectRequest jsonObjectRequest = new JsonObjectRequest
                (Request.Method.GET, url, null, new Response.Listener<JSONObject>() {

                    @Override
                    public void onResponse(JSONObject response) {
                        for (ApiWatcher watcher : watchers){
                            String title = null;
                            try {
                                title = response.getString("title");
                            } catch (JSONException e) {
                                e.printStackTrace();
                            }
                            watcher.onApiResponse(title);
                        }
                    }
                }, new Response.ErrorListener() {

                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // TODO: Handle error
                        for (ApiWatcher watcher : watchers){
                            watcher.onApiResponse(error.getMessage());
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
                    watcher.onApiResponse(response);
                }
            }
    }, new Response.ErrorListener() {
        @Override
        public void onErrorResponse(VolleyError error) {
            for (ApiWatcher watcher : watchers){
                watcher.onApiResponse(error.getMessage());
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
