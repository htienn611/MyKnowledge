import { callApi } from "./configBase.js";

export async function registerUser(userData) {
  try {
    return callApi("user/register", "POST", userData);
  } catch (error) {
    console.error("Registration failed:", error);
    throw error;
  }
}

export async function loginUser(credentials) {
  try {
    const response = await callApi("user/login", "POST", credentials);
    // Store the token in localStorage or sessionStorage
    if (response.token) {
      localStorage.setItem("authToken", response.token);
    }
    return response;
  } catch (error) {
    console.error("Login failed:", error);
    throw error;
  }
}

// Export all API functions
