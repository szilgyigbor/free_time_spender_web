let amobaTable = document.querySelector("#amobaTable");
let tableSize = 20;
let currentPlayer = "X"
let amobaString = document.querySelector("#amobaString");


for (let i = 0; i < tableSize; i++)
{
    const row = document.createElement('tr');
    
    for (let j = 0; j < tableSize; j++)
    {
        const cell = document.createElement('td');
        cell.setAttribute('id', `cell-${i}-${j}`);
        cell.textContent = ``;
        row.appendChild(cell);
    }
    amobaTable.appendChild(row);
}


amobaTable.addEventListener('click', clickHandler);


function clickHandler(event)
{
    let cell = event.target;
    if (cell.tagName === 'TD') 
    {
        gameLogic(cell);
    }
}


function gameLogic(cell) 
{
    if (currentPlayer === "X")
    {

        if (cell.textContent === "")
        {
            cell.textContent = "X";
            cell.classList.add("red");
            checkWin(cell.id);
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
            checkWin(cell.id);
            currentPlayer = "X";
        }
        
        else 
        {
            console.log("Itt már van bábú");
        }
    }


    function checkWin(position)
    {

        let splitPosition = position.split("-");
        const row  = parseInt(splitPosition[1]);
        const collumn = parseInt(splitPosition[2]);
        console.log(row, collumn);
        
        
        for (let i = 0; i < tableSize; i++)
        {
            let howManyInRows = 0;
            let howManyInCollumns = 0;

            for (let j = 0; j < tableSize; j++)
            {

                if (document.querySelector(`#cell-${i}-${j}`).textContent === currentPlayer) 
                {
                    howManyInRows++;
                }
                else
                {
                    howManyInRows = 0;
                }

                if (document.querySelector(`#cell-${j}-${i}`).textContent === currentPlayer) 
                {
                    howManyInCollumns++;
                }
                else
                {
                    howManyInCollumns = 0;
                }

                if (howManyInRows === 5 || howManyInCollumns === 5)
                {
                    amobaString.textContent = `${currentPlayer} has won!`;
                    amobaTable.removeEventListener('click', clickHandler);
                }
            }
        }
    }
}