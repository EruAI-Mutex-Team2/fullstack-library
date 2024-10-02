import React, { useState, useEffect } from 'react';
import { Navigate, useNavigate } from 'react-router-dom';

export default function Login() {
// http://localhost:5075/api/Account/girisYap
  const [email,setEmail] = useState("");
  const [password,setPassword] = useState("");
  const nav = useNavigate();

  const handleSigninClick = async (e) => {
    e.preventDefault();
    
    const data = {
      email: email,
      password: password,
    };

    const yanit = await fetch("http://localhost:5075/api/Account/girisYap",{
      method:"POST",
      headers: { "Content-Type": "application/json"},
      body: JSON.stringify(data)
    });

    if(yanit.ok)
    {
      const data = await yanit.json();
      console.log(data);
      localStorage.setItem("userData",JSON.stringify(data.userdto));
      nav("/HomePage");
    }else
    {
    }
  };
  return (
    <div className='bg-white px-10 py-20 rounded-3xl border-2 border-gray-50 max-w-lg mx-auto'>
      <h1 className='text-4xl font-bold text-center text-gray-800'>
       Login
      </h1>
      <form className='mt-8' >
        <div className='mt-4'>
          <label className='text-base font-medium'>Email</label>
          <input
            className='bg-blue-50 w-full h-12 border-2 border-gray-100 rounded-xl p-4 mt-1 '
            placeholder='Enter your email'
            name='email'
            onChange={e => setEmail(e.target.value)}
          />
        </div>

        <div className='mt-4'>
          <label className='text-base font-medium'>Password</label>
          <input
            className=' bg-blue-50 w-full h-12 border-2 border-gray-100 rounded-xl p-4 mt-1 '
            placeholder='Enter your password'
            type='password'
            name='password'
            onChange={e => setPassword(e.target.value)}
          />
        </div>

        <div className='mt-8 flex flex-col gap-y-4'>
          <button onClick={e => handleSigninClick(e)} type='submit' className='py-3 rounded-xl bg-violet-500 text-white text-lg font-bold'>
            Sign In
          </button>
        </div>

      </form>

      <div className='mt-8 flex justify-center items-center'>
        <p className='font-medium text-base'>Don't have an account?</p>
        <button className='text-violet-500 text-base font-medium ml-2'>
          Sign up
        </button>
      </div>
    </div>
  );
}
