import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom"; // React Router'dan navigate almak için

const BookReader = ({ bookId }) => {
  const [book, setBook] = useState({}); 
  const [page, setPage] = useState({}); 
  const navigate = useNavigate(); // Yönlendirme işlemi için useNavigate kullanıyoruz

  // useEffect, sayfa numarası değiştiğinde tetiklenecek ve veriyi backend'den çekecek
  useEffect(() => {
    const fetchPageContent = async () => {
      const response = await fetch(
        `http://localhost:5075/api/Kitap/kitapOku?kitapId=${1}`
      );

      if (!response.ok) {
        throw new Error("Kitap verisi alınamadı.");
      }

      const data = await response.json();
      setBook(data);
    };

    fetchPageContent();
  }, []);

  // Logout butonuna basılınca FirstPage'ye yönlendirecek fonksiyon
  const handleLogout = () => {
    navigate("/firstPage");
  };

  return (
    <div className="flex flex-col h-screen">
      {/* Navbar */}
      <nav className="bg-violet-500 text-white p-4 flex justify-between items-center shadow-md">
        <h1 className="text-2xl font-bold">BookReader</h1>
        <button
          onClick={handleLogout}
          className="bg-violet-700 hover:bg-violet-500 text-white px-4 py-2 rounded"
        >
          Logout
        </button>
      </nav>

      {/* Main Content */}
      <div className="flex flex-col items-center justify-center flex-grow bg-blue-50">
        <h1 className="font-bold mb-4">Sayfa</h1>

        <input
          type="number"
          min="1"
          onChange={(e) => setPage(book.sayfalar[e.target.value - 1])}
          className="p-2 border border-gray-300 rounded mb-4 w-1/4 text-center"
          placeholder="Sayfa numarası giriniz"
        />

        <div className="p-6 border border-gray-400 rounded bg-white w-1/2 text-center shadow-lg">
          <p className="text-lg text-gray-700">{page?.icerik || "Sayfa seçin"}</p>
        </div>
      </div>
    </div>
  );
};

export default BookReader;
