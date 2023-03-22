let amobaButton = document.querySelector("#Amoba");
let newsButton = document.querySelector("#News");
let botButton = document.querySelector("#Bot");
let weatherButton = document.querySelector("#Weather");

amobaButton.addEventListener("click", navigateToAmoba);
newsButton.addEventListener("click", navigateToNews);
botButton.addEventListener("click", navigateToBot);
weatherButton.addEventListener("click", navigateToWeather);


function navigateToAmoba() {
    window.location.href = "/Amoba/Main";
}


function navigateToNews() {
    window.location.href = "/News/Main";
}


function navigateToBot() {
    window.location.href = "/TalkWithBot/Main";
}


function navigateToWeather() {
    window.location.href = "/Weather/Main";
}