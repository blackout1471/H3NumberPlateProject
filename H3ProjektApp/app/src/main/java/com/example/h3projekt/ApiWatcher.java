package com.example.h3projekt;

public interface ApiWatcher {
    public  void  onApiResponse(NumberPlate response);
    public  void onApiError(String message);
}
