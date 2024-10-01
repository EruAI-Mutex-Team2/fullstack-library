import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';


const App = () => {
  const [requests, setRequests] = useState([]); // dizi
  const nav = useNavigate();
  const [user, setUser] = useState({}); // obje


  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    if (user === null) {//kullanıcı giriş yapmamışsa login sayfası
      nav("/login");
    }
    else if (user.rolIsmi !== "yazar") {//giriş yapan yazar değilse homepage e at
      nav("/HomePage");
    }
    else {
      setUser(user);
    }
  }, []);

  useEffect(() => {
    const fetchBooks = async () => {
      const yanit = await fetch("http://localhost:5075/api/Kitap/kitapYayinlamaİstekleri", {
        method: "GET",
      });
      if (yanit.ok) {

        const data = await yanit.json();
        setRequests(data);
        console.log(data);
      } else {
      }
    };

    fetchBooks();
  }, []);

  const handlePendingBookClick = () => {
    alert('This will show pending book creation requests');
  };

  const handleLogoutClick = () => {
    navigate('/FirstPage');
  };

const createBook = async () => {
        const response = await fetch("http://localhost:5075/api/Kitap/yeniKitapOlustur", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                yazarId: user.id,        // Yazarın id'sini POST isteğine gönderiyoruz
                yayinlanmaTarihi: new Date().toISOString(), // Yayınlanma tarihini ekliyoruz
            }),
        });

        if (response.ok) {
            alert("Kitap başarıyla oluşturuldu!");
            fetchBooks(); // Yeni kitap oluşturulduktan sonra kitapları tekrar alıyoruz
        } else {
            console.error("Kitap oluşturulurken hata oluştu.");
        }
    }


  return (
    <div className="flex flex-col h-screen w-full">
      {/* Sağ İçerik */}
      <div className="flex-grow bg-white text-white flex flex-col">
        {/* Üst Menü */}
        <header className="flex justify-between items-center p-4 bg-violet-500">
          <nav className="flex w-full items-center bg-violet-500">
            <h1 className='text-2xl font-bold'>Book Create</h1>
            <button onClick={handleLogoutClick} className="ml-auto hover:underline">
              Logout
            </button>
          </nav>
        </header>
        {/* İçerik Tablosu */}
        <div className="p-5 flex-grow overflow-auto">
          <table className="w-full text-left">
            <thead>
              <tr className="bg-violet-200 text-black">
                <th className="p-3">BOOK NAME</th>
                <th className="p-3">AUTHOR</th>
                <th className="p-3">REQUEST DATE</th>
                <th className="p-3">ACTIONS</th>
              </tr>
            </thead>
            <tbody>
              {requests.map((request, index) => (
                <tr key={index} className="bg-blue-50 text-black">
                  <td className="p-3">{request.kitapIsmi}</td> 
                  <td className="p-3">{request.kitapYazarlari.join(" , ")}</td>
                  <td className="p-3">{request.talepTarihi}</td>
                  <td className="p-3 flex space-x-2">
                    <button className="bg-green-500 hover:bg-green-600 text-black px-3 py-1 rounded">Read the book</button>
                    <button className="bg-blue-500 hover:bg-blue-600 text-black px-3 py-1 rounded">Approve</button>
                    <button className="bg-red-500 hover:bg-red-600 text-black px-3 py-1 rounded">Reject</button>
                    <button className="bg-gray-500 text-black px-3 py-1 rounded opacity-50">Details</button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

export default App;
