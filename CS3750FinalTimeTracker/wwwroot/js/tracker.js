$(document).ready(function () {
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
    if (isChecked == "true") {
        console.log("Button should be disabled")
        disableTracker();
    }

    else {
        document.getElementById("timeTrackerDiv").style.display = "block";
    }
}

//Disabled Tracker form if the user is an observer
function disableTracker() {
    console.log("DisablingTrackerPage");
    //document.getElementById("trackerDiv").disabled = true;
    //document.getElementById("trackerStartStopBtn").disabled = true;
    document.getElementById("timeTrackerDiv").style.display = "none";
}

var timerCount;
var isTimerGoing = false;
var btn = document.getElementById("trackerStartStopBtn");
var timeValue = "";

var startTime;
var endTime;

function switchButtonState() {

    if (!isTimerGoing) {
        btn.setAttribute("class", "btn btn-lg btn-danger btn-block");
        btn.removeAttribute("data-toggle");
        btn.removeAttribute("data-target");

        btn.innerHTML = "Stop Tracking";
        startTime = getCurrentTime();
        document.getElementById("startTimeLabel").innerHTML = startTime;
        startClock();
        isTimerGoing = true;
    } else {
        btn.setAttribute("class", "btn btn-lg btn-success btn-block");
        btn.setAttribute("data-toggle", "modal");
        btn.setAttribute("data-target", "#recordTimeModal");

        endTime = getCurrentTime();
        document.getElementById("endTimeLabel").innerHTML = endTime;
        document.getElementById("timeValueLabel").value = timerCount;
        document.getElementById("startTimeValueLabel").value = startTime;
        document.getElementById("endTimeValueLabel").value = endTime;
        document.getElementById("modalSave").onclick = function () {
            saveToDatabase();
        };
        btn.innerHTML = "Start Tracking";
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

    updateChart();
}

function updateChart() {

    var userList = JSON.parse(document.getElementById('usersList').innerHTML);
    var totalTimeList = JSON.parse(document.getElementById('totalTimeList').innerHTML);

    var ctx = document.getElementById('myChart').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: userList,
            datasets: [{
                label: '# of Votes',
                data: totalTimeList,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        }
    });
}

init();
