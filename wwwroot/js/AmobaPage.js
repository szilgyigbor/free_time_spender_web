let amobaTable = document.querySelector("#amobaTable");
let tableSize = 20;
let currentPlayer = "X";
let amobaString = document.querySelector("#amobaString");
let lastMove = "";
let gameEnd = false;
const newGameButton = document.createElement("button");

newGameButton.textContent = "Start a new game";
newGameButton.onclick = function() {
  location.reload();
};


// create the table
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
    if (cell.textContent == "")
    {
        cell.textContent = "X";
        cell.classList.add("red");
        lastMove = cell.id;
        checkWin(lastMove);
        if (!gameEnd)
        {
            setTimeout(aiMove, 300);
        }
    }
    
    else 
    {
        console.log("Itt már van bábú");
    }


    function checkWin(cellId)
    {
        let posX = parseInt(cellId.split("-")[1]);
        let posY = parseInt(cellId.split("-")[2]);
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
                makeWinner(currentPlayer);
                colorizeWinnerFive(winnerDiagonalPositionsLeftUpRightDown);
                break;
            }

            else if (winnerDiagonalPositionsLeftDownRightUp.length === 5)
            {
                makeWinner(currentPlayer);
                colorizeWinnerFive(winnerDiagonalPositionsLeftDownRightUp);
                break;
            }

            else if (horizontalPositions.length === 5)
            {
                makeWinner(currentPlayer);
                colorizeWinnerFive(horizontalPositions);
                break;
            }

            else if (verticalPositions.length === 5)
            {
                makeWinner(currentPlayer);
                colorizeWinnerFive(verticalPositions);
                break;
            }
        }
    }


    function makeWinner(currentPlayer)
    {
        amobaString.textContent = `${currentPlayer} has won!  `;
        amobaTable.removeEventListener('click', clickHandler);
        gameEnd = true;
        amobaString.appendChild(newGameButton);
    }


    function colorizeWinnerFive(winnerArray)
    {
        winnerArray.forEach(element => 
        {
            document.querySelector(`${element}`).classList.add("yellow");
        });
    }


    function aiMove()
    {
        currentPlayer = "O";
        let thisCell = "";
        let posX = parseInt(lastMove.split("-")[1]);
        let posY = parseInt(lastMove.split("-")[2]);

        for (let i = 0; i < 6; i++)
        {
            let randomX = Math.floor(Math.random() * 3) - 1;
            let randomY = Math.floor(Math.random() * 3) - 1;

            if (posX + randomX >= 0 && posY + randomY >= 0 && posX + randomX < tableSize && posY + randomY < tableSize)
            {
                lastMove = `#cell-${posX + randomX}-${posY + randomY}`;
                thisCell = document.querySelector(lastMove);

                if (thisCell.textContent === "")
                {
                    thisCell.textContent = currentPlayer;
                    break;
                }
            }
        }

        if (thisCell.textContent != currentPlayer)
        {
            for (let i = 0; i < 11; i++)
            {
                let randomX = Math.floor(Math.random() * 5) - 2;
                let randomY = Math.floor(Math.random() * 5) - 2;

                if (posX + randomX >= 0 && posY + randomY >= 0 && posX + randomX < tableSize && posY + randomY < tableSize)
                {
                    lastMove = `#cell-${posX + randomX}-${posY + randomY}`;
                    thisCell = document.querySelector(lastMove);

                    if (thisCell.textContent === "")
                    {
                        thisCell.textContent = currentPlayer;
                        break;
                    }
                }
            }
        }

        if (thisCell.textContent != currentPlayer)
        {
            for (let i = 0; i < 16; i++)
            {
                let randomX = Math.floor(Math.random() * 6) - 3;
                let randomY = Math.floor(Math.random() * 6) - 3;

                if (posX + randomX >= 0 && posY + randomY >= 0 && posX + randomX < tableSize && posY + randomY < tableSize)
                {
                    lastMove = `#cell-${posX + randomX}-${posY + randomY}`;
                    thisCell = document.querySelector(lastMove);

                    if (thisCell.textContent === "")
                    {
                        thisCell.textContent = currentPlayer;
                        break;
                    }
                }
            }
        }

        thisCell.classList.add("green");
        checkWin(lastMove);
        currentPlayer = "X";
    }
}