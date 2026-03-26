import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import "./RegisterPage.css";

function RegisterPage({ onRegisterSuccess }) {
  const [formData, setFormData] = useState({
    username: "",
    password: "",
    gender: "",
    title: "",
    first: "",
    last: "",
    email: "",
    phone: "",
    cell: "",
    dobDate: "",
    dobAge: "",
    nationality: "",
    streetNumber: "",
    streetName: "",
    city: "",
    state: "",
    country: "",
    postCode: "",
  });

  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleChange = (e) => {
    setFormData((prev) => ({
      ...prev,
      [e.target.name]: e.target.value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");

    try {
      const payload = {
        ...formData,
        dobAge: Number(formData.dobAge),
        
        dobDate: formData.dobDate,
        registeredDate: new Date().toISOString(),
        registeredAge: 0,
      };

      console.log("Gönderilen payload:", payload);

      const res = await axios.post(
        "http://localhost:5034/api/Create/create",
        payload
      );

      if (res.status === 200) {
        if (onRegisterSuccess) onRegisterSuccess(res.data);
        navigate("/");
      }
    } catch (err) {
      if (err.response) {
        setError(
          `Hata: ${err.response.data.message || err.response.statusText}`
        );
        console.error("Backend Hatası:", err.response.data);
      } else if (err.request) {
        setError("Sunucuya bağlanılamadı.");
        console.error("İstek yapıldı, cevap alınamadı:", err.request);
      } else {
        setError("İstek sırasında hata oluştu.");
        console.error("Hata:", err.message);
      }
    }
  };

  const handleBackHome = () => {
    navigate("/");
  };

  return (
    <div className="register-container">
      <form className="register-form" onSubmit={handleSubmit}>
        <h2>Kayıt Ol</h2>

        {error && <p className="error-msg">{error}</p>}

        <input
          name="username"
          placeholder="Kullanıcı Adı"
          value={formData.username}
          onChange={handleChange}
          required
        />

        <input
          name="password"
          type="password"
          placeholder="Şifre"
          value={formData.password}
          onChange={handleChange}
          required
        />

        <input
          name="title"
          placeholder="Unvan (Bay, Bayan, ...)"
          value={formData.title}
          onChange={handleChange}
          required
        />

        <input
          name="first"
          placeholder="Ad"
          value={formData.first}
          onChange={handleChange}
          required
        />

        <input
          name="last"
          placeholder="Soyad"
          value={formData.last}
          onChange={handleChange}
          required
        />

        <input
          name="email"
          type="email"
          placeholder="Email"
          value={formData.email}
          onChange={handleChange}
          required
        />

        <input
          name="phone"
          placeholder="İş Telefonu"
          value={formData.phone}
          onChange={handleChange}
          required
        />

        <input
          name="cell"
          placeholder="Cep Telefonu"
          value={formData.cell}
          onChange={handleChange}
          required
        />

        <input
          name="dobAge"
          type="number"
          placeholder="Yaş"
          value={formData.dobAge}
          onChange={handleChange}
          required
          min={0}
        />

        <input
          name="nationality"
          placeholder="Milliyet"
          value={formData.nationality}
          onChange={handleChange}
          required
        />



        <input
          name="streetName"
          placeholder="Sokak Adı"
          value={formData.streetName}
          onChange={handleChange}
          required
        />

        <input
          name="city"
          placeholder="Şehir"
          value={formData.city}
          onChange={handleChange}
          required
        />

        <input
          name="state"
          placeholder="İlçe / Bölge"
          value={formData.state}
          onChange={handleChange}
          required
        />

        <input
          name="country"
          placeholder="Ülke"
          value={formData.country}
          onChange={handleChange}
          required
        />

        

        <label htmlFor="dobDate">Doğum Tarihi</label>
        <input
          name="dobDate"
          type="date"
          value={formData.dobDate}
          onChange={handleChange}
          required
        />
        <div className="gender-group">
          <label>Cinsiyet:</label>
          <div className="gender-options">
            <label>
              <input
                type="radio"
                name="gender"
                value="male"
                checked={formData.gender === "male"}
                onChange={handleChange}
                required
              />
              Erkek
            </label>

            <label>
              <input
                type="radio"
                name="gender"
                value="female"
                checked={formData.gender === "female"}
                onChange={handleChange}
              />
              Kadın
            </label>

            <label>
              <input
                type="radio"
                name="gender"
                value="other"
                checked={formData.gender === "other"}
                onChange={handleChange}
              />
              Diğer
            </label>
          </div>
        </div>

        <button type="submit" className="register-button">Kayıt Ol</button>

        <button type="button" className="back-button" onClick={handleBackHome}>
          Ana Sayfaya Dön
        </button>
      </form>
    </div>
  );
}

export default RegisterPage;
