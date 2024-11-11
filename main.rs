use reqwest::Client;
use serde::{Deserialize, Serialize};
use tauri::command;

#[derive(Serialize, Deserialize)]
struct RouterResponse {
    success: bool,
    session_id: Option<String>,
    lockband: Option<Vec<String>>,
}

struct RouterControl {
    router_ip: String,
    username: String,
    password: String,
    session_id: Option<String>,
}

impl RouterControl {
    async fn new(router_ip: &str, username: &str, password: &str) -> Self {
        RouterControl {
            router_ip: router_ip.to_string(),
            username: username.to_string(),
            password: password.to_string(),
            session_id: None,
        }
    }

    async fn get_session_id(&mut self) -> Result<(), String> {
        let url = format!("http://{}/cgi-bin/lua.cgi", self.router_ip);
        let response = Client::new()
            .post(&url)
            .json(&serde_json::json!({
                "cmd": 100,
                "method": "POST",
                "username": self.username,
                "passwd": self.password
            }))
            .send()
            .await
            .map_err(|_| "Failed to connect to router".to_string())?;

        let result: RouterResponse = response.json().await.map_err(|_| "Invalid response".to_string())?;
        if result.success {
            self.session_id = result.session_id;
            Ok(())
        } else {
            Err("Failed to authenticate".to_string())
        }
    }

    async fn change_lte_bands(&self, bands: Vec<String>) -> Result<String, String> {
        let url = format!("http://{}/cgi-bin/lua.cgi", self.router_ip);
        let response = Client::new()
            .post(&url)
            .json(&serde_json::json!({
                "cmd": 166,
                "method": "POST",
                "sessionId": self.session_id,
                "band": bands,
            }))
            .send()
            .await
            .map_err(|_| "Failed to change bands".to_string())?;
        let result: RouterResponse = response.json().await.map_err(|_| "Invalid response".to_string())?;
        if result.success {
            Ok("Bands changed successfully".to_string())
        } else {
            Err("Failed to change bands".to_string())
        }
    }

    async fn get_current_bands(&self) -> Result<Vec<String>, String> {
        let url = format!("http://{}/cgi-bin/lua.cgi", self.router_ip);
        let response = Client::new()
            .post(&url)
            .json(&serde_json::json!({
                "cmd": 165,
                "method": "GET",
                "sessionId": self.session_id,
            }))
            .send()
            .await
            .map_err(|_| "Failed to fetch current bands".to_string())?;
        let result: RouterResponse = response.json().await.map_err(|_| "Invalid response".to_string())?;
        Ok(result.lockband.unwrap_or_default())
    }
}

#[command]
async fn connect_router(router_ip: String, username: String, password: String) -> Result<String, String> {
    let mut router = RouterControl::new(&router_ip, &username, &password).await;
    router.get_session_id().await.map(|_| "Connected".to_string())
}

#[command]
async fn change_lte_bands(router_ip: String, username: String, password: String, bands: Vec<String>) -> Result<String, String> {
    let router = RouterControl::new(&router_ip, &username, &password).await;
    router.change_lte_bands(bands).await
}

#[command]
async fn get_current_bands(router_ip: String, username: String, password: String) -> Result<Vec<String>, String> {
    let router = RouterControl::new(&router_ip, &username, &password).await;
    router.get_current_bands().await
}
