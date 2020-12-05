
$(document).ready(function () {
    checkObserver();
});

function observerCheck() {

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
    document.getElementById("trackerButton").disabled = true;
}


