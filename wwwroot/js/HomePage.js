let amobaButton = document.querySelector("#Amoba");
let newsButton = document.querySelector("#News");
let talkWithBotButton = document.querySelector("#Bot");

amobaButton.addEventListener("click", navigateToAmoba);
newsButton.addEventListener("click", navigateToNews);
talkWithBotButton.addEventListener("click", navigateToBot);


function navigateToAmoba() {
    window.location.href = "/Amoba/Main";
}


function navigateToNews() {
    window.location.href = "/News/Main";
}


function navigateToBot() {
    window.location.href = "/TalkWithBot/Main";
}