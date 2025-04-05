const API_BASE_URL = "http://localhost:5280/api/";

export async function callApi(endpoint, method = "GET", body = null) {
  const headers = {
    "Content-Type": "application/json",
  };

  const response = await fetch(API_BASE_URL + endpoint, {
    method,
    headers,
    body: body ? JSON.stringify(body) : null,
  });
  if (!response.ok) {
    throw new Error(`Error: ${response.statusText}`);
  }
  return await response.json();
}
