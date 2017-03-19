var canvas = document.getElementById("myCanvas");
var context = canvas.getContext("2d");
var balls = [];
var ballcount = 10000;
var ballradius = 10;
var ballspeed = 5;
context.fillStyle = "#fff";

class Ball {    
    constructor(radius, x, y) {
        
        this.radius = radius;
        this.setPosition(x,y);
        this.setVelocity(
            Math.floor(Math.random() * ballspeed) - ballspeed/2, Math.floor(Math.random() * ballspeed) - ballspeed/2);
        this.color = getRandomColor();
    }
        
    setVelocity(xv, yv) {
        this.velocity = {
            x:xv,
            y:yv
        };
    }
    
    getVelocity() {
        return this.velocity;
    }

    setPosition(xpos, ypos)
    {
        this.position = { x:xpos,y:ypos};
    }
    
    getPosition() {
        return this.position;
    }
    
    getRadius() {
        return this.radius;
    }
    
    update() 
    {
        let pos = this.getPosition();
        let vel = this.getVelocity();
        pos.x += vel.x;
        pos.y += vel.y;
        
        if(pos.x + this.radius > canvas.width || pos.x-this.radius < 0)
            vel.x = -vel.x;
        if(pos.y + this.radius > canvas.height || pos.y-this.radius < 0)
            vel.y = -vel.y;
        
        this.setPosition(pos.x,pos.y);
    }
}
    
function getRandomColor() {
    
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++ ) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}



for(let i = 0; i < ballcount; i++) {
    
    let ball = new Ball(ballradius,
                        Math.floor(Math.random() * canvas.width),
                        Math.floor(Math.random() * canvas.height));
    let ballpos = ball.getPosition();
    if(ballpos.x - ball.radius < 0)
        ballpos.x = ball.radius+1;
    else if(ball.x + ball.radius > canvas.width)
        ballpos.x = canvas.width - ball.radius-1;
    
    if(ballpos.y - ball.radius < 0)
        ballpos.y = ball.radius + 1;
    else if(ballpos.y + ball.radius > canvas.height)
        ballpos.y = canvas.height - ball.radius - 1;
    
    balls.push(ball);
}



function update() {
    context.clearRect(0,0,canvas.width,canvas.height);
    for(let i = 0; i < balls.length; i++) {
        balls[i].update();
    
        draw(balls[i]);
    }
    
    window.setTimeout(update, 16);
}


function draw(b) {
    
    context.beginPath();
    let pos = b.getPosition();
    context.fillStyle = b.color;
    context.arc(pos.x, pos.y, b.getRadius(), 0, 2*Math.PI);
    context.fill();
    context.stroke();
    context.closePath();
}

update();
