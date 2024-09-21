import React from 'react';
export default function BookList() {
  return (
<div>
      <div className="flex justify-between items-center bg-purple-500 text-white p-4 rounded-md shadow-lg mb-6 ">
        <h1 className="text-3xl font-bold">Books List</h1>
        <div className="flex">
        <a href="/logout" className="hover:text-gray-300">Logout</a>

        </div>
      </div>
      
       <div className='pl-6 pr-6 pt-2'>
      <div className="flex justify-between items-center bg-purple-500 text-white p-4 rounded-md shadow-lg mb-6 ">
        <div className="flex">

          <input
            id="book-search"
            className="pr-10 pl-10 border text-black border-gray-300 rounded-lg shadow-sm"
            type="text"
            placeholder="Book Name..."
          />

          <button className="bg-purple-700 text-white py-2 px-4 ml-2 rounded-lg shadow-lg">
            Search
          </button>

          <button className="bg-purple-700 text-white py-2 px-4 ml-2 rounded-lg shadow-lg">
            view borrow books
          </button>
        </div>
      </div>
      </div>
    
      <div className='pl-10 pr-10'>
      <div className="bg-white shadow-lg rounded-lg p-6">
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


            <tr className="border-b">
            <td className="p-6">Example Book</td>
              <td className="p-6">01/01/2024</td>
              <td className="p-6">Yes</td>
              <td className="p-6">
              <button className="bg-blue-500 text-white py-1 px-2 rounded-lg mr-2">
                Preview
                </button>
                <button className="bg-green-500 text-white py-1 px-2 rounded-lg">
                  Borrow
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      </div>
    </div>
  );
}