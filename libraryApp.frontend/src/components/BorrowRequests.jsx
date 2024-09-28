import React from 'react';

export default function BorrowRequests() {
  return (
    <div className="bg-white min-h-screen">
      {/* Üst Menü (Navbar) */}
      <div className="flex justify-between items-center bg-violet-500 text-white p-4 shadow-lg">
        <h1 className="text-3xl font-bold">Borrow Request</h1>
        <div className="flex space-x-6">
          <a href="/logout" className="hover:text-white">Logout</a>
        </div>
      </div>

      <div className='pl-6 pr-6 pt-2'>
      <div className="flex justify-between items-center bg-violet-500 text-white p-4 rounded-md shadow-lg mb-6 ">
        <div className="flex">
            
        <h2 className="pr- text-2xl font-bold">Pending Borrow Requests</h2>
          <button className="bg-violet-700 text-white py-2 px-6 ml-2 rounded-lg shadow-lg">
          See pending borrow requests
          </button>

          <button className="bg-violet-700 text-white py-2 px-6 ml-2 rounded-lg shadow-lg">
          See pending member registrations
          </button>
        </div>
      </div>
      </div>

        {/* Tablo */}
        <div className="bg-white shadow-lg rounded-lg p-6">
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
              {/* Örnek Satır */}
              <tr className="border-b">
                <td className="p-6">Example Book</td>
                <td className="p-6">Ezgi</td>
                <td className="p-6">9/16/2024</td>
                <td className="p-6">9/30/2024</td>
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
              {/* Diğer Satırlar Buraya Eklenecek */}
            </tbody>
          </table>
        </div>
        </div>
  );
}
