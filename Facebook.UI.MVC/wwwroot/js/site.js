// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function ($) {
    $('.image-popup').magnificPopup({
        type: 'image',
        closeOnBgClick: true,
        closeOnContentClick: true,
        removalDelay: 150,
        mainClass: 'mfp-fade',
        zoom: {
            enabled: true,
            duration: 300,
            easing: 'ease-in-out',
            opener: function (openerElement) {
                return openerElement.is('img') ? openerElement : openerElement.find('img');
            }
        },
        image: {
            titleSrc: function (item) {
                return item.src.replace(/^.*[\\\/]/, '');
            }
        }
    });
});


//var likeButtons = document.getElementsByClassName("LikeImage");
//for (var i = 0; i < likeButtons.length; i++) {
//    if ()
//}


//var commentLikeButtons = document.getElementsByClassName("LikeImage");
//for (var i = 0; i < commentLikeButtons.length; i++) {
//    commentLikeButtons[i].className += " blue-comment-like";
//}


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


var userImgPath = "/images/img/user/" + getCookie("userID") + "/" + getCookie("imgPath");
document.getElementById("userImage").src = userImgPath.toString();
document.getElementById("userImage2").src = userImgPath.toString();
document.getElementById("userImage3").src = userImgPath.toString();


var postBtn = document.getElementById("PostBtn");


//postBtn.onclick = function () {
//    var userId = getCookie("userID");
//    var title = document.getElementById("TitleBox").value;
//    var content = document.getElementById("ContentBox").value;

//    var file = document.getElementById("upload");
//    var filename = file.files[0].name;

//    $.ajax({
//        type: "POST",
//        url: "PostEntities/Create",
//        data: { 'UserID': userId, 'Title': title, 'Content': content, 'ImgPath': filename },
//        success: function (response) {
//            alert("Made post:  " + title + "  " + content + "  " + filename);
//            location.reload()
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            alert(xhr);
//        }
//    });
//}

function likeClick(likeBtn) {
    var userId = getCookie("userID");
    var postId = likeBtn.getAttribute("PostId");
    var postLikeStatus = likeBtn.getAttribute("PostLikeStatus");
    if (postLikeStatus > 0) {
            $.ajax({
                url: 'PostLikeEntities/ToggleDelete',
                type: 'DELETE',
                data: { 'UserId': userId, 'PostId': postId },
                success: function (response) {
                    alert("Unliked Post: " + postId + "  UserID: " + userId);
                    location.reload()
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr);
                }
            });
             }
        else {
        $.ajax({
            type: "POST",
            url: "PostLikeEntities/Create",
            data: { 'UserId': userId, 'PostId': postId, 'PostLikeStatus': 1 },
            success: function (response) {
                alert("Liked Post: " + postId + "  UserID: " + userId);
                location.reload()
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr);
            }
        });
    }
}

//function commentClick(commentBtn) {
//    var userId = getCookie("userID");
//    var postId = commentBtn.getAttribute("PostId");
//    var content = $("textarea", $(commentBtn).parent()).val();
//    var file = $('input[type=file]', $(commentBtn).parent()).val();

//    $.ajax({
//        type: "POST",
//        url: "CommentEntities/Create",
//        data: { 'PostID': postId, 'UserID': userId, 'Content': content, 'ImgPath': file },
//        success: function (response) {
//            alert("Made comment:  " + content + "   on PostId:  " + postId);
//            location.reload();
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            alert(xhr);
//        }
//    });
//}


function commentClick(commentBtn) {
    var userId = getCookie("userID");
    var postId = commentBtn.getAttribute("PostId");
    var content = $("textarea", $(commentBtn).parent()).val();
    //var file = $('input[name=file]', $(commentBtn).parent()).val();
    var file = $('input[name=file]', $(commentBtn).parent());

    $.ajax({
        type: "POST",
        url: "CommentEntities/CreateComment",
        data: { 'PostID': postId, 'UserID': userId, 'Content': content, 'ImgPath': file },
        contentType: false,
        processData: false,
        success: function (response) {
            alert("Made comment:  " + content + "   on PostId:  " + postId + "    ImgPath:  " + file);
            location.reload();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr);
        }
    });
}




function likeCommentClick(commentLikeBtn) {
    var userId = getCookie("userID");
    var commentId = commentLikeBtn.getAttribute("CommentId");
    var commentLikeStatus = commentLikeBtn.getAttribute("CommentLikeStatus");
    if (commentLikeStatus > 0) {
        $.ajax({
            url: 'CommentLikeEntities/ToggleCommentLikeDelete',
            type: 'DELETE',
            data: { 'UserId': userId, 'CommentId': commentId },
            success: function (response) {
                alert("Unliked Comment: " + commentId + "  UserId: " + userId);
                location.reload()
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr);
            }
        });
    }
    else {
        $.ajax({
            type: "POST",
            url: "CommentLikeEntities/Create",
            data: { 'UserId': userId, 'CommentId': commentId, 'CommentLikeStatus': 1 },
            success: function (response) {
                alert("Liked Commment: " + commentId + "  UserID: " + userId);
                location.reload()
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr);
            }
        });
    }
}