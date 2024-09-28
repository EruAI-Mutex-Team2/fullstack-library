import React, { useState, useEffect } from 'react';

export default function Register() {
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    passwordConfirm: ''
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
      
      // Form submission logic (simulating an API call)
      console.log('Form submitted:', formData);


      setIsSubmit(false);
    }
  }, [isSubmit, formData]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setIsSubmit(true);
  };

  return (
    <div className='bg-white px-10 py-20 rounded-3xl border-2 border-gray-50 max-w-lg mx-auto'>
      <h1 className='text-4xl font-bold text-center text-gray-800'>
        Create an Account
      </h1>

      <form className='mt-8' onSubmit={handleSubmit}>

        <div>
          <label className='text-base font-medium'>First Name</label>
          <input
            className='w-full h-12 border-2 border-gray-100 rounded-xl p-4 mt-1 bg-blue-50'
            placeholder='Enter your first name'
            name='firstName'
            value={formData.firstName}
            onChange={handleChange}
          />
        </div>

        <div className='mt-4'>
          <label className='text-base font-medium'>Last Name</label>
          <input
            className='w-full h-12 border-2 border-gray-100 rounded-xl p-4 mt-1 bg-blue-50'
            placeholder='Enter your last name'
            name='lastName'
            value={formData.lastName}
            onChange={handleChange}
          />
        </div>

        <div className='mt-4'>
          <label className='text-base font-medium'>Email</label>
          <input
            className='w-full h-12 border-2 border-gray-100 rounded-xl p-4 mt-1 bg-blue-50'
            placeholder='Enter your email'
            name='email'
            value={formData.email}
            onChange={handleChange}
          />
        </div>

        <div className='mt-4'>
          <label className='text-base font-medium'>Password</label>
          <input
            className='w-full h-12 border-2 border-gray-100 rounded-xl p-4 mt-1 bg-blue-50'
            placeholder='Enter your password'
            type='password'
            name='password'
            value={formData.password}
            onChange={handleChange}
          />
        </div>

        <div className='mt-4'>
          <label className='text-base font-medium'>Password Confirm</label>
          <input
            className='w-full h-12 border-2 border-gray-100 rounded-xl p-4 mt-1 bg-blue-50'
            placeholder='Confirm your password'
            type='password'
            name='passwordConfirm'
            value={formData.passwordConfirm}
            onChange={handleChange}
          />
        </div>

        <div className='mt-8 flex flex-col gap-y-4'>
          <button type='submit' className='py-3 rounded-xl bg-violet-500 text-white text-lg font-bold'>
            Sign up
          </button>
        </div>

      </form>

      <div className='mt-8 flex justify-center items-center'>
        <p className='font-medium text-base'>Already have an account?</p>
        <button className='text-violet-500 text-base font-medium ml-2'>
          Sign in
        </button>
      </div>
    </div>
  );
}
