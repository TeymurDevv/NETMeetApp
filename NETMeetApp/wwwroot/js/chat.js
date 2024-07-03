document.querySelectorAll('.chat-list li').forEach(function (user) {
    user.addEventListener('click', function () {
      // Get the id of the clicked user
      var userId = this.id;

      // Hide all chat areas
      document.querySelectorAll('.chat').forEach(function (chat) {
        chat.classList.add('d-none');
      });

      // Show the chat area that matches the clicked user's id
      document.getElementById(userId + '-chat').classList.remove('d-none');
    });
  });