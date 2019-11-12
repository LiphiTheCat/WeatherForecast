var countries;
function GetCountries()
{
    $.ajax({
        url: "https://localhost:5001/Home/GetCountries",
        type: "GET",
        dataType: 'json',
        success: function (result) {
            result.forEach(function (item, i, arr) {
                $("#countries").append($('<option value="' + item + '">' + item + '</option>'));
               
            });               
        }
    });
}
function GetCapitals() {
    $.ajax({
        url: "https://localhost:5001/Home/GetCountries",
        type: "GET",
        dataType: 'json',
        success: function (result) {
            result.forEach(function (item, i, arr) {
                if (item == "Nepal") {
                    $("#countries").append($('<option selected="selected value="' + item + '">' + item + '</option>'));
                    alert("Test")
                }
                else {
                    $("#countries").append($('<option value="' + item + '">' + item + '</option>'));
                }
            });
        }
    });
}
$(document).ready(function ()
{
    GetCountries()
    
})
