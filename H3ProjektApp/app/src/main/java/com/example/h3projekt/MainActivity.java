package com.example.h3projekt;

import androidx.appcompat.app.AppCompatActivity;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity implements ApiWatcher {

    ApiCall apiCaller;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        apiCaller = new ApiCall();
        apiCaller.addListener(this);
        final Button button = findViewById(R.id.GetButton);
        final Button button2 = findViewById(R.id.PostButton);

        addOnClick(button);
        addOnClick(button2);
    }

    void addOnClick(Button btn){
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                ButtonClick(v);
            }
        });
    }

    void ButtonClick(View view){
        Log.d("button_click", "button has been clicked");
        final TextView textView = findViewById(R.id.textView);
        textView.setText("Clicked");

        if(view.getId() == R.id.GetButton)
            apiCaller.call(MainActivity.this);
        else
            apiCaller.post(MainActivity.this);
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

    @Override
    public void onApiResponse(String response) {
        ShowAlert(response);
    }
}
