document.addEventListener("DOMContentLoaded", function () {
    const meetingId = document.getElementById("meetingId").value;

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/meet")
        .build();

    document.getElementById("sendButton").disabled = true;

    connection.on("ReceiveMessage", function (user, message) {
        const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        const encodedMsg = `${user} says ${msg}`;
        const li = document.createElement("li");
        li.textContent = encodedMsg;
        document.getElementById("messagesList").appendChild(li);
    });

    connection.start().then(function () {
        document.getElementById("sendButton").disabled = false;
        return connection.invoke("JoinMeeting", meetingId);
    }).catch(function (err) {
        console.error(err.toString());
    });

    document.getElementById("sendButton").addEventListener("click", function (event) {
        const user = document.getElementById("userInput").value;
        const message = document.getElementById("messageInput").value;
        connection.invoke("SendMessageToMeeting", meetingId, user, message).catch(function (err) {
            console.error(err.toString());
        });
        event.preventDefault();
    });

    let localStream = null;

    async function startMedia(constraints) {
        try {
            localStream = await navigator.mediaDevices.getUserMedia(constraints);
            document.getElementById('localVideo').srcObject = localStream;
        } catch (err) {
            console.error('Error accessing media devices.', err);
        }
    }

    document.getElementById('startMicButton').addEventListener('click', function (event) {
        startMedia({ audio: true });
        event.preventDefault();
    });

    document.getElementById('stopMicButton').addEventListener('click', function (event) {
        if (localStream) {
            localStream.getAudioTracks().forEach(track => track.stop());
        }
        event.preventDefault();
    });

    document.getElementById('startCamButton').addEventListener('click', function (event) {
        startMedia({ video: true, audio: true });
        event.preventDefault();
    });

    document.getElementById('stopCamButton').addEventListener('click', function (event) {
        if (localStream) {
            localStream.getTracks().forEach(track => track.stop());
        }
        event.preventDefault();
    });

    document.getElementById('startScreenButton').addEventListener('click', async function (event) {
        try {
            localStream = await navigator.mediaDevices.getDisplayMedia({ video: true });
            document.getElementById('localVideo').srcObject = localStream;
        } catch (err) {
            console.error('Error accessing screen sharing.', err);
        }
        event.preventDefault();
    });

    document.getElementById('stopScreenButton').addEventListener('click', function (event) {
        if (localStream) {
            localStream.getVideoTracks().forEach(track => track.stop());
        }
        event.preventDefault();
    });

    // Start camera and microphone by default
    startMedia({ video: true, audio: true });
});
