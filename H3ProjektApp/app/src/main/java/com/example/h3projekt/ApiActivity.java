package com.example.h3projekt;

import androidx.appcompat.app.AppCompatActivity;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.location.Address;
import android.location.Geocoder;
import android.os.Bundle;
import android.widget.TextView;
import android.widget.Toast;

import java.io.IOException;
import java.text.DecimalFormat;
import java.util.List;
import java.util.Locale;

public class ApiActivity extends AppCompatActivity implements ApiGetWatchable {

    ApiCall apiCaller;
    TextView view;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_api);

        apiCaller = new ApiCall();
        apiCaller.addGetListener(this);

        // Get number plate from the user input from main activity
        String plateNumber = getIntent().getStringExtra("PlateNumber");

        // Display message at the bottom of the screen
        MessageAlert.getInstance().showToast(ApiActivity.this, plateNumber);

        // Make get request with the numberplate
        apiCaller.getRequest(ApiActivity.this, plateNumber);
    }

    // Set text fields with the numberplate information
    void setPlateText(NumberPlate plate){
        setView(R.id.stolenText, "Ja");
        setView(R.id.plateText, plate.getNumber());
        setView(R.id.locationView, getCityFromXandY(formatDouble(plate.getxLoc()), formatDouble(plate.getyLoc())));
        setView(R.id.lastSeenView_, formatString(plate.getTimeSpotted()));
    }

    // Format latitude and longitude lenght to be only 6 number after decimal
    Double formatDouble(Double num){
        DecimalFormat df = new DecimalFormat("#.######");
        //ShowAlert(df.format(num));
        return Double.valueOf(df.format(num));
    }

    // Format time send by api from api
    String formatString(String str){
        str = str.replace('T', ' ');
        return str;
    }

    // Sets text view of the text view element
    void setView(int id, String text){
        view = (TextView)findViewById(id);
        view.setText(text);
    }

    @Override
    public void onApiResponse(NumberPlate response) {
        setPlateText(response);
    }

    @Override
    public void onApiError(String message) {
        setView(R.id.numberPlateText, message);
        setView(R.id.plateText, "Error");
        setView(R.id.locationView, "Error");
    }

    // Get city name from latitude and longitude
    String getCityFromXandY(Double xPos,Double yPos){

        Geocoder geoCoder = new Geocoder(ApiActivity.this, Locale.ENGLISH);

        try {
            List<Address> address = geoCoder.getFromLocation(xPos, yPos, 1);
            String finalAdress = address.get(0).getLocality();

            // Some locations don't have locality set,
            // in case that location doesn't have locality we use featurename
            // which should result in similar output
            if(finalAdress == ""){
                finalAdress = address.get(0).getFeatureName();
            }

            return finalAdress;

        } catch (IOException e) {
            MessageAlert.getInstance().showToast(ApiActivity.this, e.getMessage());
        } catch (NullPointerException e) {
            MessageAlert.getInstance().showToast(ApiActivity.this, e.getMessage());
        }
        return "Could not find position";
    }
}
