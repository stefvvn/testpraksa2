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

var FullName = getCookie("firstName") + " " + getCookie("lastName");

document.getElementById('SettingsSessionName').textContent = FullName;
document.getElementById('FeedSessionName').textContent = FullName;

var postBtn = document.getElementById("PostBtn");

postBtn.onclick = function () {
    var userId = getCookie("userID");
    var title = document.getElementById("TitleBox").value;
    var content = document.getElementById("ContentBox").value;
    $.ajax({
        type: "POST",
        url: "PostEntities/Create",
        data: { 'UserID': userId, 'Title': title, 'Content': content },
        success: function (response) {
            alert("Made post:  " + title + "  " + content);
            location.reload()
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr);
        }
    });
}


function likeClick(ButtonNumber) {
    var userId = getCookie("userID");
    var postId = ButtonNumber.getAttribute("PostId");
    var postLikeStatus = ButtonNumber.getAttribute("PostLikeStatus");
    var postLikeId = ButtonNumber.getAttribute("PostLikeId");

    alert("PostId: " + postId);
    alert("PostLikeStatus: " + postLikeStatus);
    alert("PostLikeId: " + postLikeId);

        //$.ajax({
        //    type: "POST",
        //    url: "PostLikeEntities/Create",
        //    data: { 'UserId': userId, 'PostId': postId, 'PostLikeStatus': 1 },
        //    success: function (response) {
        //        alert("Liked Post: " + postId + "  UserID: " + userId);
        //        location.reload()
        //    },
        //    error: function (xhr, ajaxOptions, thrownError) {
        //        alert(xhr);
        //    }
        //});
}

function commentClick(commentBtn) {
    var userId = getCookie("userID");
    var postId = commentBtn.getAttribute("PostId");
    var postLikeStatus = commentBtn.getAttribute("PostLikeStatus");
    var postLikeId = commentBtn.getAttribute("PostLikeId");

    alert("PostId: " + postId);
    alert("PostLikeStatus: " + postLikeStatus);
    alert("PostLikeId: " + postLikeId);

    //$.ajax({
    //    type: "POST",
    //    url: "PostLikeEntities/Create",
    //    data: { 'UserId': userId, 'PostId': postId, 'PostLikeStatus': 1 },
    //    success: function (response) {
    //        alert("Liked Post: " + postId + "  UserID: " + userId);
    //        location.reload()
    //    },
    //    error: function (xhr, ajaxOptions, thrownError) {
    //        alert(xhr);
    //    }
    //});
}