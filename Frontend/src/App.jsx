import React, { useState, useEffect } from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  useNavigate,
} from "react-router-dom";
import AllUserPage from "./pages/AllUserPage";
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import UserPage from "./pages/UserPage";
import StatisticsPage from "./pages/StatisticsPage";

import axios from "axios";

function App() {
  const [users, setUsers] = useState([]);
  const [loggedInUsername, setLoggedInUsername] = useState("");

  // Kullanıcıları backend'den al
  const fetchUsers = async () => {
    try {
      const response = await axios.get(
        "http://localhost:5034/api/AllUser/AllUser"
      );
      if (Array.isArray(response.data)) {
        setUsers(response.data.reverse()); // Yeni gelen üstte olsun
      }
    } catch (err) {
      console.error("Kullanıcılar alınamadı", err);
    }
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  const handleNewUserAdded = (newUser) => {
    setUsers((prevUsers) => [newUser, ...prevUsers]);
  };

  return (
    <Router>
      <Routes>
        <Route
          path="/"
          element={
            <AllUserPage
              users={users}
              onLoginClickPath="/login"
              onRegisterClickPath="/register"
            />
          }
        />
        <Route
          path="/login"
          element={<LoginPage onLoginSuccess={setLoggedInUsername} />}
        />
        <Route
          path="/register"
          element={<RegisterPage onRegisterSuccess={handleNewUserAdded} />}
        />
        <Route path="/user/:username" element={<UserPage />} />

        <Route path="/" element={<AllUserPage />} />
        <Route path="/statistics" element={<StatisticsPage />} />
      </Routes>
    </Router>
  );
}

export default App;
