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

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_api);

        apiCaller = new ApiCall();
        apiCaller.addGetListener(this);


        String plateNumber = getIntent().getStringExtra("PlateNumber");
        MessageAlert.getInstance().showToast(ApiActivity.this, plateNumber);


        apiCaller.getRequest(ApiActivity.this, plateNumber);
    }

    void setPlateText(NumberPlate plate){
        setView(R.id.stolenText, "Ja");
        setView(R.id.plateText, plate.getNumber());
        setView(R.id.locationView, getCityFromXandY(formatDouble(plate.getxLoc()), formatDouble(plate.getyLoc())));
        setView(R.id.lastSeenView_, formatString(plate.getTimeSpotted()));
    }

    Double formatDouble(Double num){
        DecimalFormat df = new DecimalFormat("#.######");
        //ShowAlert(df.format(num));
        return Double.valueOf(df.format(num));
    }

    String formatString(String str){
        str = str.replace('T', ' ');
        return str;
    }

    TextView view;
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

    String getCityFromXandY(Double xPos,Double yPos){

        Geocoder geoCoder = new Geocoder(ApiActivity.this, Locale.ENGLISH);

        try {
            List<Address> address = geoCoder.getFromLocation(xPos, yPos, 1);
            String finalAdress = address.get(0).getLocality();

            if(finalAdress == ""){
                finalAdress = address.get(0).getFeatureName();
            }

            return finalAdress;

        } catch (IOException e) {
            // Handle IOException
            MessageAlert.getInstance().showToast(ApiActivity.this, e.getMessage());
        } catch (NullPointerException e) {
            MessageAlert.getInstance().showToast(ApiActivity.this, e.getMessage());
            // Handle NullPointerException
        }
        return "Could not find position";
    }


}
