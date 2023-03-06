let amobaButton = document.querySelector("#Amoba");
let newsButton = document.querySelector("#News");

amobaButton.addEventListener("click", navigateToAmoba);
newsButton.addEventListener("click", navigateToNews);


function navigateToAmoba() {
    window.location.href = "/Amoba/Amoba";
}


function navigateToNews() {
    window.location.href = "/News/News";
}