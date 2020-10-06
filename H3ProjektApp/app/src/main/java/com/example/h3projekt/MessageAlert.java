package com.example.h3projekt;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.widget.Toast;

public class MessageAlert {

    private static MessageAlert instance;

    private  MessageAlert(){

    }

    public static MessageAlert getInstance() {
        if(instance == null){
            instance = new MessageAlert();
        }

        return instance;
    }

    // Show small box with the message at the bottom of the screen
    public void showToast(Context context, String text){
        Toast.makeText(context, text, Toast.LENGTH_SHORT).show();
    }

    // Shows box with message in the middle of the screen
    // with ok button to close the box
    public void showAlert(Context context, String message){
        AlertDialog.Builder builder1 = new AlertDialog.Builder(context);
        builder1.setMessage(message);
        builder1.setCancelable(true);

        builder1.setPositiveButton(
                "OK",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.cancel();
                    }
                });


        AlertDialog alert11 = builder1.create();
        alert11.show();
    }
}