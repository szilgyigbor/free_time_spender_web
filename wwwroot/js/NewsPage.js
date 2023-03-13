const getNewsUrl = "/api/getnews";
let placeHolder = document.querySelector("#cards");


fillCards();


async function fillCards() 
{
    let news = await getData();

    news.forEach(element => {
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
    const response = await fetch(getNewsUrl);
    const data = await response.json();
    console.log(data);
    return data.articles;
}