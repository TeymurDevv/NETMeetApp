AOS.init({
  duration: 1000,
  once: true,
});

// Initialize Typed.js
var typed = new Typed("#typed-slogan", {
  strings: ["Accessible learning, Anytime, Anywhere", "Innovative.", "Reliable.", "Student-friendly.", "Tutor-friendly."],
  typeSpeed: 50,
  backSpeed: 30,
  backDelay: 3000, // Time before backspacing
  startDelay: 1000, // Time before typing starts
  loop: true,
  showCursor: false // Hide the cursor
});
