package com.example.myapplication;

import android.graphics.Color;
import android.view.View;

import java.util.EventListener;


public class TicTacToe implements EventListener {
    int i=0;
    public void addEvent(MainActivity MA, GameManager GM, int a){
        // 클릭이벤트 추가하는 메소드
        MA.Btns[a].setOnClickListener(new View.OnClickListener() {
            int m_X = a / 3;
            int m_Y = a % 3;
            @Override
            public void onClick(View v) {
                int p;
                if(MA.count % 2 == 0){
                    p = 2;
                    MA.Btns[a].setText("X");
                    MA.Btns[a].setBackgroundColor(Color.RED);
                }else{
                    p = 1;
                    MA.Btns[a].setText("O");
                    MA.Btns[a].setBackgroundColor(Color.BLUE);
                }
                MA.Check[m_X][m_Y] = p;
                MA.count+=1;
                MA.Btns[a].setClickable(false);
                int C = GM.WinCheck(MA);
                GM.win(C,MA);
            }
        });
    }
    public void addRstEvent(MainActivity MA, GameManager GM){
        MA.Rst.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                GM.Reset(MA);
            }
        });
    }

}
