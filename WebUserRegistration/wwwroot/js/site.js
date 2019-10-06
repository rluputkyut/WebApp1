// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const uri = 'https://localhost:44341/api/users';
let todos = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function displayItems(data) {
    //var table = document.getElementById('usertb');
    //var tableBody = document.getElementById('utbody');
    var table = document.createElement('table');
    table.className = "table";
    var tableBody = document.createElement('tbody');
    //tBody.innerHTML = '';

    var row = document.createElement('tr');

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("No"));
    row.appendChild(cell);

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("Name"));
    row.appendChild(cell);

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("Email"));
    row.appendChild(cell);

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("Gender"));
    row.appendChild(cell);

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("RegisteredDate"));
    row.appendChild(cell);

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("EventDays"));
    row.appendChild(cell);

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("AddationalRequest"));
    row.appendChild(cell);

    tableBody.appendChild(row);

    data.forEach(function (rowData){
        var row = document.createElement('tr');

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(rowData.Id));
        row.appendChild(cell);

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(rowData.Name));
        row.appendChild(cell);

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(rowData.Email));
        row.appendChild(cell);

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(rowData.Gender));
        row.appendChild(cell);

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(rowData.RegisteredDate));
        row.appendChild(cell);

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(rowData.EventDays));
        row.appendChild(cell);

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(rowData.AddationalRequest));
        row.appendChild(cell);

        tableBody.appendChild(row);
    });

    table.appendChild(tableBody);
    document.body.appendChild(table);
}