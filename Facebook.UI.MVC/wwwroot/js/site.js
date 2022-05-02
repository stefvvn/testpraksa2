// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var settingsmenu = document.querySelector(".settings-menu");
var darkBtn = document.getElementById("dark-btn");

function settingsMenuToggle() {
    settingsmenu.classList.toggle("settings-menu-height");
}
darkBtn.onclick = function () {
    darkBtn.classList.toggle("dark-btn-on");
    document.body.classList.toggle("dark-theme");

    if (localStorage.getItem("theme") == "light") {
        localStorage.setItem("theme", "dark");

    }
    else {
        localStorage.setItem("theme", "light");
    }

}


if (localStorage.getItem("theme") == "light") {
    darkBtn.classList.remove("dark-btn-on");
    document.body.classList.remove("dark-theme");

}
else if (localStorage.getItem("theme") == "dark") {
    darkBtn.classList.add("dark-btn-on");
    document.body.classList.add("dark-theme");
}
else {
    localStorage.setItem("theme", "light");
}


function setCookie(cName, cValue, expDays) {
    let date = new Date();
    date.setTime(date.getTime() + (expDays * 24 * 60 * 60 * 1000));
    const expires = "expires=" + date.toUTCString();
    document.cookie = cName + "=" + cValue + "; " + expires + "; path=/";
}

function getCookie(cName) {
    const name = cName + "=";
    const cDecoded = decodeURIComponent(document.cookie);
    const cArr = cDecoded.split('; ');
    let res;
    cArr.forEach(val => {
        if (val.indexOf(name) === 0) res = val.substring(name.length);
    })
    return res;
}

//setCookie("FirstName", "Vuk", 1);
//setCookie("LastName", "Vasiljevic", 1);
//setCookie("UserID", "1", 1);
//setCookie("UserName", "TestUserName", 1);

var FullName = getCookie("firstName") + " " + getCookie("lastName");

document.getElementById('SettingsSessionName').textContent = FullName;
document.getElementById('FeedSessionName').textContent = FullName;

var postBtn = document.getElementById("PostBtn");

postBtn.onclick = function () {
    var userId = getCookie("userID");
    var title = document.getElementById("TitleBox").value;
    var content = document.getElementById("ContentBox").value;

    alert(title);
    alert(content);

    $.ajax({
        type: "POST",
        //url: "PostEntities/CreatePost", ERROR 500 = Nema CreatePost View
        //url: "PostEntities/Index", RADI
        //url: "PostEntities/Create", RADI
        url: "PostEntities/Create",
        data: { 'UserID': userId, 'Title': title, 'Content': content },
        success: function (response) {
            // ...
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr);
            alert(thrownError);
        }
    });

}

//var likeBtn = document.getElementById("LikeBtn");

//likeBtn.onclick = function () {
//    var userId = getCookie("userID");
//    var postId = document.getElementById("TitleBox").value;
//    var likeStatus = ////////////////

//    alert(postId);

//    $.ajax({
//        type: "POST",
//        url: "PostEntities/Create",
//        data: { 'UserID': userId, 'Title': title, 'Content': content },
//        success: function (response) {
//            // ...
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            alert(xhr);
//            alert(thrownError);
//        }
//    });

//}