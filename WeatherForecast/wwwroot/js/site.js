var selectedCountry = "Russia";
var citiesOfSelectedCountry;
var selectedCity = "Moscow";
var colorClass;

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

function GetCities(Country) {
    $.ajax({
        url: ("https://localhost:5001/Home/GetCities?country=" + Country),
        type: "GET",
        dataType: 'json',
        success: function (result) {
            $.ajax({
                url: ("https://localhost:5001/Home/GetCapital?country=" + Country),
                type: "GET",
                dataType: 'json',
                success: function (result1) {
                    document.getElementById("cities").remove();
                    $("#mainForm").append('<select id="cities" onchange="citysListChange()"></select>');
                    var counter = 0;
                    result.forEach(function (item, i, arr) {
                        if (counter > 1000) {

                        }
                        else {
                            if (item == result1) {
                                $("#cities").append($('<option value="' + item + '" selected="selected"' + '">' + item + '</option>'));
                            }
                            else {
                                $("#cities").append($('<option value="' + item + '">' + item + '</option>'));
                            }
                        }
                        counter++;
                    });
                    $.ajax({
                        url: ("https://localhost:5001/Home/GetWeather?city=" + result1),
                        type: "GET",
                        dataType: 'json',
                        success: function (result) {
                            fillCommand(result)
                        }
                    });

                }
            })


        }
    });
};

$(document).ready(function () {
    GetCountries()
    GetCities(selectedCountry);
    $.ajax({
        url: ("https://localhost:5001/Home/GetWeather?city=Moscow"),
        type: "GET",
        dataType: 'json',
        success: function (result) {
            fillCommand(result)
            console.log(result)
        }
    });

})

function countriesListChange() {
    var countriesList = document.getElementById("countries");
    let selectedOption = countriesList.options[countriesList.selectedIndex].text;
    GetCities(selectedOption);
}
function citysListChange() {
    var citysList = document.getElementById("cities");
    let selectedOption = citysList.options[citysList.selectedIndex].text;

    $.ajax({
        url: ("https://localhost:5001/Home/GetWeather?city=" + selectedOption),
        type: "GET",
        dataType: 'json',
        success: function (result) {
            fillCommand(result)
            console.log(result)
        }
    });
}
function fillCommand(result) {
  //  document.getElementById('disc').innerHTML = result.weather[0].description;
    document.getElementById('mainTemp').innerHTML = result.main.temp;
    document.getElementById('cityName').innerHTML = result.name;
    document.getElementById('minTemp').innerHTML = result.main.temp_min;
    document.getElementById('maxTemp').innerHTML = result.main.temp_max;
    document.getElementById('pressure').innerHTML = result.main.pressure;
    document.getElementById('winddeg').innerHTML = result.wind.deg;
    document.getElementById('winddir').innerHTML = result.wind.dir;
    document.getElementById('windspeed').innerHTML = result.wind.speed;
    document.getElementById('humidity').innerHTML = result.main.humidity;
    document.getElementById('weatherIcon').remove();
    $("#imgDiv").append('<img id="weatherIcon" src="http://openweathermap.org/img/wn/' + result.weather[0].icon + '@2x.png">');
    $("body").removeClass();
    $("body").addClass(result.weather[0].main);
    $("#countries").removeClass();
    $("#countries").addClass(result.weather[0].main);
    $("#cities").removeClass();
    $("#cities").addClass(result.weather[0].main);
    $("option").removeClass();
    $("option").addClass(result.weather[0].main);
    colorClass = result.weather[0].main;
    document.getElementById('countryName').innerHTML = document.getElementById("countries").
        options[document.getElementById("countries").selectedIndex].text;

}
