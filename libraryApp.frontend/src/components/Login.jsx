import React, { useState, useEffect } from 'react';

export default function Login() {
  const [formData, setFormData] = useState({
    email: '',
    password: '',
  });

  const [isSubmit, setIsSubmit] = useState(false);

  useEffect(() => {
    if (isSubmit) {
      // Password confirmation check
      if (formData.password !== formData.passwordConfirm) {
        alert('Passwords do not match!');
        setIsSubmit(false);
        return;
      }
      

      setIsSubmit(false);
    }
  }, [isSubmit, formData]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value })
 
  };
  const handleSubmit = (e) => {
    e.preventDefault();
    setIsSubmit(true);
  };

  return (
    <div className='bg-white px-10 py-20 rounded-3xl border-2 border-gray-50 max-w-lg mx-auto'>
      <h1 className='text-4xl font-bold text-center text-gray-800'>
       Login
      </h1>


      <form className='mt-8' onSubmit={handleSubmit}>


        <div className='mt-4'>
          <label className='text-base font-medium'>Email</label>
          <input
            className='bg-blue-50 w-full h-12 border-2 border-gray-100 rounded-xl p-4 mt-1 '
            placeholder='Enter your email'
            name='email'
            value={formData.email}
            onChange={handleChange}
          />
        </div>

        <div className='mt-4'>
          <label className='text-base font-medium'>Password</label>
          <input
            className=' bg-blue-50 w-full h-12 border-2 border-gray-100 rounded-xl p-4 mt-1 '
            placeholder='Enter your password'
            type='password'
            name='password'
            value={formData.password}
            onChange={handleChange}
          />
        </div>

        <div className='mt-8 flex flex-col gap-y-4'>
          <button type='submit' className='py-3 rounded-xl bg-violet-500 text-white text-lg font-bold'>
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
