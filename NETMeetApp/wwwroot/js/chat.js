var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
connection.start();
console.log(connection);

connection.on("OnConnect", function (user) {
    let clientList = document.getElementById("clientList");
    let userName = user.fullName;
    let photo = user.imageUrl;



    if (photo != null)
    {
        let createdLi = `       <li id=${user.id} class="clearfix">
                                    <img src="~/images/${user.imageUrl}"
                                         alt="avatar" />
                                    <div class="about">
                                        <div class="name">${user.fullName}</div>
                                        <div class="status">
                                            <i class="fa fa-circle online"></i> Online
                                        </div>
                                    </div>
                                </li>
                    `
        clientList.innerHTML += createdLi;
    }
    else
    {
        let createdLi = `       <li id=${user.id} class="clearfix">
                                    <div class="about">
                                        <div class="name">${user.fullName}</div>
                                        <div class="status">
                                            <i class="fa fa-circle online"></i> Online
                                        </div>
                                    </div>
                            </li>
                    `
        clientList.innerHTML += createdLi;
    }
    const audio = new Audio('../audio/join.mp3');
    audio.play();
})


connection.on("DisConnect", function (userId) {
    let clientList = document.getElementById("clientList");
    let listItem = document.getElementById(userId);
    clientList.removeChild(listItem);
    const audio = new Audio('../audio/join.mp3');
    audio.play();

})