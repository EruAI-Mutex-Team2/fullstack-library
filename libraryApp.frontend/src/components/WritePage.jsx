import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

const WritePage = () => {
  const nav = useNavigate();

  const [pageContents, setPageContents] = useState([""]);
  const [currentPage, setCurrentPage] = useState(0);


  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    if (user === null) {
      nav("/login");
    }
    else if (user.rolIsmi !== "yonetici") {
      nav("/HomePage");
    }
    else {
      setUser(user);
    }
  }
  )

  const handleContentChange = (e) => {
    const newContents = [...pageContents];
    newContents[currentPage] = e.target.value;
    setPageContents(newContents);
  };

  const handleNextPage = () => {
    if (currentPage < pageContents.length - 1) {
      setCurrentPage(currentPage + 1);
    } else {
      setPageContents([...pageContents, ""]);
      setCurrentPage(currentPage + 1);
    }
  };

  const handlePreviousPage = () => {
    if (currentPage > 0) {
      setCurrentPage(currentPage - 1);
    }
  };

  return (
    <div className="min-h-screen bg-White textblack-">
      <header className="flex items-center justify-between p-4 bg-indigo-200 text-white shadow-lg">
        <h1 className="text-3xl font-bold">Book Editor</h1>
        <div className="flex">
          <a href="/logout" className="hover:text-gray-300">Logout</a>
        </div>
      </header>

      <div className="flex flex-col items-center justify-center mt-10 w-full">
        <textarea
          value={pageContents[currentPage] || ""}
          onChange={handleContentChange}
          placeholder="Type the content of the page here..."
          className="w-full max-w-5xl h-64 p-4 bg-white text-black rounded-lg shadow-md focus:outline-none focus:ring-2 focus:ring-violet-700"
        ></textarea>

        <div className="w-full max-w-5xl flex justify-between items-center mt-4">
          <div>
            <button
              onClick={handlePreviousPage}
              disabled={currentPage === 0}
              className="mx-2 px-4 py-2 bg-violet-600 text-white rounded-lg shadow hover:bg-violet-700 disabled:opacity-50 disabled:cursor-not-allowed"
            >
              Previous Page
            </button>

            <button
              onClick={handleNextPage}
              className="mx-2 px-4 py-2 bg-violet-600 text-white rounded-lg shadow hover:bg-violet-700"
            >
              Next Page
            </button>
          </div>

          <button
            className="ml-auto px-4 py-2 bg-violet-600 text-white rounded-lg shadow hover:bg-violet-700"
          >
            Save
          </button>
        </div>

        <div className="mt-6">
          <input
            type="file"
            className="file:bg-violet-600 file:text-white file:rounded-lg file:px-4 file:py-2  file:hover:bg-violet-700 cursor-pointer"
          />
        </div>

        <div className="mt-6">
          <p className="text-lg font-semibold">Current Page: {currentPage}</p>
        </div>
      </div>
    </div>
  )
}

export default WritePage;