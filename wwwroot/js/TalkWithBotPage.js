const apiKey = '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';
const sendButton = document.querySelector("#chat-send-button");
let chatFlow = document.querySelector("#chat-messages");
let chatHistory = "";


sendButton.addEventListener("click", sendMessage);

async function sendMessage()
{
    let messageField = document.querySelector("#chat-input");
    let newMessage = messageField.value;
    console.log(newMessage);
    chatHistory += newMessage + "\n"
    messageField.value = "";

    const response = await fetch('https://api.openai.com/v1/completions', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + apiKey,
        },
        body: JSON.stringify({
            model: "text-davinci-003",
            prompt: chatHistory,
            temperature: 0.5,
            max_tokens: 256,
            top_p: 1,
            n: 1,
        }),
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

