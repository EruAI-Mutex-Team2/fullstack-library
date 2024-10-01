import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

export default function MyBooks() {

    const [user, setUser] = useState({});
    const [books, setBooks] = useState([]);
    const nav = useNavigate();

    useEffect(() => {
        const user = JSON.parse(localStorage.getItem("userData"));
        if (user === null) {
            nav("/login");
        }
        else if (user.rolIsmi !== "yazar") {
            nav("/HomePage");
        }
        else {
            setUser(user);
            fetchBooks(user);
        }
    }, []);


    const fetchBooks = async () => {
        const yanit = await fetch("http://localhost:5075/api/Kitap/yazarinKitaplariniGetir/" + user.id, {
            method: "GET",
        });

        if (yanit.ok) {
            const data = await yanit.json();
            setBooks(data);
        }
        else {
            console.error("Kitaplar alınırken hata oluştu.");
        }
    }

    const createBook = async () => {
        const yanit2 = await fetch("http://localhost:5075/api/Kitap/kitapOlustur", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                yazarId: user.id, //yazarın id sini gönderiyoruz
            }),
        });

        if (yanit2.ok) {
            alert("Kitap başarıyla oluşturuldu!");
            fetchBooks(); // Yeni kitap oluşturulduktan sonra kitapları tekrar alıyoruz
        } else {
            console.error("Kitap oluşturulurken hata oluştu.");
        }
    }

    return (
        <div className="p-6 bg-white min-h-screen">

            <div className="flex justify-between items-center bg-violet-700 text-white p-4 rounded-md shadow-lg mb-6">
                <h1 className="text-2xl font-bold">My Books</h1>
                <div className="flex">
                    <a href="/logout" className="hover:text-gray-300">Logout</a>
                </div>
            </div>


            <div className="flex justify-end mb-4">
                <button onClick={createBook} className="bg-violet-500 text-white py-2 px-4 rounded-md shadow-lg">
                    Create a book
                </button>
            </div>


            <div className="bg-gray-100 shadow-lg rounded-lg p-6">
                <table className="min-w-full table-auto">
                    <thead>
                        <tr className="bg-violet-500 text-white">
                            <th className="p-4 text-left">BOOK NAME</th>
                            <th className="p-4 text-left">STATUS</th>
                            <th className="p-4 text-left">PUBLISH DATE</th>
                            <th className="p-4 text-left">ACTIONS</th>
                        </tr>
                    </thead>

                    <tbody>
                        {books.map((book, index) => (
                            <tr key={index} className="border-b border-gray-700">
                                <td className="p-4">{book.kitapIsmi}</td>
                                <td className="p-4">{"Eklenecek"}</td>
                                <td className="p-4">{book.yayinlanmaTarihi}</td>
                                <td className="p-4 flex space-x-2">
                                    <input
                                        type="text"
                                        placeholder="Enter new name"
                                        className="p-1 rounded-md text-black"
                                    />
                                    <Link className="bg-blue-500 text-white py-1 px-2 rounded-lg" to="/WritePage">
                                        Write
                                    </Link>
                                    <button className="bg-green-500 text-white py-1 px-2 rounded-lg">
                                        Request publishment
                                    </button>
                                    <button className="bg-gray-500 text-white py-1 px-2 rounded-lg">
                                        Read
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}