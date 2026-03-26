import React, { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import "./AllUserPage.css";

function AllUserPage() {
  const [users, setUsers] = useState([]);
  const [page, setPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");
  const [gender, setGender] = useState("");
  const [nationality, setNationality] = useState("");
  const [nationalities, setNationalities] = useState([]);
  const [totalCount, setTotalCount] = useState(0);

  const pageSize = 18;
  const navigate = useNavigate();

  useEffect(() => {
    fetchUsers();
  }, [gender, nationality, page]);

  useEffect(() => {
    fetchNationalities();
  }, []);

const fetchUsers = async () => {
  try {
    const response = await axios.get("http://localhost:5034/api/AllUser/AllUser", {
      params: {
        gender: gender || null,
        nationality: nationality || null,
        pageNumber: page,
        pageSize
      }
    });

    setUsers(response.data.items || []);
    setTotalCount(response.data.totalCount || 0);

  } catch (error) {
    console.error("Kullanıcılar alınamadı", error);
  }
};

  const fetchNationalities = async () => {
    try {
      const response = await axios.get(
        "http://localhost:5034/api/AllUser/Nationalities"
      );
      setNationalities(response.data);
    } catch (error) {
      console.error("Milliyetler alınamadı", error);
    }
  };

  const filteredUsers = users.filter(user =>
    (user.fullName || "").toLowerCase().includes(searchTerm.toLowerCase())
  );

  const totalPages = Math.ceil(totalCount / pageSize);

  return (
    <div className="page-wrapper">
      <nav className="navbar">
        <h1 className="navbar-title">Kullanıcı Listesi</h1>
        <div className="navbar-filters">
          <select
            value={gender}
            onChange={(e) => {
              setGender(e.target.value);
              setPage(1);
            }}
            className="filter-select-navbar"
          >
            <option value="">Cinsiyet</option>
            <option value="male">Erkek</option>
            <option value="female">Kadın</option>
          </select>

          <select
            value={nationality}
            onChange={(e) => {
              setNationality(e.target.value);
              setPage(1);
            }}
            className="filter-select-navbar"
          >
            <option value="">Ülke</option>
            {nationalities.map((nat) => (
              <option key={nat} value={nat}>
                {nat}
              </option>
            ))}
          </select>

          <button
            className="statistics-button"
            onClick={() => navigate("/statistics")}
          >
            İstatistikler
          </button>
        </div>

        <div className="navbar-buttons">
          <button className="login-button" onClick={() => navigate("/login")}>
            Giriş Yap
          </button>
          <button
            className="register-button"
            onClick={() => navigate("/register")}
          >
            Kayıt Ol
          </button>
        </div>
      </nav>

      <div className="search-area">
        <input
          type="text"
          placeholder="İsim veya soyisim ara..."
          value={searchTerm}
          onChange={(e) => {
            setSearchTerm(e.target.value);
            setPage(1);
          }}
          className="search-input-main"
        />
      </div>

      <div className="user-list">
        {filteredUsers.map((user) => (
          <div key={user.userId} className="user-row">
            <img
              src={user.pictureThumbnailUrl}
              alt={user.fullName}
              className="user-image"
            />
            <div className="user-details">
              <p><strong>{user.fullName}</strong></p>
              <p>Mail Adresi: {user.email}</p>
              <p>İş Telefonu: {user.phone}</p>
              <p>Cep Telefonu: {user.cell}</p>
              <p>Milliyet: {user.nationality}</p>
            </div>
          </div>
        ))}
      </div>

      
      <div className="pagination">
        <button
          onClick={() => setPage((prev) => Math.max(prev - 1, 1))}
          disabled={page === 1}
          className="nav-button"
        >
          «
        </button>

        {Array.from({ length: totalPages }, (_, i) => (
          <button
            key={i}
            onClick={() => setPage(i + 1)}
            className={page === i + 1 ? "active" : ""}
          >
            {i + 1}
          </button>
        ))}

        <button
          onClick={() => setPage((prev) => Math.min(prev + 1, totalPages))}
          disabled={page === totalPages}
          className="nav-button"
        >
          »
        </button>
      </div>
    </div>
  );
}

export default AllUserPage;
