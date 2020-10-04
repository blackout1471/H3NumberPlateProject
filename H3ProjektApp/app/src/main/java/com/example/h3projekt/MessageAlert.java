package com.example.h3projekt;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.widget.Toast;

public class MessageAlert {

    private static MessageAlert instance;
    private static Context context;

    private  MessageAlert(){

    }

    public static MessageAlert getInstance(Context _context) {
        context = _context;

        if(instance == null){
            instance = new MessageAlert();
        }

        return instance;
    }

    public void showToast(String text){
        Toast.makeText(context, text, Toast.LENGTH_SHORT).show();
    }

    public void ShowAlert(String message){
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