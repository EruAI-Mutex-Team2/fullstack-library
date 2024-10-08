import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { toast } from 'react-toastify';


const UserRequest = () => {

  const nav = useNavigate();

  const borrowRequests = [];

  const handleLogoutClick = () => {
    localStorage.removeItem("userData");
    nav("/");
};
const handleHomePageClick = () => {
    nav("/HomePage");
};

  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    if (user === null) {
      nav("/login");
    }
    else if( user.rolIsmi!=="gorevli" || user.rolIsmi !=="yonetici"){
       nav("/HomePage");
    }
    else{
      setUser(user);
    }});

  return (

    <div>
      <div className="bg-white min-h-screen">
        {/* Üst Menü (Navbar) */}
        <div className="flex justify-between items-center bg-violet-500 text-white p-4 shadow-lg">
          <h1 className="text-3xl font-bold">User Request</h1>
          <div className="flex">
            <button onClick={handleHomePageClick} className="hover:text-gray-300 p-2 ">Home Page</button>
            <button onClick={handleLogoutClick} className="hover:text-gray-300 p-2">Logout</button>
        </div>
        </div>

        {/* Search or Filter Section */}
        <div className='pl-6 pr-6 pt-2'>
          <div className="flex justify-between items-center bg-violet-500 text-white p-4 rounded-md shadow-lg mb-6">
            <div className="flex">
              <h2 className="text-2xl font-bold">Pending User Requests</h2>
            </div>
          </div>

          {/* Main Content */}
          <div className='pl-6 pr-6'>
            <div className="bg-white shadow-lg rounded-lg p-6">
              <table className="min-w-full">
                <thead>
                  <tr className="bg-violet-600 text-white">
                    <th className="p-6 text-left">Name</th>
                    <th className="p-6 text-left">Surname</th>
                    <th className="p-6 text-left">Email</th>
                    <th className="p-6 text-left">Password</th>
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
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default UserRequest;