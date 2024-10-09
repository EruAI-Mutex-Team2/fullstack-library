import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom"; // React Router'dan navigate almak için
import { useLocation } from "react-router-dom";
import { toast } from 'react-toastify';


const BookReader = () => {
  const [book, setBook] = useState(null); // Kitap verisini saklamak için
  const [currentPageNumber, setCurrentPageNumber] = useState(1); // Şu anki sayfa numarası
  const navigate = useNavigate(); // Yönlendirme işlemi için
  const location = useLocation(); // URL'deki parametreleri almak için
  const [user, setUser] = useState({});

  // URL'den 'bookId'yi alıyoruz
  const bookId = new URLSearchParams(location.search).get("bookId");

  // Kitap verisini fetch etmek için useEffect
  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    if (user === null) {
      navigate("/login");
    } else {
      setUser(user);
      console.log(user);
    }

      if (!response.ok) 
        {
          toast.error("Kitap verisi alınamadı", {
            onClose: () => nav(0)
          });
        }
      

      const data = await response.json();
      setBook(data);
    };

    if (bookId) {
      fetchBookData();
    }
  }, [bookId];

  // Logout butonuna basıldığında yönlendirmek için
  const handleLogoutClick = () => {
    localStorage.removeItem("userData");
    navigate("/firstPage");
  };

  // Home Page'e yönlendirmek için
  const handleHomePageClick = () => {
    navigate("/HomePage");
  };

  // Sonraki sayfaya geçmek için
  const handleNextPage = () => {
    if (book && currentPageNumber < book.sayfalar.length) {
      setCurrentPageNumber(currentPageNumber + 1);
    }
  };

  // Önceki sayfaya geri dönmek için
  const handlePreviousPage = () => {
    if (currentPageNumber > 1) {
      setCurrentPageNumber(currentPageNumber - 1);
    }
  };

  return (
    <div className="flex flex-col h-screen">
      {/* Navbar */}
      <nav className="bg-violet-500 text-white p-4 flex justify-between items-center shadow-md">
        <h1 className="text-2xl font-bold">Book Read</h1>
        <div className="flex">
          <button onClick={handleHomePageClick} className="hover:text-gray-300 p-2">Home Page</button>
          <button onClick={handleLogoutClick} className="hover:text-gray-300 p-2">Logout</button>
        </div>
      </nav>

      {/* Main Content */}
      <div className="flex flex-col items-center justify-center flex-grow bg-blue-50 p-6">
        {/* Kitap ismi */}
        <h2 className="font-bold text-xl mb-2">{book?.kitapIsmi}</h2>

        <h1 className="font-bold text-2xl mb-4">Sayfa {currentPageNumber}</h1>

        {/* Kitap içeriği */}
        <div className="p-6 border border-gray-400 rounded bg-white w-full max-w-2xl text-center shadow-lg mb-4">
          <p className="text-lg text-gray-700">
            {book?.sayfalar?.[currentPageNumber - 1]?.icerik || "Yükleniyor..."}
          </p>
        </div>

        {/* Sayfa ileri-geri butonları */}
        <div className="flex space-x-4 mb-4">
          <button
            onClick={handlePreviousPage}
            disabled={currentPageNumber === 1}
            className="px-4 py-2 bg-violet-500 text-white rounded disabled:opacity-50"
          >
            Önceki
          </button>
          <button
            onClick={handleNextPage}
            disabled={book && currentPageNumber === book.sayfalar.length}
            className="px-4 py-2 bg-violet-500 text-white rounded disabled:opacity-50"
          >
            Sonraki
          </button>
        </div>
      </div>
    </div>
  );
};

export default BookReader;
