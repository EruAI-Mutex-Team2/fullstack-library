import React, { useEffect, useState } from 'react';
import { Link, useNavigate, useSearchParams } from 'react-router-dom';

export default function HomePage() {
  const nav = useNavigate();
  const [user,setUser] = useState({});

  const handleLogoutClick = () => {
    localStorage.removeItem("userData");
    nav("/");
  };

  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    if (user === null) {
      nav("/login");
    }else{
      setUser(user);
    }


  }, []);

  return (
    <div className="h-screen flex flex-col items-center justify-start bg-white"> {/* Arka plan beyaz yapıldı */}
      {/* Ana içerik */}
      <div className="text-center mt-20"> {/* Yukarıda ortalandı */}
        <h1 className="text-5xl font-bold mb-4 text-violet-700" style={{ fontFamily: "cursive" }}>
          Welcome to Your Library!
        </h1>
      </div>

      {/* Üst menü */}
      <div className="flex flex-col items-center  mt-10">
        <h2 className="text-violet-700 text-xl mb-4">Select an Option:</h2>
        {(user.rolIsmi === "yazar") && ( <Link to="/MyBooks">
          <button className="bg-violet-700 text-white py-2 px-4 mb-2 rounded-lg hover:bg-violet-600 transition-all w-64"> {/* Butonların genişliği belirlendi */}
            My Books
          </button>
        </Link>)}
        <Link to="/BookList">
          <button className="bg-violet-700 text-white py-2 px-4 mb-2 rounded-lg hover:bg-violet-600 transition-all w-64">
            Book List
          </button>
        </Link>
        <Link to="/BorrowRequests">
          <button className="bg-violet-700 text-white py-2 px-4 mb-2 rounded-lg hover:bg-violet-600 transition-all w-64">
            Borrow Requests
          </button>
        </Link>
        <Link to="/BorrowedBooksList">
          <button className="bg-violet-700 text-white py-2 px-4 mb-2 rounded-lg hover:bg-violet-600 transition-all w-64">
            Borrowed Books
          </button>
        </Link>
        <Link to="/MessagePage">
          <button className="bg-violet-700 text-white py-2 px-4 rounded-lg hover:bg-violet-600 transition-all w-64">
            Messages
          </button>
        </Link>
        <button onClick={handleLogoutClick} className="bg-violet-700 text-white py-2 px-4 rounded-lg hover:bg-violet-600 transition-all w-64">
            Logout
          </button>
      </div>
    </div>
  );
}
