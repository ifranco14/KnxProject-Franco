$(document).ready(function () {
    $('#PersonType').change(function () {
        selection = $(this).val();
        switch (selection) {
            case 'Lawyer':
                $('#Lawyer').show();
                $('#Employee').hide();
                $('#Client').hide();
                break;
            case 'Employee':
                $('#Employee').show();
                $('#Lawyer').hide();
                $('#Client').hide();
                break;
            case 'Client':
                $('#Client').show();
                $('#Lawyer').hide();
                $('#Employee').hide();
                break;
            default:
                $('#Lawyer').hide();
                $('#Employee').hide();
                $('#Client').hide();
                break;
        }
    })
});
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
