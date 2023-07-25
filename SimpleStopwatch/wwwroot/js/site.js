// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const startBtn = document.getElementById('start');
const stopBtn = document.getElementById('stop');
const resetBtn = document.getElementById('reset');
const display = document.getElementById('display');
const sentInput = document.getElementById('sentTime');



startBtn.addEventListener('click', start);
stopBtn.addEventListener('click', stop);
resetBtn.addEventListener('click', reset);

let startTime;
let elapsedTime = 0;
let timerInterval;

function formatTime(milliseconds) {
    const date = new Date(milliseconds);
    const minutes = date.getUTCMinutes().toString().padStart(2, '0');
    const seconds = date.getSeconds().toString().padStart(2, '0');
    const ms = Math.floor(date.getMilliseconds() / 10).toString().padStart(2, '0');
    return `${minutes}:${seconds}.${ms}`;
}
function updateDisplay() {
    display.textContent = formatTime(elapsedTime);
}

function start() {
    startBtn.hidden = true;
    stopBtn.hidden = false;    
    startTime = Date.now() - elapsedTime;
    timerInterval = setInterval(() => {
        elapsedTime = Date.now() - startTime;
        updateDisplay();
    }, 10);
}

function stop() {
    stopBtn.hidden = true;
    resetBtn.hidden = false;    
    clearInterval(timerInterval);
    sentInput.value = elapsedTime;
}

function reset() {
    clearInterval(timerInterval);    
    elapsedTime = 0;
    updateDisplay();
    resetBtn.hidden = true;
    startBtn.hidden = false;       
    
}

function displayDateTime() {
    var date = new Date();    
    var year = date.getFullYear();
    var month = ("0" + (date.getMonth() + 1)).slice(-2);
    var day = ("0" + date.getDate()).slice(-2);

    var hours = ("0" + date.getHours()).slice(-2);
    var minutes = ("0" + date.getMinutes()).slice(-2);
    var seconds = ("0" + date.getSeconds()).slice(-2);

    var dateTime = day + "." + month + "." + year + " " + hours + ":" + minutes + ":" + seconds;

    document.getElementById("datetime").innerHTML = dateTime;
}

displayDateTime();

setInterval(displayDateTime, 1000);
