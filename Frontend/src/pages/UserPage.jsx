import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";

import UserInfo from "../components/UserInfo";
import LocationInfo from "../components/LocationInfo";

function UserPage({ onLogout }) {
  const { username } = useParams();
  const [user, setUser] = useState(null);
  const [location, setLocation] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        // Kullanıcı bilgisi çekiliyor
        const userRes = await axios.get(
          `http://localhost:5034/api/users/user?username=${username}`
        );
        const userData = userRes.data;
        setUser(userData);

        // Adres bilgisi çekiliyor
        if (userData?.userId) {
          const locationRes = await axios.get(
            `http://localhost:5034/api/locations/user?userId=${userData.userId}`
          );
          setLocation(locationRes.data);
        }
      } catch (err) {
        console.error("Veri alınırken hata oluştu", err);
      }
    };

    fetchData();
  }, [username]);

  const handleLogoutClick = () => {
    if (onLogout) onLogout(); 
    navigate("/");            
  };

  if (!user) return <p>Yükleniyor...</p>;

  return (
    <div className="user-page-container">
      <div style={{ display: "flex", justifyContent: "space-between", padding: "1rem" }}>
        <h2>{user.first} {user.last}  Profil Sayfası</h2>
        <button
          onClick={handleLogoutClick}
          style={{
            backgroundColor: "#f44336",
            color: "white",
            border: "none",
            padding: "8px 12px",
            borderRadius: "5px"
          }}
        >
          Çıkış Yap
        </button>
      </div>

      <UserInfo user={user} />
      {location ? (
        <LocationInfo location={location} />
      ) : (
        <p>Adres bilgisi bulunamadı.</p>
      )}
    </div>
  );
}

export default UserPage;
