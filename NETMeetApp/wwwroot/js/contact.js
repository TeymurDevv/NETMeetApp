(function () {
    emailjs.init("80-JAbIAxJn3DSh9G");
  })();

  document
    .getElementById("contact-form")
    .addEventListener("submit", function (event) {
      event.preventDefault();
      emailjs.sendForm("service_57yun4i", "template_n9dkoof", this).then(
        function () {
          alert("Email sent successfully!");
        },
        function (error) {
          alert("Failed to send email. Please try again later.");
          console.log("Failed to send email:", error);
        }
      );
    });
    