import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

const App = () => {

  const nav = useNavigate();
  
  const [books, setBooks] = useState([]); // State to hold the list of books
  const [loading, setLoading] = useState(true); // State to manage loading state
  const [error, setError] = useState(null); // State to manage any errors


  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    if (user === null) {//kullanıcı giriş yapmamışsa login sayfası
      nav("/login");
    }
    else if( user.rolIsmi!=="yazar"){//giriş yapan yazar değilse homepage e at
       nav("/HomePage");
    }
    else{
      setUser(user);  
    }});

  useEffect(() => {
    const fetchBooks = async () => {
      try {
        const response = await fetch('https://jsonplaceholder.typicode.com/posts'); // Mock API for testing
        if (!response.ok) {
          throw new Error('Failed to fetch data from API');
        }
        const data = await response.json();
        setBooks(data.slice(0, 5)); // Mock response to show a few items
      } catch (error) {
        setError(error.message); // Log error to state
      } finally {
        setLoading(false); // Set loading to false when done
      }
    };

    fetchBooks();
  }, []); // Empty dependency array means this effect runs once on mount

  // Handler for "See pending book" button click
  const handlePendingBookClick = () => {
    alert('This will show pending book creation requests');
    // You can add navigation or different logic here as needed
  };

  return (
    <div className="flex h-screen">
      {/* Sol Panel */}
      <aside className="w-1/5 bg-indigo-200 text-black p-5">
        <h1 className="text-2xl font-bold mb-10">EruLib</h1>
        <nav>
          <ul>
            <li className="mb-5">
              <button 
                className="bg-indigo-500 w-full py-2 text-white rounded-md hover:bg-indigo-600"
                onClick={handlePendingBookClick} // Added onClick event
              >
                See pending book creation requests
              </button>
            </li>
          </ul>
        </nav>
      </aside>

      {/* Sağ İçerik */}
      <div className="w-4/5 bg-white text-black">
        {/* Üst Menü */}
        <header className="flex justify-between items-center p-4 bg-indigo-200">
          <span>manager - NameOfManager Anderson</span>
          <nav className="flex space-x-4">
            <a href="#" className="hover:underline">Reports</a>
            <a href="#" className="hover:underline">Settings</a>
            <a href="#" className="hover:underline">Logout</a>
          </nav>
        </header>

        {/* İçerik Tablosu */}
        <div className="p-5">
          {loading && <p>Loading books...</p>}
          {error && <p className="text-red-500">{error}</p>}
          {!loading && !error && (
            <table className="w-full text-left">
              <thead>
                <tr className="bg-indigo-200 text-black">
                  <th className="p-3">BOOK NAME</th>
                  <th className="p-3">AUTHOR</th>
                  <th className="p-3">REQUEST DATE</th>
                  <th className="p-3">ACTIONS</th>
                </tr>
              </thead>
              <tbody>
                {books.map((book, index) => (
                  <tr key={index} className="bg-blue-50 text-black">
                    <td className="p-3">{book.title}</td> {/* Updated to mock data */}
                    <td className="p-3">Author {index + 1}</td>
                    <td className="p-3">9/16/2024</td>
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
          )}
        </div>
      </div>
    </div>
  );
};

export default App;
