import React, { useState, useEffect } from 'react';

const MessagePage = () => {
  const [receiver, setReceiver] = useState('');//bu constlar sabit değerlerimiz
  const [title, setTitle] = useState('');
  const [message, setMessage] = useState('');
  const [messages, setMessages] = useState([]);//bütün mesajları biz diziye atıyor
  const [viewInbox, setViewInbox] = useState(false);

  // Sayfa yüklendiğinde localStorage'dan mesajları çek
  useEffect(() => {
    const storedMessages = localStorage.getItem('messages');
    if (storedMessages) {
      setMessages(JSON.parse(storedMessages));
      /*The JSON.parse function is used to convert this JSON string back into a JavaScript object. */
    }
  }, []);

  // Mesaj gönderildiğinde mesajları localStorage'a kaydet
  const handleSend = () => {
    if (receiver && title && message) {
      const newMessages = [...messages, { receiver, title, message }];
      setMessages(newMessages);
      localStorage.setItem('messages', JSON.stringify(newMessages));//sayfa yenilensede mesajlar kalır

      // Alanları sıfırlama
      setReceiver('');
      setTitle('');
      setMessage('');
    } else {
      alert('Lütfen tüm alanları doldurun.');
    }
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
              {!viewInbox ? (
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
              ) : (
                <div>
                  <h3 className="text-lg font-bold mb-4">Inbox</h3>
                  {messages.length === 0 ? (
                    <p>No messages in your inbox.</p>
                  ) : (
                    <ul className="space-y-4">
                    {messages.map((msg, index) => (
                      <li
                        key={index}
                        className="p-4 rounded-lg bg-blue-50" // Tek renk olarak belirledik
                      >
                        <strong>To:</strong> {msg.receiver} <br />
                        <strong>Title:</strong> {msg.title} <br />
                        <strong>Message:</strong> {msg.message}
                      </li>
                    ))}
                  </ul>
                  )}
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
      
    </div>
  );
};

export default MessagePage;
