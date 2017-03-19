class Ball {
    constructor(x,y) {
        this.x = x;
        this.y = y;
    }
    
    update() {
        x+= 2;
    }
}

var ball = new Ball(100,100);
var ball2 = new Ball(100,150);
var ball3 = new Ball(100,200);

var balls = [ball, ball2, ball3];

balls[0].update();
ball.update();

