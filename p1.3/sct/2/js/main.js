var canvas = document.getElementById("myCanvas");
var context = canvas.getContext("2d");
var ballgrabbed = false;
var throwing = false;

canvas.onmousemove = handlemouseinput;

var gravity = 0.3;
var MAX_GRAVITY = 4;

window.setTimeout(ApplyPhyiscs, 16);

function ApplyPhyiscs()
{
    console.log(mouseVelocity);
    
    if(ballgrabbed !== 1)
    {
        ballvelocity.y += gravity;;

        if(gravity > MAX_GRAVITY)
            gravity = MAX_GRAVITY;

        ballposition.y += ballvelocity.y;
        ballposition.x += ballvelocity.x;

        bounce();
    }
    else {
        
        ballposition.x += mouseVelocity.x;
        ballposition.y += mouseVelocity.y;
        mouseVelocity = {x:0,y:0};
    }
    
    draw();
    mouseVelocity = {x:0,y:0};
    window.setTimeout(ApplyPhyiscs, 16);
}

function bounce() {
    'use strict';
    
    if(ballposition.y + 50 > canvas.height) {
        ballvelocity.y *= -1;
        ballposition.y = canvas.height - 50;
    
    }
    else if(ballposition.y - 50 < 0) {
        ballvelocity.y *= -0.9;
        ballposition.y = 50;
    }
    
    if(ballposition.x - 50 < 0) {
        ballvelocity.x *= -0.8;
        ballposition.x = 50;
    }
    else if(ballposition.x + 50 > canvas.width){
        ballvelocity.x *= -0.8;
        ballposition.x = canvas.width - 50;
    }
}

var ballvelocity = { x:0, y:0 };
var ballposition = { x:0, y:0 };
var lastMousePosition = { x: 0, y:0 };
var mouseVelocity = { x:0, y:0 };
var lastMouseState = 0;
ballposition.x = canvas.width / 2;
ballposition.y = canvas.height / 2;

context.strokeStyle = "#000";
context.lineWidth = 5;
context.fillStyle = "#f44";

function draw()
{
    context.clearRect(0,0,canvas.width,canvas.height);
    context.beginPath();
    context.arc(ballposition.x, ballposition.y, 50, 0, 2*Math.PI);
    context.fill();
    context.stroke();
    context.closePath();
}

function getMousePos(canvas, evt) {
    
    var rect = canvas.getBoundingClientRect();
    return {
      x: evt.clientX - rect.left,
      y: evt.clientY - rect.top
    };
}

function getCollision(circlePosition, circleRadius, mousePosition) {
    
    var dx = circlePosition.x - mousePosition.x;
    var dy = circlePosition.y - mousePosition.y;
    return Math.abs(dx) + Math.abs(dy) <= circleRadius;
}

function handlemouseinput(x) {
    
    var mousepos = getMousePos(canvas, x);
    
    mouseVelocity.x += mousepos.x - lastMousePosition.x;
    mouseVelocity.y += mousepos.y - lastMousePosition.y;
    
    if(x.which !== 1) {
        checkThrow(x.which);
        ballgrabbed = 0;
    }
    else
        collision(mousepos);
    
    lastMouseState = x.which;
    lastMousePosition=mousepos;
}

function checkThrow(mousestate) {
    if(lastMouseState != mousestate && ballgrabbed)
    ballvelocity = mouseVelocity;
}

function collision(mousepos) {
    
    if(lastMouseState === 0 && getCollision(ballposition, 50, mousepos))
        ballgrabbed = 1;
}