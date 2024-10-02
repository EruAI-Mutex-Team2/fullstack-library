import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";


const WritePage = () => {

    const [user,setUser]=useState({});
    
  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    if (user === null) {
      nav("/login");
    }
    else if( user.rolIsmi!=="yazar"){
       nav("/HomePage");
    }
    else{
      setUser(user);
    }

    
  },[]);

  
  const nav = useNavigate();
  const [pageContent, setPageContent] = useState("");

  const handleContentChange = (e) => { 
    setPageContent(e.target.value);
  };

  const handleSave = async () => {
    try 
    {
      const yanit = await fetch('http://localhost:5075/api/Kitap/sayfaEkle', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          kitapId: 1,
          sayfaNo: 11 + 1,  //sayfa numarasını gönderiyoruz
          icerik: pageContent,  //sayfa içeriği
        }),
      });

      if (!yanit.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      else if(yanit.ok){
      const data = await yanit.json();
      alert('Sayfa başarıyla kaydedildi!');
      }
    }
     catch (error)
    {
      console.error("Sayfa kaydedilirken bir hata oluştu", error);
    }
  };

  const saveToFile = async () => {
    try {
      // File System Access API ile dosya seçme
      const handle = await window.showSaveFilePicker({
        suggestedName: "book.txt",
        types: [
          {
            description: "Text Files",
            accept: {
              "text/plain": [".txt"],
            },
          },
        ],
      });

      // Dosya yazma işlemi
      const writableStream = await handle.createWritable();
      await writableStream.write(pageContents.join("\n\n--- Page Break ---\n\n")); // Sayfaları ayırmak için bir ayırıcı eklenebilir
      await writableStream.close();

      alert("Dosya başarıyla kaydedildi!");
    } catch (err) {
      console.error("Dosya kaydedilirken bir hata oluştu:", err);
    }
  };

  return (
  <div className="min-h-screen bg-White textblack-">
    <header className="flex items-center justify-between p-4 bg-indigo-200 text-white shadow-lg">
      <h1 className="text-3xl font-bold">Book Editor</h1>
      <div className="flex">
        <a href="/logout" className="hover:text-gray-300">Logout</a>
      </div>
    </header>

    <div className="flex flex-col items-center justify-center mt-10 w-full">
      <textarea
        onChange={handleContentChange}
        placeholder="Type the content of the page here..."
        className="w-full max-w-5xl h-64 p-4 bg-white text-black rounded-lg shadow-md focus:outline-none focus:ring-2 focus:ring-violet-700"
      ></textarea>

      <div className="w-full max-w-5xl flex justify-between items-center mt-4">
        <button
        onClick={handleSave}
          className="ml-auto px-4 py-2 bg-violet-600 text-white rounded-lg shadow hover:bg-violet-700"
        >
          Save
        </button>
      </div>

      <div className="mt-6">
        <input
          type="file"
          className="file:bg-violet-600 file:text-white file:rounded-lg file:px-4 file:py-2  file:hover:bg-violet-700 cursor-pointer"
        />
      </div>

      <div className="mt-6">
        <p className="text-lg font-semibold">Current Page: {currentPage}</p>
      </div>
    </div>
  </div>

  );
}

export default WritePage;
