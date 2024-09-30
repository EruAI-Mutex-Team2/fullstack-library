import React, { useState, useEffect } from 'react';

const ChangeRole = () => { 
  const [users, setUsers] = useState([]); // Kullanıcıları tutmak için state
  const [roles, setRoles] = useState([]); 
  const [selectedUser, setSelectedUser] = useState('');
  const [selectedRole, setSelectedRole] = useState('');
  const [isPunishmentModalOpen, setIsPunishmentModalOpen] = useState(false);
  const [punishmentType, setPunishmentType] = useState('');
  useEffect(() => {
    // Burada kullanıcıları API'den alıyormuş gibi sabit bir veri kullanıyoruz.
    const fetchUsers = async () => {
      // Bu kısımda API çağrısı yapmalısınız.
      const response = await fetch("http://localhost:5075/api/User/rolDegistirilecekUserlariGetir",{
        method: "GET",
        //yanıtı json türünden aldık

      });
      if (response.ok) {
        const dummyUsers = response.json();// jsondan objeye dönüştü
        setUsers(dummyUsers); 
      }
    
    };
    const fetchRoles = async () => {
      // Bu kısımda API çağrısı yapmalısınız.
      const response = await fetch("http://localhost:5075/api/User/rolleriGetir",{
        method: "GET",
        //yanıtı json türünden aldık

      });
      if (response.ok) {
        const dummyRoles = response.json();// jsondan objeye dönüştü
        setRoles(dummyRoles); 
      }
    
    };     

    fetchUsers();
    fetchRoles();
  }, []);

  const handleUpdate = () => {
    const updateRole = async () => {
      // Bu kısımda API çağrısı yapmalısınız.
      const response = await fetch("http://localhost:5075/api/User/roluGuncelle",{
        method: "PUT",
        headers: {"Content-Type": "application/json"},
        body: 
          JSON.stringify(
            {"userId": selectedUser,
          "yeniRolId": selectedRole,}
        ),
        
        //yanıtı json türünden aldık

      }); 
    };
    updateRole();
  };

  const handlePunishmentSubmit = () => {
    alert(`User: ${selectedUser}, Punishment: ${punishmentType} applied!`);
    setIsPunishmentModalOpen(false); // Modalı kapat
  };

  return (
    <div className="flex h-screen bg-white">
      {/* Sidebar */}
      <aside className="w-1/4 bg-indigo-200 p-4 text-black">
        <h2 className="text-xl mb-6">General Operations</h2>
        <button 
          className="w-full bg-purple-600 py-2 mb-4 rounded hover:bg-purple-700"
          onClick={() => setIsPunishmentModalOpen(true)} // Open punishment modal
        >
          Set punishment of a user
        </button>
      </aside>

      {/* Main Content */}
      <main className="w-2/4 p-8 text-black">
        <h1 className="text-2xl mb-10 mt-10">Change Role</h1>
       <div>
       <div className="mb-6">
          <label className="block mb-2">Select user</label>
          <select
            value={selectedUser}
            onChange={(e) => setSelectedUser(e.target.value)}
            className="w-full p-2 bg-blue-50 border bg-blue-50 rounded"
          >
            <option value="">Select someone</option>
            {users.map(user => (
              <option key={user.userId} value={user.userId}>{user.isim}</option>
            ))}
          </select>
        </div>

        <div>
        <select
            value={selectedRole}
            onChange={(e) => setSelectedRole(e.target.value)}
            className="w-full p-2 bg-blue-50 border bg-blue-50 rounded"
          >
            <option value="">Select role</option>
            {roles.map(role => (
              <option key={role.id} value={role.id}>{role.rolIsmi}</option>
            ))}
          </select>
        </div>
       </div>

     <div>
         <button
          className="bg-green-600 mt-5 hover:bg-green-700 text-white py-2 px-4 rounded"
          onClick={handleUpdate}
        >
          Update
        </button>
     </div>
      </main>

      {/* Top Bar */}
      <header className="absolute top-0 right-0 w-3/4 bg-indigo-200 text-white p-4 flex justify-between items-center">
        <span></span>
        <nav className="space-x-4">
          <a href="#reports" className="hover:underline">Reports</a>
          <a href="#settings" className="hover:underline">Settings</a>
          <a href="#logout" className="hover:underline">Logout</a>
        </nav>
      </header>

      {/* Punishment Modal */}
      {isPunishmentModalOpen && (
        <div className="fixed inset-0 flex items-center justify-center bg-blue-50 bg-opacity-50">
          <div className="bg-white p-6 rounded shadow-md w-1/3">
            <h2 className="text-xl mb-4">Set Punishment</h2>
            <label className="block mb-2">Select User</label>
            <select
              value={selectedUser}
              onChange={(e) => setSelectedUser(e.target.value)}
              className="w-full p-2 bg-blue-50 border rounded mb-4"
            >
              <option value="">Select user</option>
              {users.map(user => (
                <option key={user.id} value={user.id}>{user.name}</option>
              ))}
            </select>
           
            <label className="block mb-2">Select Punishment Type</label>
            <select
              value={punishmentType}
              onChange={(e) => setPunishmentType(e.target.value)}
              className="w-full p-2 bg-blue-50 border rounded mb-4"
            >
              <option value="">Select punishment</option>
              <option value="Warning">Warning</option>
              <option value="Temporary Ban">Temporary Ban</option>
              <option value="Permanent Ban">Permanent Ban</option>
            </select>

            <div className="flex justify-between">
              <button
                className="bg-red-600 hover:bg-red-700 text-white py-2 px-4 rounded"
                onClick={() => setIsPunishmentModalOpen(false)}
              >
                Cancel
              </button>
              <button
                className="bg-green-600 hover:bg-green-700 text-white py-2 px-4 rounded"
                onClick={handlePunishmentSubmit}
              >
                Apply Punishment
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default ChangeRole;
