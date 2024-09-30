import React from "react";

export default function FirstPage() {
  return (
    <div
      className="h-screen flex flex-col items-start justify-center pl-10"
      style={{
        background: "linear-gradient(135deg, #4B0082, #7A1B9A)", 
      }}
    >
      

      <div className="absolute top-10 right-10">
          <button className="bg-white text-violet-700 py-2 px-4 mr-4 rounded-lg hover:bg-gray-200 transition-all">
            Sign in
          </button>

          <button className="bg-white text-violet-700 py-2 px-4 rounded-lg hover:bg-gray-200 transition-all">
            Sign up
          </button>
      </div>



      <div className="text-left text-white">
        <h1 className="text-6xl font-bold mb-4" style={{ fontFamily: "cursive" }}>
          Welcome To Library...
        </h1>
        <p className="text-2xl font-light mb-6">
        Welcome! Your book reading journey is starting, start now!
        </p>
      </div>
    </div>
  );
}
