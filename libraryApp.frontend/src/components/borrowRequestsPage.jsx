import React, { useState, useEffect } from 'react';

const BorrowRequestsPage = () => {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [pendingMembers, setPendingMembers] = useState([]);

  // Modal açma ve kapama fonksiyonu
  const toggleModal = () => {
    setIsModalOpen(!isModalOpen);
  };

  // API'den kayıt olmayı bekleyen kullanıcıları çekmek için bir fonksiyon
  const fetchPendingMembers = async () => {
    // Burada kendi API'n ile değiştireceğin bir fetch isteği yapabilirsin.
    const response = await fetch('https://api.example.com/pending-registrations');
    const data = await response.json();
    setPendingMembers(data);
  };

  // Modal açıldığında API çağrısı yap
  useEffect(() => {
    if (isModalOpen) {
      fetchPendingMembers();
    }
  }, [isModalOpen]);

  return (
    <div className="min-h-screen bg-white text-black">
      {/* Sidebar */}
      <div className="flex">
        <div className="bg-indigo-200 w-1/4 h-screen p-4">
          <h2 className="text-2xl font-bold mb-6">EruLib</h2>
          <div className="space-y-4">
            <button className="w-full bg-purple-500 text-white py-2 px-4 rounded-lg">
              See pending borrow requests
            </button>
            {/* Modal açmak için buton */}
            <button 
              onClick={toggleModal}
              className="w-full bg-purple-500 text-white py-2 px-4 rounded-lg"
            >
              See pending member registrations
            </button>
          </div>
        </div>

        {/* Main Content */}
        <div className="flex-3 p-6 ">
          {/* Header */}
          <div className="flex justify-between w-full mb-8 bg-indigo-200">
            <h2 className="text-xl font-bold">Member Operations</h2>
            <div className="flex space-x-4">
              <header className="flex justify-between items-center p-4 bg-indigo-200">
                <span>manager - NameOfManager Anderson</span>
                <nav className="flex space-x-4">
                  <a href="#" className="hover:underline">Reports</a>
                  <a href="#" className="hover:underline">Settings</a>
                  <a href="#" className="hover:underline">Logout</a>
                </nav>
              </header>
            </div>
          </div>

          {/* Table */}
          <div className="bg-blue-50 p-4 rounded-lg">
            <table className="w-full text-left table-auto">
              <thead>
                <tr className="text-gray-400">
                  <th className="py-2 px-4">Book</th>
                  <th className="py-2 px-4">Requestor</th>
                  <th className="py-2 px-4">Borrow Date</th>
                  <th className="py-2 px-4">Return Date</th>
                  <th className="py-2 px-4">Actions</th>
                </tr>
              </thead>
              <tbody>
                {/* Row 1 */}
                <tr>
                  <td className="py-2 px-4 text-blue-400">Suç ve Ceza</td>
                  <td className="py-2 px-4">Dostoyevski</td>
                  <td className="py-2 px-4">9/16/2024</td>
                  <td className="py-2 px-4">9/30/2024</td>
                  <td className="py-2 px-4 flex space-x-2">
                    <button className="bg-green-500 hover:bg-green-600 text-white py-1 px-2 rounded-lg">Approve</button>
                    <button className="bg-red-500 hover:bg-red-600 text-white py-1 px-2 rounded-lg">Reject</button>
                    <button className="bg-gray-500 text-white py-1 px-2 rounded-lg" disabled>Details</button>
                  </td>
                </tr>
                {/* Diğer satırlar buraya eklenebilir */}
              </tbody>
            </table>
          </div>
        </div>
      </div>

      {/* Modal */}
      {isModalOpen && (
        <div className="fixed inset-0 flex items-center justify-center bg-gray-800 bg-opacity-50">
          <div className="bg-blue-50 rounded-lg p-6 w-1/2">
            <h2 className="text-2xl font-bold mb-4">Pending Member Registrations</h2>
            <table className="w-full text-left table-auto">
              <thead>
                <tr className="bg-indigo-200 text-gray-400">
                  <th className="py-2 px-4">Name</th>
                  <th className="py-2 px-4">Email</th>
                  <th className="py-2 px-4">Actions</th>
                </tr>
              </thead>
              <tbody>
                {pendingMembers.map((member) => (
                  <tr key={member.id}>
                    <td className="py-2 px-4">{member.name}</td>
                    <td className="py-2 px-4">{member.email}</td>
                    <td className="py-2 px-4 flex space-x-2">
                      <button className="bg-green-500 hover:bg-green-600 text-white py-1 px-2 rounded-lg">Approve</button>
                      <button className="bg-red-500 hover:bg-red-600 text-white py-1 px-2 rounded-lg">Reject</button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
            <div className="mt-4">
              <button 
                onClick={toggleModal}
                className="bg-green-500 text-white py-2 px-4 rounded-lg"
              >
                Close
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default BorrowRequestsPage;
