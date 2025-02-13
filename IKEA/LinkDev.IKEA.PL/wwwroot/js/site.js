// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var searchInput = document.getElementById("searchInp");
searchInput.addEventListener("keyup", function () {

    var searchValue = searchInput.value;

    var xhr = new XMLHttpRequest();
    xhr.open("GET", `https://localhost:7167/Employee?search=${searchValue}`);
    xhr.send();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == XMLHttpRequest.DONE) {
            if (xhr.status == 200) {
                document.getElementById("myDiv").innerHTML = XMLhttp.responseText;
            }
            else if (xmlhttp.status == 400) {
                alert('there was an error 400');
            }
            else {
                alert('something else other than 200 was returned');
            }
        }
    }
});