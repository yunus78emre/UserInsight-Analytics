import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import "./LoginPage.css";

function LoginPage({ onLoginSuccess }) {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");

    try {
      const res = await axios.post("http://localhost:5034/api/auth/login", {
        username,
        password,
      });

      if (res.data.success) {
        onLoginSuccess(username);
        navigate(`/user/${username}`);
      } else {
        
        setError(res.data.message || "Kullanıcı adı veya şifre geçersiz.");
      }
    } catch (err) {
      
      if (err.response && err.response.status === 401) {
        setError("Kullanıcı adı veya şifre geçersiz.");
      } else {
        setError("Giriş sırasında hata oluştu.");
      }
    }
  };
  const handleBackHome = () => {
    navigate("/");
  };

  return (
    <div className="login-container">
      <form className="login-box" onSubmit={handleSubmit}>
        <h2>Giriş Yap</h2>

        {error && <div className="error-msg">{error}</div>}

        <input
          type="text"
          placeholder="Kullanıcı Adı"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          required
        />

        <input
          type="password"
          placeholder="Şifre"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />

        <button type="submit" className="login-button">
          Giriş
        </button>

        <button type="button" className="back-button" onClick={handleBackHome}>
          Ana Sayfaya Dön
        </button>
      </form>
    </div>
  );
}

export default LoginPage;
