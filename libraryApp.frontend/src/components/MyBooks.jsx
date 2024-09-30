import React from 'react';

export default function MyBooks() {
  return (
    <div className="p-6 bg-white min-h-screen">

      <div className="flex justify-between items-center bg-violet-700 text-white p-4 rounded-md shadow-lg mb-6">
        <h1 className="text-2xl font-bold">My Books</h1>
        <div className="flex">
          <a href="/logout" className="hover:text-gray-300">Logout</a>
        </div>
      </div>


      <div className="flex justify-end mb-4">
        <button className="bg-violet-500 text-white py-2 px-4 rounded-md shadow-lg">
          Create a book
        </button>
      </div>


      <div className="bg-gray-100 shadow-lg rounded-lg p-6">
        <table className="min-w-full table-auto">
          <thead>
            <tr className="bg-violet-500 text-white">
              <th className="p-4 text-left">BOOK NAME</th>
              <th className="p-4 text-left">STATUS</th>
              <th className="p-4 text-left">PUBLISH DATE</th>
              <th className="p-4 text-left">ACTIONS</th>
            </tr>
          </thead>
          <tbody>

            <tr className="border-b border-gray-700">
              <td className="p-4">New Book</td>
              <td className="p-4">Can send request</td>
              <td className="p-4">1/1/1000</td>
              <td className="p-4 flex space-x-2">
                <input
                  type="text"
                  placeholder="Enter new name"
                  className="p-1 rounded-md text-black"
                />
                <button className="bg-blue-500 text-white py-1 px-2 rounded-lg">
                  Write
                </button>
                <button className="bg-green-500 text-white py-1 px-2 rounded-lg">
                  Request publishment
                </button>
                <button className="bg-gray-500 text-white py-1 px-2 rounded-lg">
                  Read
                </button>
              </td>
            </tr>

            <tr className="border-b border-gray-700">
              <td className="p-4">qefqef</td>
              <td className="p-4">Can send request</td>
              <td className="p-4">1/1/1000</td>
              <td className="p-4 flex space-x-2">
                <input
                  type="text"
                  placeholder="Enter new name"
                  className="p-1 rounded-md text-black"
                />
                <button className="bg-blue-500 text-white py-1 px-2 rounded-lg">
                  Write
                </button>
                <button className="bg-green-500 text-white py-1 px-2 rounded-lg">
                  Request publishment
                </button>
                <button className="bg-gray-500 text-white py-1 px-2 rounded-lg">
                  Read
                </button>
              </td>
            </tr>

            <tr className="border-b border-gray-700">
              <td className="p-4">New Book</td>
              <td className="p-4">Published</td>
              <td className="p-4">9/2/2024</td>
              <td className="p-4">
                <button className="bg-gray-500 text-white py-1 px-2 rounded-lg">
                  Read
                </button>
              </td>
            </tr>
            
          </tbody>
        </table>
      </div>
    </div>
  );
}