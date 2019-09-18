$(document).ready(function () {
    console.log("ready!");
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/messagehub")
        .build();

    connection.start().catch(err => console.error(err.toString()));

    connection.on('NewMessage', (senderName, message) => {
        appendLine(senderName, message);
    });

    function appendLine(senderName, message) {
        let li = document.createElement('li');
        li.innerText = senderName + ": " + message;
        li.classList.add("list-group-item");
        document.getElementById('messages').appendChild(li);
    }
});