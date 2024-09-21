import React, { useState, useEffect } from 'react';

const MessagePage = () => {
  const [receiver, setReceiver] = useState('');//string olcak demek
  const [title, setTitle] = useState('');
  const [message, setMessage] = useState('');
  const [messages, setMessages] = useState([]);//dizi olcak demek
  const [viewInbox, setViewInbox] = useState(false);//boolean ifade olcak

  // Sayfa yüklendiğinde localStorage'dan mesajları çek
  useEffect(() => {
    const storedMessages = localStorage.getItem('messages');
    if (storedMessages) {
      setMessages(JSON.parse(storedMessages)); // localStorage'dan alınan veriler JSON olarak parse edilir
    }
  }, []);

  // Mesaj gönderildiğinde mesajları localStorage'a kaydet
  const handleSend = () => {
    if (receiver && title && message) {
      const newMessages = [...messages, { receiver, title, message }];
      setMessages(newMessages);
      localStorage.setItem('messages', JSON.stringify(newMessages)); // Mesajları JSON formatında kaydeder

      // Alanları sıfırlama
      setReceiver('');
      setTitle('');
      setMessage('');
    } else {
      alert('Lütfen tüm alanları doldurun.');
    }
  };

  return (
    <div className="min-h-screen bg-gray-900 text-white">
      <div className="container mx-auto p-8">
        <div className="bg-gray-800 p-4 rounded-lg">
          <h2 className="text-xl font-bold mb-4">Message Operations</h2>
          
          <div className="flex mb-4 ">
            <div className=" p-2  ">
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
              {!viewInbox ? (//bu satır ile
                <div>
                  <div className="mb-4">
                    <label>Select receiver</label>
                    <select 
                      className="w-full mt-1 p-2 rounded-lg bg-gray-700"
                      value={receiver}
                      onChange={(e) => setReceiver(e.target.value)}
                    >
                      <option value="">Select receiver</option>
                      <option value="Beyzanur Aslan">Beyzanur Aslan</option>
                      <option value="Ezgi Yücel">Ezgi Yücel</option>
                    </select>
                  </div>

                  <div className="mb-4">
                    <label>Title</label>
                    <input
                      type="text"
                      className="w-full mt-1 p-2 rounded-lg bg-gray-700"
                      value={title}
                      onChange={(e) => setTitle(e.target.value)}
                    />
                  </div>

                  <div className="mb-4">
                    <label>Your message</label>
                    <textarea
                      className="w-full mt-1 p-2 rounded-lg bg-gray-700 h-24"
                      value={message}
                      onChange={(e) => setMessage(e.target.value)}
                    />
                  </div>

                  <button
                    onClick={handleSend}
                    className="bg-green-600 px-4 py-2 rounded-lg"
                  >
                    Send
                  </button>
                </div>// 57-97. satırlar arası select receiverden send butonuna kadar olan ksımın kodu
              ) : (
                <div>
                  <h3 className="text-lg font-bold mb-4">Inbox</h3>
                  {messages.length === 0 ? (
                    <p>No messages in your inbox.</p>
                  ) : (
                    <ul className="space-y-4">
                      {messages.map((msg, index) => (
                        <li key={index} className="p-4 bg-gray-700 rounded-lg">
                          <strong>To:</strong> {msg.receiver} <br />
                          <strong>Title:</strong> {msg.title} <br />
                          <strong>Message:</strong> {msg.message}
                        </li>
                      ))}
                    </ul>
                  )}
                </div>
              )
              }
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default MessagePage;
