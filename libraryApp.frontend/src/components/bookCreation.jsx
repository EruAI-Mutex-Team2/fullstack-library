import React from 'react';

const App = () => {
  return (
    <div className="flex h-screen">
      {/* Sol Panel */}
      <aside className="w-1/5 bg-indigo-200 text-black p-5">
        <h1 className="text-2xl font-bold mb-10">EruLib</h1>
        <nav>
          <ul>
            <li className="mb-5">
              <button className="bg-indigo-500 w-full py-2 text-white rounded-md hover:bg-indigo-600">
                See pending book creation requests
              </button>
            </li>
          </ul>
        </nav>
      </aside>

      {/* Sağ İçerik */}
      <div className="w-4/5 bg-white text-white">
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
              {/* Satır */}
              <tr className="bg-blue-50 text-black">
                <td className="p-3">Suç ve Ceza</td>
                <td className="p-3">Dostoyevski</td>
                <td className="p-3">9/10/2024</td>
                <td className="p-3 flex space-x-2">
                  <button className="bg-green-500 hover:bg-green-600 text-black px-3 py-1 rounded">Read the book</button>
                  <button className="bg-blue-500 hover:bg-blue-600 text-black px-3 py-1 rounded">Approve</button>
                  <button className="bg-red-500 hover:bg-red-600 text-black px-3 py-1 rounded">Reject</button>
                  <button className="bg-gray-500 text-black px-3 py-1 rounded opacity-50">Details</button>
                </td>
              </tr>

              {/* Başka Satır */}
              <tr className="bg-blue-50 text-black">
                <td className="p-3">New Book</td>
                <td className="p-3">NameOfAuthor</td>
                <td className="p-3">9/16/2024</td>
                <td className="p-3 flex space-x-2">
                  <button className="bg-green-500 hover:bg-green-600 text-black px-3 py-1 rounded">Read the book</button>
                  <button className="bg-blue-500 hover:bg-blue-600 text-black px-3 py-1 rounded">Approve</button>
                  <button className="bg-red-500 hover:bg-red-600 text-black px-3 py-1 rounded">Reject</button>
                  <button className="bg-gray-500 text-black px-3 py-1 rounded opacity-50">Details</button>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

export default App;
