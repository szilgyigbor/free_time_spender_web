let amobaTable = document.querySelector("#amobaTable");
let tableSize = 20;
let currentPlayer = "X"

console.log(amobaTable);

for (let i = 0; i < tableSize; i++)
{
    const row = document.createElement('tr');
    
    for (let j = 0; j < tableSize; j++)
    {
        const cell = document.createElement('td');
        cell.textContent = ``;
        row.appendChild(cell);
    }

    amobaTable.appendChild(row);
}


amobaTable.addEventListener('click', function(event) {
    let cell = event.target;
    if (cell.tagName === 'TD') 
    {
      gameLogic(cell);
    }

  });


function gameLogic(cell) 
{
    if (currentPlayer === "X")
    {
        
        if (cell.textContent === "")
        {
            cell.textContent = "X";
            cell.classList.add("red");

            currentPlayer = "O";
        }
        
        else 
        {
            console.log("Itt már van bábú");
        }
    }


    if (currentPlayer === "O")
    {
        
        if (cell.textContent === "")
        {
            cell.textContent = "O";
            cell.classList.add("green");

            currentPlayer = "X";
        }
        
        else 
        {
            console.log("Itt már van bábú");
        }

    }
    
    
}