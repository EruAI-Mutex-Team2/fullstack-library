import * as React from 'react';

export default function Register() {
  return (
    <div className='bg-white px-10 py-20 rounded-3xl border-2 border-gray-50 max-w-lg mx-auto'>
    
      <h1 className='text-4xl font-bold text-center text-gray-800'>
        Create an Account
      </h1> 

      <p className='font-medium text-lg text-gray-500 mt-4 text-center'>
        Please fill in your details to create a new account.
      </p>

      <div className='mt-8' >

        <div>
          <label className='text-base font-medium'>First Name</label>
          <input
            className='w-full h-1 border-2 border-gray-100 rounded-xl p-4 mt-1 bg-transparent'
            placeholder='Enter your first name'
          />
        </div>


        <div className='mt-4'>
          <label className='text-base font-medium'>Last Name</label>
          <input
            className='w-full h-1 border-2 border-gray-100 rounded-xl p-4 mt-1 bg-transparent'
            placeholder='Enter your last name'
          />
        </div>


        <div className='mt-4'>
          <label className='text-base font-medium'>Email</label>
          <input
            className='w-full h-1 border-2 border-gray-100 rounded-xl p-4 mt-1 bg-transparent'
            placeholder='Enter your email'
          />
        </div>



        <div className='mt-4'>
          <label className='text-base font-medium'>Password</label>
          <input
            className='w-full h-1 border-2 border-gray-100 rounded-xl p-4 mt-1 bg-transparent'
            placeholder='Enter your password'
            type='password'
          />
        </div>


        <div className='mt-4'>
          <label className='text-base font-medium'>Password Confirm</label>
          <input
            className='w-full h-1 border-2 border-gray-100 rounded-xl p-4 mt-1 bg-transparent'
            placeholder='Enter your password'
            type='password'
          />
        </div>


        <div className='mt-8 flex flex-col gap-y-4'>
          <button className='py-3 rounded-xl bg-violet-500 text-white text-lg font-bold'>
            Sign up
          </button>
        </div>



        <div className='mt-8 flex justify-center items-center'>
          <p className='font-medium text-base'>Already have an account?</p>
          <button className='text-violet-500 text-base font-medium ml-2'>
            Sign in
          </button>
        </div>
      </div>
    </div> 
  );
}
