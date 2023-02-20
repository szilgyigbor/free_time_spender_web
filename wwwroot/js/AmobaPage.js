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
            //currentPlayer = "O";
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


            

            if (winnerDiagonalPositionsLeftUpRightDown.length === 5)
            {
                amobaString.textContent = `${currentPlayer} has won!`;
                amobaTable.removeEventListener('click', clickHandler);
                colorizeWinnerFive(winnerDiagonalPositionsLeftUpRightDown);
            }

            else if (winnerDiagonalPositionsLeftDownRightUp.length == 5)
            {
                amobaString.textContent = `${currentPlayer} has won!`;
                amobaTable.removeEventListener('click', clickHandler);
                colorizeWinnerFive(winnerDiagonalPositionsLeftDownRightUp);
            }

        }
        
        // check diagonal right down
        /*for (let i = 0; i < 5; i++)
        {
            if (posX + i < tableSize && posY + i < tableSize)
            {
                if (document.querySelector(`#cell-${posX + i}-${posY + i}`).textContent === currentPlayer)
                {
                    winnerDiagonalPositionsRightDown.push(`#cell-${posX + i}-${posY + i}`);
                    console.log(winnerDiagonalPositionsRightDown);
                }
                else
                {
                    break;
                }
            }
        }*/



        // Check columns and rows
        
        /*for (let i = 0; i < tableSize; i++)
        {
            let winnerRowPositions = [];
            let winnerColumnPositions = [];
            let howManyInRows = 0;
            let howManyInColumns = 0;

            for (let j = 0; j < tableSize; j++)
            {

                if (document.querySelector(`#cell-${i}-${j}`).textContent === currentPlayer) 
                {
                    howManyInRows++;
                    winnerRowPositions.push(`#cell-${i}-${j}`);
                }
                else
                {
                    howManyInRows = 0;
                    winnerRowPositions = [];
                }

                if (document.querySelector(`#cell-${j}-${i}`).textContent === currentPlayer) 
                {
                    howManyInColumns++;
                    winnerColumnPositions.push(`#cell-${j}-${i}`);
                }
                else
                {
                    howManyInColumns = 0;
                    winnerColumnPositions = [];
                }

                if (howManyInRows === 5) 
                {
                    amobaString.textContent = `${currentPlayer} has won!`;
                    amobaTable.removeEventListener('click', clickHandler);
                    colorizeWinnerFive(winnerRowPositions);
                }
                    
                if (howManyInColumns === 5)
                {
                    amobaString.textContent = `${currentPlayer} has won!`;
                    amobaTable.removeEventListener('click', clickHandler);
                    colorizeWinnerFive(winnerColumnPositions);
                }
            }
        }

        // Check diagonal

        for (let i = 0; i < tableSize; i++)
        {
            for (let j = 0; j < tableSize; j++)
            {
                let howManyInDiagonals = 0;
                let winnerDiagonalPositions = [];

                for (let k = 0; k < 5; k++) 
                {
                    if (document.querySelector(`#cell-${i+k}-${j+k}`).textContent === currentPlayer) 
                    {
                        winnerDiagonalPositions.push(`#cell-${i+k}-${j+k}`);
                        howManyInDiagonals++;
                        if (currentPlayer === "X")
                        {
                            console.log(winnerDiagonalPositions);
                        }
                        
                    }
                    
                    else 
                    {
                        howManyInDiagonals = 0;
                        winnerDiagonalPositions = []
                        break;
                    }
                    
                    if (howManyInDiagonals === 5) 
                    {
                        amobaString.textContent = `${currentPlayer} has won!`;
                        amobaTable.removeEventListener('click', clickHandler);
                        colorizeWinnerFive(winnerDiagonalPositions);
                    }


                }
                
            }
        } */
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