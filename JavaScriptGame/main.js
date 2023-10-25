const canvas = document.getElementById('main_canvas');
var context = canvas.getContext('2d');

class GameManager{
    constructor(){
        this.score = 0;
        this.gameState = 0; //0: 시작화면, 1: 게임중, 2: 게임오버
        this.fps = 60;
        this.BulletMax = 5;
        this.BulletArr = [];
        this.EnemyArr = [];
        this.ReadyArr = [];
        this.Player = new player(canvas.width/2, canvas.height/2, 10, 'skyblue', 100);
    }

    
    
    getDistance( ax, ay, zx, zy ){ // 오브젝트 사이 거리 구하는 함수
        var dis_x = ax - zx;
        var dix_y = ay - zy;
        this.dist = Math.sqrt(Math.abs( dis_x * dis_x ) + Math.abs( dix_y * dix_y ) );
        if(this.dist < 0) this.dist * -1;
        return this.dist;
    }

    checkcollision(){ // 콜라이더 체크 함수
        for (let Enemy of this.EnemyArr) {
            if(this.getDistance(Enemy.position_x,Enemy.position_y, this.Player.position_x, this.Player.position_y) <= Enemy.radius + this.Player.radius){
                for(let i = Enemy.E_N+1; i < this.EnemyArr.length; i++ ){
                    this.EnemyArr[i].E_N -= 1;
                }
                this.Player.HP -= Enemy.HP; // 그 후 플레이어 HP 10 감소
                delete this.EnemyArr[Enemy.E_N]; // 24 ~ 28 : Enemy와 Player 사이 거리 구해서 Player에 닿으면 Enemy 삭제
                console.log(this.Player.HP);
                if(this.Player.HP < 0){
                    this.gameState = 2;
                }
                for(let i = 0; i < this.EnemyArr.length; i++) {
                    if(this.EnemyArr[i] == undefined)  {
                        this.EnemyArr.splice(i, 1);
                        i--;
                    }
                }
            }
            for (let Bullet of this.BulletArr) {
                if(this.getDistance(Enemy.position_x,Enemy.position_y, Bullet.position_x, Bullet.position_y) <= Enemy.radius + Bullet.radius){
                    for(let i = Bullet.B_N+1; i < this.BulletArr.length; i++ ){
                        this.BulletArr[i].B_N -= 1;
                    }
                    delete this.BulletArr[Bullet.B_N];
                    if(Enemy.damaged(6) == 0){
                        for(let i = Enemy.E_N+1; i < this.EnemyArr.length; i++ ){
                            this.EnemyArr[i].E_N -= 1;
                        }
                        delete this.EnemyArr[Enemy.E_N];
                        this.score += 200;
                        for(let i = 0; i < this.EnemyArr.length; i++) {
                            if(this.EnemyArr[i] == undefined)  {
                                this.EnemyArr.splice(i, 1);
                                i--;
                            }
                        }
                    }
                    for(let i = 0; i < this.BulletArr.length; i++) {
                        if(this.BulletArr[i] == undefined)  {
                            this.BulletArr.splice(i, 1);
                            i--;
                        }
                    }
                }
            }
        }
        
    }

    drawUT(){
        context.font = "30px verdana";
        context.strokeStyle = "Black";
        context.strokeText("HP : "+this.Player.HP, 20, 30);
        context.font = "30px Gulim";
        context.strokeStyle = "Black";
        this.BulletStr = "";
        for(let i = this.BulletMax-1; i >= 0; i--){
            if(this.BulletArr[i] == undefined)
                this.BulletStr += "□";
            else
                this.BulletStr += "■";
        }
        context.strokeText("Bullet : "+this.BulletStr , 20, 70);
    }


    summonEnemy(){ // Enemy 소환 함수
        if(this.gameState == 0 || this.gameState == 2) return;
        this.SMX = 500;
        this.SMY = 350;
        this.SMX = Math.floor(Math.random() * 600);
        if(this.SMX > 500 || this.SMX < 100){ // x좌표가 모서리라면 랜덤 y에 소환
         this.SMY = Math.floor(Math.random() * 600);
        }else{ // x좌표가 모서리가 아니라면 y좌표를 모서리가 나올때까지 반복
         this.R = Math.random * 2;
         if(this.R < 1){
             this.SMY = Math.floor(Math.random() * 100);  
         }else{
             this.SMY = Math.floor(Math.random() * 100) + 500;
         }
        }
        this.EnemyArr.push(new Enemy(this.SMX, this.SMY,1,1,'red',100, this.EnemyArr.length, parseInt(Math.random()*30)))
    }

    update(){
        if(this.gameState == 0){
            context.clearRect(0, 0, canvas.width, canvas.height);
            context.font = "25px verdana";
            context.strokeStyle = "Black";
            context.strokeText("게임을 시작하려면 마우스를 클릭해주세요.",60, 300);
        }
        else if(this.gameState == 1){
            this.gamePlayingUpdate();
        }
        else if(this.gameState == 2){
            context.clearRect(0, 0, canvas.width, canvas.height);
            context.font = "25px verdana";
            context.strokeStyle = "Black";
            context.strokeText("GameOver",200, 250);
            context.strokeText("Score : "+this.score, 200, 320);
        }
        
    }

    gamePlayingUpdate(){
        context.clearRect(0, 0, canvas.width, canvas.height);
        this.Player.draw();
        this.drawUT();

        for (let bullet of this.BulletArr) {
            bullet.update();
            if(bullet.position_x > 600 || bullet.position_y > 600 || bullet.position_x < 0 || bullet.position_y < 0){
                for(let i = bullet.B_N+1; i < this.BulletArr.length; i++){
                    this.BulletArr[i].B_N -= 1;
                }
                delete this.BulletArr[bullet.B_N];
            }
            for(let i = 0; i < this.BulletArr.length; i++){
                if(this.BulletArr[i] == undefined){
                    this.BulletArr.splice(i,1);
                    i--;
                }
            }
            bullet.draw();
        } 
        for (let Enemy of this.EnemyArr) {
            Enemy.update();
            Enemy.draw();
            if(Enemy.position_x > 600 || Enemy.position_y > 600 ||Enemy.position_x < 0 || Enemy.position_y < 0 ){
                for(let i = Enemy.E_N+1; i < this.EnemyArr.length; i++ ){
                    this.EnemyArr[i].E_N -= 1;
                }
                delete this.EnemyArr[Enemy.E_N];
            }
            for(let i = 0; i < this.EnemyArr.length; i++) {
                if(this.EnemyArr[i] == undefined)  {
                    this.EnemyArr.splice(i, 1);
                    i--;
                }
            }
        }
        this.checkcollision();
    }

    spawnBullet(event) {
        if(this.gameState == 0){
            this.gameState = 1;
            return;
        }
        if(this.BulletArr.length >= this.BulletMax)
            return;
        let clickpos_x = event.clientX -context.canvas.offsetLeft;
        let clickpos_y = event.clientY -context.canvas.offsetTop;
        let des_x = clickpos_x - this.Player.position_x;
        let des_y = clickpos_y - this.Player.position_y;
        this.BulletArr.push(new bullet(this.Player.position_x,this.Player.position_y,des_x,des_y,5,'green',5, this.BulletArr.length));
    }


}

var gm = new GameManager();
var start = setInterval(update,1000/gm.fps);
var start2 = setInterval(Summon,60000/gm.fps);


canvas.onclick = function(event){    
    gm.spawnBullet(event);
}

function update(){
    gm.update();
}

function Summon(){
    gm.summonEnemy();
}

