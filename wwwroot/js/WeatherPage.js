const sendButton = document.querySelector("#location-send-button");
const locationInput = document.getElementById("location-input");
let weatherInfo = document.querySelector("#weather");
//let imagePlace = document.querySelector("#image-place");


sendButton.addEventListener("click", sendLocation);

locationInput.addEventListener("keydown", function (event) {
    if (event.keyCode === 13) {
        sendLocation();
    }
});


async function sendLocation() {
    let locationInput = document.getElementById("location-input");
    let location = locationInput.value;
    locationInput.value = "";

    const pictureResponse = await fetch('/api/getimage', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(location)
    });

    const pictureData = await pictureResponse.json();

    console.log(pictureData);

    let largepicture = pictureData.sizes.size.find(size => size.label === "Large");

    let pictureUrl = largepicture.source;

    console.log(pictureUrl);
    document.body.style.backgroundImage = "url('" + pictureUrl + "')";

    const weatherResponse = await fetch('/api/getweather', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(location)
    });

    const weatherData = await weatherResponse.json();
    weatherInfo.style.display = 'block';

    
    console.log(weatherData);

    weatherInfo.innerHTML = `
        <p>
            <span>Country:  ${weatherData.location.country}</span> 
            <br>
            <span>Name:  ${weatherData.location.name}</span> 
            <br>
            <span>Temperature:  ${weatherData.current.temp_c}°C</span> 
            <br>
            <span><img src=${weatherData.current.condition.icon} alt="ikon"> ( ${weatherData.current.condition.text} ) </span> 
        </p>
    `;

    //imagePlace.innerHTML = `<img src=${pictureUrl} alt="picture">`;

}