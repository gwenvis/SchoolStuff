var canvas = document.getElementById("myCanvas");
var context = canvas.getContext("2d");

context.strokeStyle = "#000";
context.lineWidth = 5;

context.beginPath();
context.moveTo(200,200);
context.lineTo(500,300);
context.lineTo(500, 500);
context.lineTo(200,400);
context.lineTo(200,200);
fill("#ccc");
context.stroke();
context.closePath();

context.beginPath();
context.moveTo(200,200);
context.lineTo(300, 100);
context.lineTo(600, 150);
context.lineTo(500,300);
context.lineTo(200,200);
fill("#d44");
context.stroke();
context.closePath();

context.beginPath();
context.moveTo(500, 300);
context.lineTo(700, 200);
context.lineTo(600,150);
context.lineTo(500,300);
fill("#d22");
context.stroke();
context.closePath();

context.beginPath();
context.moveTo(500,500);
context.lineTo(700,400);
context.lineTo(700,200);
context.lineTo(500, 300);
context.lineTo(500,500);
fill("#888");
context.stroke();
context.closePath();

function fillAt(x, y, color) {
    'use strict';
    context.moveTo(x, y);
    context.fillStyle = color;
    context.fill();
}

function fill(color) {
    context.fillStyle = color;
    context.fill();
}