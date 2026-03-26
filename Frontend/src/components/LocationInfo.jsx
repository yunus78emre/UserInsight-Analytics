import React from "react";

const locationInfoStyle = {
  container: {
    maxWidth: "400px",
    margin: "20px auto",
    padding: "20px",
    boxShadow: "0 2px 8px rgba(0,0,0,0.1)",
    borderRadius: "10px",
    backgroundColor: "#fff",
    fontFamily: "'Segoe UI', Tahoma, Geneva, Verdana, sans-serif",
    textAlign: "left",
    color: "#444",
  },
  header: {
    fontSize: "1.5rem",
    marginBottom: "12px",
    color: "#333",
    borderBottom: "2px solid #eee",
    paddingBottom: "6px",
  },
  infoRow: {
    margin: "8px 0",
    fontSize: "1rem",
  },
  label: {
    fontWeight: "600",
    color: "#555",
  },
};

function LocationInfo({ location }) {
  if (!location) return null;

  return (
    <div style={locationInfoStyle.container}>
      <h3 style={locationInfoStyle.header}>Adres Bilgileri</h3>
      <p style={locationInfoStyle.infoRow}>
        <span style={locationInfoStyle.label}>Ülke: </span>
        {location.country}
      </p>
      <p style={locationInfoStyle.infoRow}>
        <span style={locationInfoStyle.label}>Şehir: </span>
        {location.city}
      </p>
      <p style={locationInfoStyle.infoRow}>
        <span style={locationInfoStyle.label}>Posta Kodu: </span>
        {location.postCode}
      </p>
      <p style={locationInfoStyle.infoRow}>
        <span style={locationInfoStyle.label}>Adres: </span>
        {location.streetNumber} {location.streetName}
      </p>
      <p style={locationInfoStyle.infoRow}>
        <span style={locationInfoStyle.label}>Koordinatlar: </span>
        {location.coordinateLatitude}, {location.coordinateLongtitude}
      </p>
      <p style={locationInfoStyle.infoRow}>
        <span style={locationInfoStyle.label}>Saat Dilimi: </span>
        {location.timezoneDescription} ({location.timezoneOffset})
      </p>
    </div>
  );
}

export default LocationInfo;
