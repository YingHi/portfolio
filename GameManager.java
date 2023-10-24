package com.example.myapplication;

import android.content.Intent;
import android.graphics.Color;
import android.widget.Button;
import android.widget.TextView;

import androidx.annotation.ColorInt;
import androidx.appcompat.app.AppCompatActivity;

public class GameManager extends AppCompatActivity {

    public void Reset(MainActivity MA){
        // 게임을 다시시작하는 메소드.
        MA.count = 1;
        MA.Check = new int[][] {{0,0,0},{0,0,0},{0,0,0}};
        for(int n=0;n<9;n++){
            MA.Btns[n].setClickable(true);
            MA.Btns[n].setText("BTN");
            MA.Btns[n].setBackgroundColor(Color.GRAY);
        }
        MA.txt.setText("TikTacToe");
        MA.Rst.setEnabled(false);
    }

    public void win(int num, MainActivity MA){
        // 승패를 출력하는 메소드
        if(num == 1){
            for(int n=0;n<9;n++){
                MA.Btns[n].setClickable(false);
            }
            MA.txt.setText("1P 승리!");
            MA.Rst.setEnabled(true);
        }else if(num == 2){
            for(int n=0;n<9;n++){
                MA.Btns[n].setClickable(false);
            }
            MA.txt.setText("2P 승리!");
            MA.Rst.setEnabled(true);
        }else if(MA.count == 10){
            for(int n=0;n<9;n++){
                MA.Btns[n].setClickable(false);
            }
            MA.txt.setText("무승부!");
            MA.Rst.setEnabled(true);
        }
    }

    public int WinCheck(MainActivity MA){
        // 승패를 판단하는 메소드.
        int winchk = 0;
        for(int team=1;team<3;team++){
            for(int a = 0; a < 2; a++ ){
                for(int i=0;i<3;i++){
                    winchk = 0;
                    for(int j=0;j<3;j++){
                        if(MA.Check[i][j] == team){
                            winchk += 1;
                            if(winchk == 3) {
                                return team;
                            }
                        }else{
                            break;
                        }
                    }
                }
                for(int i=0;i<3;i++){
                    winchk = 0;
                    for(int j=0;j<3;j++){
                        if(MA.Check[j][i] ==team){
                            winchk += 1;
                            if(winchk == 3) {
                                return team;
                            }
                        }else{
                            break;
                        }
                    }
                }
                winchk = 0;
                for(int i=0;i<3;i++){
                    if(MA.Check[i][i] == team){
                        winchk += 1;
                        if(winchk == 3) {
                            return team;
                        }
                    }else{
                        break;
                    }
                }
                winchk = 0;
                if(MA.Check[0][2] == team){
                    winchk += 1;
                }
                if(MA.Check[1][1] == team){
                    winchk += 1;
                }
                if(MA.Check[2][0] == team){
                    winchk += 1;
                }
                if(winchk == 3) {
                    return team;
                }
            }
        }
        return 0;
    }

}
