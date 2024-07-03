
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
connection.start().then(() => {
    console.log(connection);
}).catch(err => console.error(err.toString()));
document.addEventListener("DOMContentLoaded", function () {
    let clientList = document.getElementById("clientList");
    let chatList = document.querySelectorAll(".chat-history");
    let chatHeader = document.querySelectorAll(".chat-header");
    let chatMessage = document.querySelectorAll(".chat-message");
    connection.on("OnConnect", function (user) {
        let userName = user.fullName;
        let photo = user.imageUrl;

        let createdLi;
        if (photo != null) {
            createdLi = `
            <li id="${user.id}" class="clearfix">
                <img src="../images/${user.imageUrl}" alt="avatar" />
                <div class="about">
                    <div class="name">${user.fullName}</div>
                    <div class="status">
                        <i class="fa fa-circle online"></i> Online
                    </div>
                </div>
            </li>`;
        }
        else {
            createdLi = `
            <li id="${user.id}" class="clearfix">
                <div class="about">
                    <div class="name">${user.fullName}</div>
                    <div class="status">
                        <i class="fa fa-circle online"></i> Online
                    </div>
                </div>
            </li>`;
        }
        clientList.innerHTML += createdLi;

        const audio = new Audio('../audio/join.mp3');
        audio.play();
    });

    connection.on("DisConnect", function (userId) {
        let listItem = document.getElementById(userId);
        if (listItem) {
            clientList.removeChild(listItem);
        }
    });


    document.getElementById("send-btn-general").addEventListener("click", function () {
        const message = document.getElementById("general-message-input").value;
        connection.invoke("SendMessageGeneral", message);
    });

    connection.on("RecieveMessageGeneral", (message, user) => {
        let messageList = document.getElementById("general-chat");
        let currentdate = new Date();
        let hours = currentdate.getHours();
        let minutes = currentdate.getMinutes();

        hours = hours < 10 ? '0' + hours : hours;
        minutes = minutes < 10 ? '0' + minutes : minutes;

        let dateTime = hours + ':' + minutes;
        if (user.imageurl != null) {
            let createdLi =
                `
                            <li class="clearfix">
                                <div class="message-data">
                                    <img src="images/${user.iamgeUrl}"
                                         alt="avatar"
                                         class="avatar" />
                                    <span class="message-data-name">${user.fullName}</span>
                                    <span class="message-data-time">${dateTime}</span>
                                </div>
                                <div class="message my-message">
                                    ${message}
                                </div>
                            </li>
    `   ;
            messageList.innerHTML += createdLi;
        }

        else {
            let createdLi =
                `
                            <li class="clearfix">
                                <div class="message-data">
                                    <span class="message-data-name">${user.fullName}</span>
                                    <span class="message-data-time">${dateTime}</span>
                                </div>
                                <div class="message my-message">
                                    ${message}
                                </div>
                            </li>
    `;
            messageList.innerHTML += createdLi;
        }

    });



    clientList.childNodes.forEach(node => {
        node.addEventListener("click", function () {
            if (node.nodeType === Node.ELEMENT_NODE) {
                let elementId = node.getAttribute('id');
                let chatId = "chat-" + elementId;
                let profileId = "profile-" + elementId;
                let chatMessageId = "chat-" + elementId;
                let activeChat = document.getElementById(chatId);
                let activeProfile = document.getElementById(profileId);
                let activeChatMessage = document.getElementById(chatMessageId);

                chatList.forEach(chat => {
                    if (chat.classList.contains("d-block")) {
                        chat.classList.remove("d-block");
                    }
                    chat.classList.add("d-none")
                });
                activeChat.classList.remove("d-none");

                chatHeader.forEach(header => {
                    if (header.classList.contains("d-block")) {
                        header.classList.remove("d-block");
                    }
                    header.classList.add("d-none")
                });
                activeProfile.classList.remove("d-none");

                chatMessage.forEach(chatMessage => {
                    if (chatMessage.classList.contains("d-block")) {
                        chatMessage.classList.remove("d-block");
                    }
                    chatMessage.classList.add("d-none")
                });
                activeChatMessage.classList.remove("d-none");

            }
        });
    });
});
