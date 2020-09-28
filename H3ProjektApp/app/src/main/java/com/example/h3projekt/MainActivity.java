package com.example.h3projekt;

import androidx.appcompat.app.AppCompatActivity;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    String numberPlate;

    ImageButton btn;
    EditText plate;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btn = (ImageButton) findViewById(R.id.searchButton);
        plate = (EditText) findViewById(R.id.numberPlateText);

        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                buttonClicked(v);
            }
        });

        final ImageButton btn2 = (ImageButton) findViewById(R.id.settingsButton);
        btn2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showSettingsAcivity();
            }
        });

        final Button btn3 = (Button) findViewById(R.id.cameraButton);
        btn3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showNumberPlateActivity();
            }
        });
    }

    void buttonClicked(View v){
        numberPlate = plate.getText().toString();

        //showToast(numberPlate);

        showApiAcivity();
    }

    void showSettingsAcivity(){
        Intent intent = new Intent(this, SettingsActivity.class);
        //ApiCallTemp temp = new ApiCallTemp(numberPlate);
        startActivity(intent);
    }

    void showNumberPlateActivity(){
        Intent intent = new Intent(this, NumberPlateRecognitionActivity.class);
        //ApiCallTemp temp = new ApiCallTemp(numberPlate);
        startActivity(intent);
    }



    void showApiAcivity(){
        Intent intent = new Intent(this, ApiActivity.class);
        //ApiCallTemp temp = new ApiCallTemp(numberPlate);

        intent.putExtra("PlateNumber", numberPlate);
        startActivity(intent);
    }

    void showToast(String text){
        Toast.makeText(MainActivity.this, text, Toast.LENGTH_SHORT).show();
    }

    void ShowAlert(String message){
        AlertDialog.Builder builder1 = new AlertDialog.Builder(MainActivity.this);
        builder1.setMessage(message);
        builder1.setCancelable(true);

        builder1.setPositiveButton(
                "Yes",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.cancel();
                    }
                });


        AlertDialog alert11 = builder1.create();
        alert11.show();
    }

}
