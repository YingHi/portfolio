package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class TitleActivity extends AppCompatActivity {

    Button m_BtnStart;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_title);
        setTitle("Tic Tac Toe");

        m_BtnStart = (Button)findViewById(R.id.btnstart);
        m_BtnStart.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startbtn();
            }
        });
    }

    public void startbtn(){
        Intent intent = new Intent(this,MainActivity.class);
        startActivity(intent);
        finish();
    }
}