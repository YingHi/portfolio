//classes
class player{
    constructor(x,y,radius,color,hp){
        this.position_x = x;
        this.position_y = y;
        this.radius = radius;
        this.color = color;
        this.HP = hp;
    }

    draw(){
        context.beginPath();
        context.arc(this.position_x,this.position_y,this.radius,0,2*Math.PI)
        context.fillStyle = this.color;
        context.fill()
        context.closePath();        
    }
}

class bullet{
    constructor(position_x,position_y, destination_x, destination_y, radius,color, speed, Arr_Num){
        this.position_x = position_x;
        this.position_y = position_y;
        this.destination_x = destination_x / (Math.sqrt(Math.pow(destination_x,2) + Math.pow(destination_y,2)));
        this.destination_y = destination_y / (Math.sqrt(Math.pow(destination_x,2) + Math.pow(destination_y,2)));
        this.radius = radius;
        this.color = color;
        this.speed = speed;
        this.B_N = Arr_Num;
    }
    update(){
        this.position_x += this.destination_x * this.speed;
        this.position_y += this.destination_y * this.speed;
        
    }
    draw(){
        context.beginPath();
        context.arc(this.position_x, this.position_y, this.radius, 0, 2*Math.PI);
        context.fillStyle = this.color;
        context.fill();
        context.closePath();
    }
}

class Enemy{
    constructor(position_x,position_y, destination_x, destination_y, color, speed, Arr_Num, Hp){
        this.position_x = position_x;
        this.position_y = position_y;
        this.destination_x = destination_x / (Math.sqrt(Math.pow(destination_x,2) + Math.pow(destination_y,2)));
        this.destination_y = destination_y / (Math.sqrt(Math.pow(destination_x,2) + Math.pow(destination_y,2)));
        this.color = color;
        this.radius;
        this.HP = Hp;
        this.Atk = Hp;
        this.E_N = Arr_Num;
        this.speed_x = (300 - position_x)/speed
        this.speed_y = (300 - position_y)/speed
        this.resize();
        }
    damaged(Atk){ // 데미지 받는 함수
        this.HP -= Atk;
        if(this.HP < 0){
            this.HP = 0
            console.log("0 실행");
            return 0;
        }
        this.resize();
        console.log("1 실행");
        return 1;
    }
    draw(){
        context.beginPath();
        context.arc(this.position_x, this.position_y, this.radius, 0, 2*Math.PI);
        context.fillStyle = this.color;
        context.fill();
        context.closePath();
    }
    update(){
        this.position_x += this.speed_x
        this.position_y += this.speed_y
    }
    resize(){
        this.radius = this.HP;
    }
    }