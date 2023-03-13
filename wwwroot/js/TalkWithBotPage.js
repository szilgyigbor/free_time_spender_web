const sendButton = document.querySelector("#chat-send-button");
const chatInput = document.getElementById("chat-input");
let chatFlow = document.querySelector("#chat-messages");
let chatHistory = "";


sendButton.addEventListener("click", sendMessage);

chatInput.addEventListener("keydown", function(event) {
    if (event.keyCode === 13) {
      sendMessage();
    }
  });


async function sendMessage()
{
    let messageField = document.querySelector("#chat-input");
    let newMessage = messageField.value;
    chatHistory += newMessage + "\n"
    messageField.value = "";

    const response = await fetch('/api/getbotanswer', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(chatHistory)
      });

        
    const data = await response.json();

    console.log(data);
    let answer = data.choices[0].text.trim();

    chatHistory += answer + "\n";

    console.log(chatHistory);

    chatFlow.insertAdjacentHTML('afterbegin', 
    `<p>
        <span class="chat-me">Me:</span> ${newMessage}
        <br>
        <span class="chat-bot">Bot:</span> ${answer}
    </p>`
    );

}

