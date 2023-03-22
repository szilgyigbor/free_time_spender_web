const sendButton = document.querySelector("#location-send-button");
const locationInput = document.getElementById("location-input");
let weatherInfo = document.querySelector("#weather");


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

    const response = await fetch('/api/getweather', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(location)
    });


    const data = await response.json();
    console.log(data);

    weatherInfo.innerHTML = `
        <p>
            <span>Country:  ${data.location.country}</span> 
            <br>
            <span>Name:  ${data.location.name}</span> 
            <br>
            <span>Temperature:  ${data.current.temp_c}°C</span> 
            <img src=${data.current.condition.icon} alt="ikon">
        </p>
    `;

}