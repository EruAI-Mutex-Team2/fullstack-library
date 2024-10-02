import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

export default function BorrowedBooksList() {

  const [borrowedBooks, setBorrowedBooks] = useState([]);//kitapların olduğu array
  const [user, setUser] = useState({});
  const nav = useNavigate();

  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    if (user === null) {
      nav("/login");
    }
    else {
      setUser(user);
    }

    const fetchBorrowedBooks = async () => {
      const yanit = await fetch(`http://localhost:5075/api/Kitap/oduncAlinanKitaplariGetir/${user.id}`,
        {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
          },
        });

      if (yanit.ok) {
        const data = await yanit.json(); //dönen sonucu çevirip borrowedbooks içine attık
        setBorrowedBooks(data);
      }
    };

    fetchBorrowedBooks();//sayfa açılınca metodu çağırmış olduk
  }, []);


  const returnBook = async (kitapId) => {
    try {
      const yanit2 = await fetch('http://localhost:5075/api/Kitap/kitapIadeEt',
        {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(kitapId),//bodyden gönderdiğimiz için linkle göndermedik
        });

      if (!yanit2.ok) {
        alert("başarısız");
      }
      else
      {
      setBorrowedBooks(borrowedBooks.filter(book => book.id !== kitapId));
      alert("başarılı");
      }

    }
    catch (error) {                //belirli şartları sağlıyorsa dizide kalır sağlamıyorsa diziden atılır filterın kullanışı bu şekildedir.
      console.error(error);
    }
  };

  return (
    <div>
      <div className="flex justify-between items-center bg-violet-500 text-white p-4 rounded-md shadow-lg mb-6">
        <h1 className="text-3xl font-bold">Book Operations</h1>
        <div className="flex">
          <Link to="/FirstPage">
            <a href="/logout" className="hover:text-gray-300">Logout</a>
          </Link>

        </div>
      </div>


      <div className='pl-6 pr-6 pt-2'>
        <div className="flex justify-between items-center bg-violet-500 text-white p-4 rounded-md shadow-lg mb-6">
          <div className="flex">
            <input
              id="book-search"
              className="pr-10 pl-10 border text-black border-gray-300 rounded-lg shadow-sm"
              type="text"
              placeholder="Book Name..."
            />
            <button className="bg-violet-700 text-white py-2 px-4 ml-2 rounded-lg shadow-lg">
              Search
            </button>
          </div>
        </div>
      </div>


      <div className='pl-10 pr-10'>
        <div className="bg-white shadow-lg rounded-lg p-6">
          <table className="min-w-full">
            <thead>
              <tr className="bg-violet-600 text-white">
                <th className="p-6 text-left">Title</th>
                <th className="p-6 text-left">Authors</th>
                <th className="p-6 text-left">Publication Date</th>
                <th className="p-6 text-left">Actions</th>
              </tr>
            </thead>
            <tbody>
              {borrowedBooks.map((book, index) => (
                <tr key={index} className="border-b">
                  <td className="p-6">{book.kitapIsmi}</td>
                  <td className="p-6">{book.kitapYazarlari}</td>
                  <td className="p-6">{book.yayinlanmaTarihi}</td>
                  <td className="p-6">
                    <Link to={"/ReadBook?BookId="+book.id} className="bg-blue-500 text-white py-1 px-2 rounded-lg mr-2">
                      Read
                    </Link>
                    <button
                      onClick={() => returnBook(book.id)}
                      className="bg-green-500 text-white py-1 px-2 rounded-lg">
                      Return
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}
