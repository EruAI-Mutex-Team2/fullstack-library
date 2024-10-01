import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

export default function BorrowedBooksList() {
  const [borrowedBooks, setBorrowedBooks] = useState([]); // State to hold borrowed books data

  useEffect(() => {
    const fetchBorrowedBooks = async () => {
      try {
        // Simulating an API call with a fetch request (Replace with real API)
        const response = await fetch('https://jsonplaceholder.typicode.com/posts'); // Mock API
        if (!response.ok) {
          throw new Error('Failed to fetch borrowed books');
        }
        const data = await response.json();
        setBorrowedBooks(data.slice(0, 5)); // Limit to 5 mock records for demo purposes
      } catch (error) {
        setError(error.message); // Handle any errors that occur during fetch
      } finally {
        setLoading(false); // End loading state
      }
    };

    fetchBorrowedBooks(); // Fetch data when component mounts
  }, []); // Empty dependency array ensures effect only runs once

  return (
    <div>
      {/* Header */}
      <div className="flex justify-between items-center bg-violet-500 text-white p-4 rounded-md shadow-lg mb-6">
        <h1 className="text-3xl font-bold">Book Operations</h1>
        <div className="flex">
        <Link to="/FirstPage">
        <a href="/logout" className="hover:text-gray-300">Logout</a>
        </Link>

        </div>
      </div>

      {/* Search Bar */}
      <div className='pl-6 pr-6 pt-2'>
        <div className="flex justify-between items-center bg-violet-500 text-white p-4 rounded-md shadow-lg mb-6">
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
              View Borrowed Books
            </button>
          </div>
        </div>
      </div>

      {/* Borrowed Books Table */}
      <div className='pl-10 pr-10'>
        <div className="bg-white shadow-lg rounded-lg p-6">
            <table className="min-w-full">
              <thead>
                <tr className="bg-violet-600 text-white">
                  <th className="p-6 text-left">Title</th>
                  <th className="p-6 text-left">Authors</th>
                  <th className="p-6 text-left">Publication Date</th>
                  <th className="p-6 text-left">Borrowed Date</th>
                  <th className="p-6 text-left">Return Date</th>
                  <th className="p-6 text-left">Actions</th>
                </tr>
              </thead>
              <tbody>
                {borrowedBooks.map((book, index) => (
                  <tr key={index} className="border-b">
                    <td className="p-6">{book.title}</td>
                    <td className="p-6">Author Name {index + 1}</td>
                    <td className="p-6">01/01/2024</td>
                    <td className="p-6">02/01/2024</td>
                    <td className="p-6">03/01/2024</td>
                    <td className="p-6">
                      <button className="bg-blue-500 text-white py-1 px-2 rounded-lg mr-2">
                        Read
                      </button>
                      <button className="bg-green-500 text-white py-1 px-2 rounded-lg">
                        Return
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
        </div>
      </div>
    </div>
  );
}
