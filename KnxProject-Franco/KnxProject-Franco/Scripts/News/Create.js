//window.URL = window.URL || window.webkitURL;

//var imgSelect = document.getElementById("imgSelect"),
//    imgElem = document.getElementById("imgElem"),
//    image = document.getElementById("image");

//imgSelect.addEventListener("click", function (e) {
//    if (imgElem) {
//        imgElem.click();
//    }
//    e.preventDefault(); // prevent navigation to "#"
//}, false);

//function handleFiles(files) {
//    if (!files.length) {
//        image.innerHTML = "<p>¡Aún no has seleccionado una imagen!</p>";
//    } else {
//        image.innerHTML = "";
//        var list = document.createElement("ul");
//        image.appendChild(list);
//        var base = new URL("/","~/Content/img/News")
//        for (var i = 0; i < files.length; i++) {
//            var li = document.createElement("li");
//            list.appendChild(li);
//            var img = document.createElement("img");
//            img.src = new URL(files[i].name, base);
//            img.height = 60;
//            li.appendChild(img);
//            var info = document.createElement("span");
//            info.innerHTML = files[i].name + ": ";
//            li.appendChild(info);
//        }

//    }
//}

// Get all variables
var bannerImage = document.getElementById('Image');
var result = document.getElementById('res');
var img = document.getElementById('img');

// 
bannerImage.addEventListener('change', function () {
    var file = this.files[0];
    if (file.type.indexOf('image') < 0) {
        res.innerHTML = 'invalid type';
        return;
    }
    var fReader = new FileReader();
    fReader.onload = function () {
        img.src = fReader.result;
        sessionStorage.setItem("imgData", getBase64Image(img));
    };
    fReader.readAsDataURL(file);
});

function getBase64Image(img) {
    var canvas = document.createElement("canvas");
    canvas.width = img.width; //TODO:set the width
    canvas.height = img.height; //TODO:set the height

    var ctx = canvas.getContext("2d");
    ctx.drawImage(img, 0, 0);

    var dataURL = canvas.toDataURL("image/png");

    return dataURL.replace(/^data:image\/(png|jpg);base64,/, "");
}

function fetchimage() {
    var dataImage = sessionStorage.getItem('imgData');
    img.src = "data:image/png;base64," + dataImage;
}



// Call fetch to get image from localStorage.
//fetchimage();
