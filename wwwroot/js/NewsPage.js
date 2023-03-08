const api_key = "ad7b28e663bc4ae1a0037d4aa79f32a0";
const country = "hu";
let placeHolder = document.querySelector("#cards");




fillCards();


async function fillCards() 
{
    let news = await getData();

    news.forEach(element => {
        console.log(element.title);
        let card = document.createElement('div');
        card.classList.add('card');

        let title = document.createElement('h2');
        title.textContent = element.title;
        title.classList.add('card-title');

        let link = document.createElement('a');
        link.href = element.url;
        link.textContent = 'Read More';
        link.classList.add('card-link');
        link.target = '_blank';

        card.appendChild(title);
        card.appendChild(link);

        placeHolder.appendChild(card);

    });
}


async function getData() 
{
    const response = await fetch(`https://newsapi.org/v2/top-headlines?country=${country}&apiKey=${api_key}`);
    const data = await response.json();
    console.log(data);
    return data.articles;
}
              
getData();

