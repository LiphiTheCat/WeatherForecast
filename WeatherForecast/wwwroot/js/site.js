var selectedCountry = "Russia";
var citiesOfSelectedCountry;
var selectedCity = "Moscow";

function GetCountries() {
    $.ajax({
        url: "https://localhost:5001/Home/GetCountries",
        type: "GET",
        dataType: 'json',
        success: function (result) {
            result.forEach(function (item, i, arr) {
                if (item == 'Russia') {
                    $("#countries").append($('<option value="' + item + '" selected="selected"' + '">' + item + '</option>'));
                }
                else {
                    $("#countries").append($('<option value="' + item + '">' + item + '</option>'));
                }
            });
        }
    });
};
function GetCapital(Country) {
    alert("D");

    $.ajax({
        url: ("https://localhost:5001/Home/GetCapital?country=" + Country),
        type: "GET",
        dataType: 'json',
        success: function (result) {
            alert(result);
            return result;
        }
    })
};
function GetCities(Country, GetCapital) {
    var capital = GetCapital(Country);
    $.ajax({
        url: ("https://localhost:5001/Home/GetCities?country=" + Country),
        type: "GET",
        dataType: 'json',
        success: function (result) {
            result.forEach(function (item, i, arr) {
                if (item == capital) {
                    $("#cities").append($('<option value="' + item + '" selected="selected"' + '">' + item + '</option>'));
                }
                else {
                    $("#cities").append($('<option value="' + item + '">' + item + '</option>'));
                }
            });

        }
    });
};

$(document).ready(function () {
    GetCountries(GetCities)
    GetCities(selectedCountry);
})
