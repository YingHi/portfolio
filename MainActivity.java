package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {
    public Button[] Btns = new Button[9];
    public Button Rst;
    public int Check[][];
    public int count, counta;
    public TextView txt;
    TicTacToe TTT;
    GameManager GM;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("TikTacToe!");
        Make();
        TTT = new TicTacToe();
        GM = new GameManager();
        GM.Reset(this);
        for(counta = 0; counta < 9 ; counta++){
            TTT.addEvent(this, GM, counta);
        }
        TTT.addRstEvent(this,GM);
    }

    public void Make(){
        txt = (TextView) findViewById(R.id.TXT);
        Rst = (Button) findViewById(R.id.Reset);
        Btns[0] = (Button) findViewById(R.id.Btn0);
        Btns[1] = (Button) findViewById(R.id.Btn1);
        Btns[2] = (Button) findViewById(R.id.Btn2);
        Btns[3] = (Button) findViewById(R.id.Btn3);
        Btns[4] = (Button) findViewById(R.id.Btn4);
        Btns[5] = (Button) findViewById(R.id.Btn5);
        Btns[6] = (Button) findViewById(R.id.Btn6);
        Btns[7] = (Button) findViewById(R.id.Btn7);
        Btns[8] = (Button) findViewById(R.id.Btn8);
    }


}