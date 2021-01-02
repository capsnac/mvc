function IsEmailValid(email) {
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
        return false;
    } else {
        return true;
    }
};

function showLoader() {
    $("#loader_screen").css("display", "block");
}

function hideLoader() {
    $("#loader_screen").css("display", "none");
}