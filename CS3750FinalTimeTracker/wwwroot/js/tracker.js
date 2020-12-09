$(document).ready(function() {
    checkObserver();
});

function storeCheckboxValue() {

    //Checking to see if the checkbox is checked or the value is "true"
    var isChecked = document.getElementById("observerCheckBox").checked;
    console.log(isChecked);
    //Save value to session storage for use on other pages
    sessionStorage.setItem("observerValue", isChecked);
}

function checkObserver() {
    console.log("In Check Observer Method");

    //retreve session storage value
    var isChecked = sessionStorage.getItem("observerValue");
    console.log(isChecked);

    //if the checkbox has been checked then disable the rest of the time tracker page
    if (isChecked) {
        console.log("Button should be disabled")
        disableTracker();
    }
}

//Disabled Tracker form if the user is an observer
function disableTracker() {
    console.log("DisablingTrackerPage");
    document.getElementById("trackerDiv").disabled = true;
    document.getElementById("trackerStartStopBtn").disabled = true;
}

var timerCount;
var isTimerGoing = false;
var btn = document.getElementById("trackerStartStopBtn");
var timeValue = "";

function switchButtonState() {

    if (!isTimerGoing) {
        btn.setAttribute("class", "btn btn-lg btn-danger btn-block");
        btn.removeAttribute("data-toggle");
        btn.removeAttribute("data-target");

        btn.innerHTML = "Stop Tracking";
        document.getElementById("startTimeLabel").innerHTML = getCurrentTime();
        startClock();
        isTimerGoing = true;
    } else {
        btn.setAttribute("class", "btn btn-lg btn-success btn-block");
        btn.setAttribute("data-toggle", "modal");
        btn.setAttribute("data-target", "#recordTimeModal");

        document.getElementById("timeValueLabel").value = timeValue;
        document.getElementById("modalSave").onclick = function() {
            saveToDatabase();
        };
        btn.innerHTML = "Start Tracking";
        document.getElementById("endTimeLabel").innerHTML = getCurrentTime();
        stopClock();
        isTimerGoing = false;
    }
}

function getCurrentTime() {
    var today = new Date();
    var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    time = time.split(':'); // convert to array

    var hours = Number(time[0]);
    var minutes = Number(time[1]);

    var timeValue;

    if (hours > 0 && hours <= 12) {
        timeValue = "" + hours;
    } else if (hours > 12) {
        timeValue = "" + (hours - 12);
    } else if (hours == 0) {
        timeValue = "12";
    }

    timeValue += (minutes < 10) ? ":0" + minutes : ":" + minutes; // get minutes
    timeValue += (hours >= 12) ? " PM" : " AM"; // get AM/PM

    return timeValue;
}

function startClock() {
    timerCount = 0;
    clockId = setInterval(runClock, 1000);
}

function runClock() {
    timerCount += 1;

    timeValue = "";
    console.log(timerCount);

    var hours = Math.floor(timerCount / 60 / 60);
    var minutes = Math.floor(timerCount / 60) - (hours * 60);
    var seconds = timerCount % 60;

    timeValue += (hours < 10) ? "0" + hours : ":" + hours; // get hours
    timeValue += (minutes < 10) ? ":0" + minutes : ":" + minutes; // get minutes
    timeValue += (seconds < 10) ? ":0" + seconds : ":" + seconds; // get seconds

    document.getElementById("currentTimeLabel").innerHTML = getCurrentTime();
    document.getElementById("timer").innerHTML = timeValue;
}

function stopClock() {
    clearInterval(clockId);
}

function createTableRow() {
    var table = document.getElementById("trackedTimeTable");
    var row = table.insertRow();
}

function saveToDatabase() {
    $('#recordTimeModal').modal('hide');

    resetTimer();
    console.log("saving...");
}

function resetTimer() {
    document.getElementById("timer").innerHTML = "00:00:00";
    document.getElementById("startTimeLabel").innerHTML = "00:00";
    document.getElementById("currentTimeLabel").innerHTML = "00:00";
    document.getElementById("endTimeLabel").innerHTML = "00:00";
}

function init() {
    btn.onclick = function() {
        switchButtonState();
    };
}

init();