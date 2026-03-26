import React, { useEffect, useState } from "react";
import axios from "axios";
import {
  BarChart,
  Bar,
  XAxis,
  YAxis,
  Tooltip,
  ResponsiveContainer
} from "recharts";
import { useNavigate } from "react-router-dom";
import "./StatisticsPage.css";


const StatisticsPage = () => {
  const [statistics, setStatistics] = useState(null);
  const [selectedChart, setSelectedChart] = useState("country");
  const navigate = useNavigate(); 


  useEffect(() => {
    const fetchStatistics = async () => {
      try {
        const response = await axios.get("http://localhost:5034/api/statistics/statistics");
        setStatistics(response.data);
      } catch (error) {
        console.error("Veri alınamadı:", error);
      }
    };

    fetchStatistics();
  }, []);

  
  const handleBackHome = () => {
    navigate("/");
  };
  

  const renderChart = () => {
    if (!statistics) return <p>Yükleniyor...</p>;




    switch (selectedChart) {
      case "gender":
        return (
          <div className="chart-box">
            <h3>Cinsiyet Dağılımı</h3>
            <ResponsiveContainer width="100%" height={300}>
              <BarChart data={[
                { name: "Kadın", value: statistics.femaleCount },
                { name: "Erkek", value: statistics.maleCount }
              ]}>
                <XAxis dataKey="name" stroke="#fff" />
                <YAxis stroke="#fff"/>
                <Tooltip />
                <Bar dataKey="value" fill="#45b39d" />
              </BarChart>
            </ResponsiveContainer>
          </div>
        );
      case "country":
        return (
          <div className="chart-box">
            <h3>Ülke Dağılımı</h3>
            <ResponsiveContainer width="100%" height={300}>
              <BarChart data={statistics.countryDistribution}>
                <XAxis dataKey="country" stroke="#fff" />
                <YAxis stroke="#fff"/>
                <Tooltip />
                <Bar dataKey="count" fill="#f39c12" />
              </BarChart>
            </ResponsiveContainer>
          </div>
        );
      default:
        return null;
    }
  };

  return (
    <div className="statistics-container">
      <div className="statistics-filter">
        <select
          className="filter-select"
          value={selectedChart}
          onChange={(e) => setSelectedChart(e.target.value)}
        >
          <option value="gender">Kadın / Erkek Sayısı</option>
          <option value="country">Ülke Dağılımı</option>
        </select>
      
      <button type="button" className="back-button" onClick={handleBackHome}>
          Ana Sayfaya Dön
        </button>
      </div>

      {renderChart()}

      {statistics && (
        <div className="summary-boxes">
          <div className="summary-box">
            <span className="summary-title">Toplam Kullanıcı</span>
            <span className="summary-value">{statistics.totalUsers}</span>
          </div>
          <div className="summary-box">
            <span className="summary-title">Ortalama Yaş</span>
            <span className="summary-value">{Math.round(statistics.averageAge)}</span>
          </div>
        </div>
      )}
    
      
    </div>
  );
};
    
export default StatisticsPage;
