let amobaTable = document.querySelector("#amobaTable");
let tableSize = 15;

console.log(amobaTable);

for (let i = 0; i < tableSize; i++)
{
    const row = document.createElement('tr');
    
    for (let j = 0; j < tableSize; j++)
    {
        const cell = document.createElement('td');
        cell.textContent = `${i},${j}`;
        row.appendChild(cell);
    }

    amobaTable.appendChild(row);
}


amobaTable.addEventListener('click', function(event) {
    let cell = event.target;
    if (cell.tagName === 'TD') {
      console.log(cell);
    }
  });
