import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

const MessagePage = () => {
  const [receiver, setReceiver] = useState('');//bu constlar sabit değerlerimiz
  const [title, setTitle] = useState('');
  const [message, setMessage] = useState('');
  const [users, setUsers] = useState([]);
  const [user, setUser] = useState({});
  const nav = useNavigate();

  const fetchUsers = async (user) => {
    const yanit = await fetch("http://localhost:5075/api/User/mesajGonderilebilecekUserlarGetir/" + user.rolId,
      { method: "GET" }
    );
    if (yanit.ok) {
      const data = await yanit.json();
      setUsers(data);
    }
  }

  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    if (user === null) {
      nav("/login");
    }
    else {
      setUser(user);
    }
    fetchUsers(user);
  }, []);

  // Mesaj gönderildiğinde mesajları localStorage'a kaydet
  const handleSend = () => {
  };

  return (
    <div className="min-h-screen bg-blue-50 text-black"> {/* Arka plan rengini pembe yaptık */}
      <div className="container mx-auto p-5">
        <div className="bg-indigo-200  p-4 rounded-xl">
          <h2 className="text-xl font-bold mb-4">Message Operations</h2>
          <div className="flex mb-10">
            <div className="p-2">
              <button
                className="bg-purple-600 px-4 py-2 h-30 w-30 rounded-lg mb-4 block"
                onClick={() => setViewInbox(false)} // Mesaj gönderme alanını gösterir
              >
                Send message
              </button>
              <button
                className="bg-purple-600 px-4 py-2 h-30 w-30 rounded-lg mb-4 block"
                onClick={() => setViewInbox(true)} // Gelen kutusunu (Inbox) gösterir
              >
                View inbox
              </button>
            </div>

            <div className="w-3/4 ml-4">
              <div>
                <div className="mb-4">
                  <label>Select receiver</label>
                  <select
                    className="w-full mt-1 p-2 rounded-lg bg-blue-50"
                    value={receiver}
                    onChange={(e) => setReceiver(e.target.value)}
                  >
                    <option>Select receiver</option>
                    <option value="Beyzanur Aslan">Beyzanur Aslan</option>
                    <option value="Ezgi Yücel">Ezgi Yücel</option>
                  </select>
                </div>

                <div className="mb-4">
                  <label>Title</label>
                  <input
                    type="text"
                    className="w-full mt-1 p-2 rounded-lg bg-blue-50"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                  />
                </div>

                <div className="mb-4">
                  <label>Your message</label>
                  <textarea
                    className="w-full mt-1 p-2 rounded-lg bg-blue-50 h-24"
                    value={message}
                    onChange={(e) => setMessage(e.target.value)}
                  />
                </div>

                <button
                  onClick={handleSend}
                  className="bg-green-500 px-4 py-2 rounded-lg"
                >
                  Send
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>

    </div>
  );
};

export default MessagePage;
