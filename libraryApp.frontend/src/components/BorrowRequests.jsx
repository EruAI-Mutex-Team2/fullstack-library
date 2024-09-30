import React, { useEffect, useState } from 'react';

export default function BorrowRequests() {
  const [borrowRequests, setBorrowRequests] = useState([]); 
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchBorrowRequests = async () => {
      try {
        // Replace with your API endpoint or mock data
        const response = await fetch('https://jsonplaceholder.typicode.com/posts'); 
        if (!response.ok) {
          throw new Error('Failed to fetch borrow requests');
        }
        const data = await response.json();
        setBorrowRequests(data.slice(0, 5)); 
        setError(error.message); 
      } finally {
        setLoading(false); 
      }
    };

    fetchBorrowRequests(); 
  }, []); 

  return (
    <div className="bg-white min-h-screen">
      {/* Üst Menü (Navbar) */}
      <div className="flex justify-between items-center bg-violet-500 text-white p-4 shadow-lg">
        <h1 className="text-3xl font-bold">Borrow Request</h1>
        <div className="flex space-x-6">
          <a href="/logout" className="hover:text-white">Logout</a>
        </div>
      </div>

      {/* Search or Filter Section */}
      <div className='pl-6 pr-6 pt-2'>
        <div className="flex justify-between items-center bg-violet-500 text-white p-4 rounded-md shadow-lg mb-6">
          <div className="flex">
            <h2 className="text-2xl font-bold">Pending Borrow Requests</h2>
            <button className="bg-violet-700 text-white py-2 px-6 ml-2 rounded-lg shadow-lg">
              See pending borrow requests
            </button>
            <button className="bg-violet-700 text-white py-2 px-6 ml-2 rounded-lg shadow-lg">
              See pending member registrations
            </button>
          </div>
        </div>
      </div>

      {/* Main Content */}
      <div className='pl-6 pr-6'>
        <div className="bg-white shadow-lg rounded-lg p-6">
          {loading && <p>Loading borrow requests...</p>} {/* Display loading message */}
          {error && <p className="text-red-500">{error}</p>} {/* Display error message if fetch fails */}

          {!loading && !error && (
            <table className="min-w-full">
              <thead>
                <tr className="bg-violet-600 text-white">
                  <th className="p-6 text-left">Book</th>
                  <th className="p-6 text-left">Requestor</th>
                  <th className="p-6 text-left">Borrow Date</th>
                  <th className="p-6 text-left">Return Date</th>
                  <th className="p-6 text-left">Actions</th>
                </tr>
              </thead>
              <tbody>
                {borrowRequests.map((request, index) => (
                  <tr key={index} className="border-b">
                    <td className="p-6">{request.title}</td> {/* Replace with real book name */}
                    <td className="p-6">User {index + 1}</td> {/* Replace with real requestor */}
                    <td className="p-6">01/01/2024</td> {/* Replace with real borrow date */}
                    <td className="p-6">15/01/2024</td> {/* Replace with real return date */}
                    <td className="p-6 flex space-x-2">
                      <button className="bg-green-500 text-white py-2 px-4 rounded-lg">
                        Approve
                      </button>
                      <button className="bg-red-500 text-white py-2 px-4 rounded-lg">
                        Reject
                      </button>
                      <button className="bg-gray-500 text-white py-2 px-4 rounded-lg">
                        Details
                      </button>
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
}
