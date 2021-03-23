import { hero } from "./models/hero";

//note that when declaring stuff, you should assign it a type
function GetAllHeroes(): void
{
    fetch("https://localhost:44352/api/Hero")
    .then(response => response.json())
    .then(responseBody => PrintHeroesTable(responseBody));
}
function PrintHeroesTable(heroes : hero[]) : void
{
    document.querySelectorAll('#heroes tbody tr').forEach(row => row.remove());
    //using the union to set table element to either be an HTMLTableElement (which is an interface), or null
    let table : HTMLTableElement | null = document.querySelector<HTMLTableElement>('#heroes tbody');
    //leveraging the truthiness of the table value
    if(table)
    {
        //for each hero from the server, add a row to the table
        for(let i: number = 0; i < heroes.length; ++i)
        {
            //inserting a row at the bottom of a table
            let row : HTMLTableRowElement = table.insertRow(table.rows.length);
            //inserting a data cell of index 0 at the row
            let heroNameCell: HTMLTableCellElement = row.insertCell(0);
            //setting the data of that cell to be the current hero's name
            heroNameCell.innerHTML = heroes[i].heroName;

            let hpCell: HTMLTableCellElement = row.insertCell(1);
            hpCell.innerHTML = heroes[i].hp.toString();

            let elementCell: HTMLTableCellElement = row.insertCell(2);
            elementCell.innerHTML = heroes[i].elementType.toString();

            let spNameCell : HTMLTableCellElement = row.insertCell(3);
            spNameCell.innerHTML = heroes[i].superPower.name;

            let spDescriptionCell : HTMLTableCellElement = row.insertCell(4);
            spDescriptionCell.innerHTML = heroes[i].superPower.description;

            let spDamageCell : HTMLTableCellElement = row.insertCell(5);
            spDamageCell.innerHTML = heroes[i].superPower.damage.toString();

        }

    }
}