import React from "react";

const userInfoStyle = {
  container: {
    maxWidth: "400px",
    margin: "20px auto",
    padding: "20px",
    boxShadow: "0 2px 8px rgba(0,0,0,0.1)",
    borderRadius: "10px",
    backgroundColor: "#fff",
    fontFamily: "'Segoe UI', Tahoma, Geneva, Verdana, sans-serif",
    textAlign: "center",
  },
  image: {
    width: "150px",
    height: "150px",
    borderRadius: "50%",
    objectFit: "cover",
    marginBottom: "15px",
  },
  name: {
    fontSize: "1.8rem",
    margin: "10px 0",
    color: "#333",
  },
  infoRow: {
    margin: "6px 0",
    fontSize: "1rem",
    color: "#555",
  },
  label: {
    fontWeight: "600",
  },
};

function UserInfo({ user }) {
  if (!user) return null;

  return (
    <div style={userInfoStyle.container}>
      <img
        src={user.pictureLargeUrl}
        alt={user.fullName}
        style={userInfoStyle.image}
      />
      <h2 style={userInfoStyle.name}>{user.fullName}</h2>

      <p style={userInfoStyle.infoRow}>
        <span style={userInfoStyle.label}>Email: </span> {user.email}
      </p>
      <p style={userInfoStyle.infoRow}>
        <span style={userInfoStyle.label}>Telefon: </span> {user.phone}
      </p>
      <p style={userInfoStyle.infoRow}>
        <span style={userInfoStyle.label}>Cinsiyet: </span> {user.gender}
      </p>
      <p style={userInfoStyle.infoRow}>
        <span style={userInfoStyle.label}>Doğum Tarihi: </span> {user.dateOfBirth}
      </p>
      {/* İstersen burada diğer alanları da ekleyebilirsin */}
    </div>
  );
}

export default UserInfo;
