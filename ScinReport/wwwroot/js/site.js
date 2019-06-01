// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function createUser() {
    $("#lastForm").after("<div class='form-group' id='lastForm'> </div > ")
}

function checkOne(id,check) {
    var text = document.getElementById("textcheckbox");
    var i;
    var s = "";
    for (i = 0; i < text.value.length; i++) {
        if (i == id) {
            if(check.checked==true)
                s += '1';
            else
                s += '0';
        }
        else {
            s += text.value[i];
        }

    }
    text.value = s;
}
function checkAll(ch) {
    var el = document.getElementsByClassName("checkbox");
    var text = document.getElementById("textcheckbox");
    var s = "";
    var i;
    if (ch.checked == true) {
        for (i = 0; i < el.length; i++) {
            el[i].checked = 1;
        }
        for (i = 0; i < text.value.length; i++) {
                    s += '1';
            }

        }
    else {
        for (i = 0; i < el.length; i++) {
            el[i].checked = 0;
        }
        for (i = 0; i < text.value.length; i++) {
            s += '1';
        }
    }
    text.value = s;
}