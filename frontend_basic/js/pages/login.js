import { registerUser, loginUser } from "../services/apiServices.js";

document.addEventListener("DOMContentLoaded", () => {
  const toggleRegisterButton = document.getElementById("toggle-register");
  const registerForm = document.getElementById("register-form");
  const loginForm = document.getElementById("login-form");

  toggleRegisterButton.addEventListener("click", () => {
    if (registerForm.style.display === "none" || !registerForm.style.display) {
      registerForm.style.display = "block";
      loginForm.style.display = "none";
    } else {
      registerForm.style.display = "none";
      loginForm.style.display = "block";
    }
  });

  loginForm.addEventListener("submit", async (event) => {
    event.preventDefault();
    console.log("Login form submitted"); // Debugging line
    const credentials = {
      email: document.getElementById("email").value,
      password: document.getElementById("password").value,
    };

    console.log("Login credentials:", credentials); // Debugging line
    try {
      const result = await loginUser(credentials);
      alert("Login successful!");
      loginForm.reset();
      // Redirect or perform post-login actions
      window.location.href = "/frontend_basic/index.html";
    } catch (error) {
      alert("Login failed. Please check your credentials and try again.");
    }
  });
});
