import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

export default function BookList() {
  const [books, setBooks] = useState([]); // State to hold books
  const [loading, setLoading] = useState(true); // Loading state
  const [error, setError] = useState(null); // Error state

  useEffect(() => {
    const fetchBooks = async () => {
      try {
        // Simulate API call
        const response = await fetch('https://jsonplaceholder.typicode.com/posts'); // Mock API
        if (!response.ok) {
          throw new Error('Failed to fetch books');
        }
        const data = await response.json();
        setBooks(data.slice(0, 5)); // Taking a few items from the mock data
      } catch (error) {
        setError(error.message);
      } finally {
        setLoading(false); // Stop loading once the fetch is done
      }
    };

    fetchBooks(); // Call the function to fetch books
  }, []); // Empty dependency array ensures the effect runs once on mount

  return (
    <div>
      <div className="flex justify-between items-center bg-violet-500 text-white p-4 rounded-md shadow-lg mb-6 ">
        <h1 className="text-3xl font-bold">Books List</h1>
        <div className="flex">
          <Link to="/FirstPage">
            <a href="/logout" className="hover:text-gray-300">Logout</a>
          </Link>
        </div>
      </div>

      <div className='pl-6 pr-6 pt-2'>
        <div className="flex justify-between items-center bg-violet-500 text-white p-4 rounded-md shadow-lg mb-6 ">
          <div className="flex">

            <input
              id="book-search"
              className="pr-10 pl-10 border text-black border-gray-300 rounded-lg shadow-sm"
              type="text"
              placeholder="Book Name..."
            />

            <button className="bg-violet-700 text-white py-2 px-4 ml-2 rounded-lg shadow-lg">
              Search
            </button>

            <button className="bg-violet-700 text-white py-2 px-4 ml-2 rounded-lg shadow-lg">
              view borrow books
            </button>
          </div>
        </div>
      </div>

      <div className='pl-10 pr-10'>
        <div className="bg-white shadow-lg rounded-lg p-6">
          <table className="min-w-full">
            <div className="pl-10 pr-10">
              <div className="bg-white shadow-lg rounded-lg p-6">
                {loading && <p>Loading books...</p>}
                {error && <p className="text-red-500">{error}</p>}
                {!loading && !error && (
                  <table className="min-w-full">
                    <thead>
                      <tr className="bg-purple-600 text-white">
                        <th className="p-6 text-left">Title</th>
                        <th className="p-6 text-left">Publication Date</th>
                        <th className="p-6 text-left">Is Borrowed</th>
                        <th className="p-6 text-left">Actions</th>
                      </tr>
                    </thead>
                    <tbody>
                      {books.map((book, index) => (
                        <tr key={index} className="border-b">
                          <td className="p-6">{book.title}</td>
                          <td className="p-6">01/01/2024</td>
                          <td className="p-6">{index % 2 === 0 ? 'Yes' : 'No'}</td>
                          <td className="p-6">
                            <button className="bg-blue-500 text-white py-1 px-2 rounded-lg mr-2">
                              Preview
                            </button>
                            <button className="bg-green-500 text-white py-1 px-2 rounded-lg">
                              Borrow
                            </button>
                          </td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                )}
              </div>
            </div>
            </table>
        </div>
      </div>
    </div>
  );
}
