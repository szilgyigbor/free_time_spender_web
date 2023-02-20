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

        if (cell.textContent == "")
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

    else if (currentPlayer === "O")
    {
        

        if (cell.textContent == "")
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


    function checkWin(cellId)
    {
        let posX = parseInt(cellId.split("-")[1]);
        let posY = parseInt(cellId.split("-")[2]);
        console.log(posX, posY);

        let winnerDiagonalPositionsLeftUpRightDown = [];
        let winnerDiagonalPositionsLeftDownRightUp = [];
        let horizontalPositions = [];
        let verticalPositions = [];

        
        for (let i = -4; i < 5; i++)
        {
            // check diagonal from left up to right down
            if (posX + i >= 0 && posY + i >= 0 && posX + i < tableSize && posY + i < tableSize)
            {
                if (document.querySelector(`#cell-${posX + i}-${posY + i}`).textContent === currentPlayer)
                {
                    winnerDiagonalPositionsLeftUpRightDown.push(`#cell-${posX + i}-${posY + i}`);
                }
                else
                {
                    winnerDiagonalPositionsLeftUpRightDown = [];
                }
            }
        

            // check diagonal from left down to right up
            if (posX + (- i) >= 0 && posY + i >= 0 && posX + (- i) < tableSize && posY + i < tableSize)
            {
                if (document.querySelector(`#cell-${posX + (- i)}-${posY + i}`).textContent === currentPlayer)
                {
                    winnerDiagonalPositionsLeftDownRightUp.push(`#cell-${posX + (- i)}-${posY + i}`);
                }
                else
                {
                    winnerDiagonalPositionsLeftDownRightUp = [];
                }
            }


            // check horizontal
            if (posY + i >= 0 &&  posY + i < tableSize)
            {
                if (document.querySelector(`#cell-${posX}-${posY + i}`).textContent === currentPlayer)
                {
                    horizontalPositions.push(`#cell-${posX}-${posY + i}`);
                }
                else
                {
                    horizontalPositions = [];
                }
            }


            // check vertical
            if (posX + i >= 0 &&  posX + i < tableSize)
            {
                if (document.querySelector(`#cell-${posX + i}-${posY}`).textContent === currentPlayer)
                {
                    verticalPositions.push(`#cell-${posX + i}-${posY}`);
                }
                else
                {
                    verticalPositions = [];
                }
            }


            // colorize winner
            if (winnerDiagonalPositionsLeftUpRightDown.length === 5)
            {
                amobaString.textContent = `${currentPlayer} has won!`;
                amobaTable.removeEventListener('click', clickHandler);
                colorizeWinnerFive(winnerDiagonalPositionsLeftUpRightDown);
                break;
            }

            else if (winnerDiagonalPositionsLeftDownRightUp.length == 5)
            {
                amobaString.textContent = `${currentPlayer} has won!`;
                amobaTable.removeEventListener('click', clickHandler);
                colorizeWinnerFive(winnerDiagonalPositionsLeftDownRightUp);
                break;
            }

            else if (horizontalPositions.length == 5)
            {
                amobaString.textContent = `${currentPlayer} has won!`;
                amobaTable.removeEventListener('click', clickHandler);
                colorizeWinnerFive(horizontalPositions);
                break;
            }

            else if (verticalPositions.length == 5)
            {
                amobaString.textContent = `${currentPlayer} has won!`;
                amobaTable.removeEventListener('click', clickHandler);
                colorizeWinnerFive(verticalPositions);
                break;
            }
        }
    }


    function colorizeWinnerFive(winnerArray)
    {
        winnerArray.forEach(element => {
            document.querySelector(`${element}`).classList.add("yellow");
        });

        if (currentPlayer === "X")
        {
            amobaString.classList.add("red");    
        }
        else
        {
            amobaString.classList.add("green");
        }

    }

}