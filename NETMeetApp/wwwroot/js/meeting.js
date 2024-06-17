// wwwroot/js/meeting.js

const urlParams = new URLSearchParams(window.location.search);
const meetingId = urlParams.get('meetId');

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/meet")
    .build();

// Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    const encodedMsg = user + " says " + msg;
    const li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
    return connection.invoke("JoinMeeting", meetingId);
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    const user = document.getElementById("userInput").value;
    const message = document.getElementById("messageInput").value;
    connection.invoke("SendMessageToMeeting", meetingId, user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
