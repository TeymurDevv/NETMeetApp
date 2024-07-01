var connection = new SignalR.HubConnectionBuilder().withUrl("/chatHub").build();
connection.start();
console.log(connection);

connection.on("OnConnect", function (user) {
    let clientList = document.getElementById("clientList");
    let userName = user.FullName;
    let createdLi = document.createElement("li");
    createdLi.innerText = userName;
    clientList.appendChild(createdLi);
    
})
