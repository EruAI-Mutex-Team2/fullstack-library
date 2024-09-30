import * as React from 'react';
import { Link } from 'react-router-dom';

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
    <div className="flex w-full h-screen">


      <div className="w-full lg:w-1/2 flex items-center justify-center">
        <div className='bg-white px-10 py-20 rounded-3xl border-2 border-gray-50 max-w-lg mx-auto'>
          <h1 className='mt-3 text-4xl font-bold text-center text-gray-800'>
            Create an Account
          </h1> 

          <p className='font-medium text-lg text-gray-500 mt-4 text-center'>
            Please fill in your details to create a new account.
          </p>

          <div className='mt-8'>
            <div>
              <label className='text-base font-medium'>First Name</label>
              <input
                className='w-full h-12 border border-gray-300 rounded-xl p-4 mt-1 bg-transparent'
                placeholder='Enter your first name'
              />
            </div>

            <div className='mt-4'>
              <label className='text-base font-medium'>Last Name</label>
              <input
                className='w-full h-12 border border-gray-300 rounded-xl p-4 mt-1 bg-transparent'
                placeholder='Enter your last name'
              />
            </div>

            <div className='mt-4'>
              <label className='text-base font-medium'>Email</label>
              <input
                className='w-full h-12 border border-gray-300 rounded-xl p-4 mt-1 bg-transparent'
                placeholder='Enter your email'
              />
            </div>

            <div className='mt-4'>
              <label className='text-base font-medium'>Password</label>
              <input
                className='w-full h-12 border border-gray-300 rounded-xl p-4 mt-1 bg-transparent'
                placeholder='Enter your password'
                type='password'
              />
            </div>

            <div className='mt-4'>
              <label className='text-base font-medium'>Password Confirm</label>
              <input
                className='w-full h-12 border border-gray-300 rounded-xl p-4 mt-1 bg-transparent'
                placeholder='Confirm your password'
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
              <Link to="/Login">
              <button className='text-violet-500 text-base font-medium ml-2'>
                Sign in
              </button>
              </Link>
            </div>
          </div>
        </div>
      </div>

      
      <div className="hidden lg:flex w-1/2 items-center justify-center relative bg-gray-200">
        <div className="w-60 h-60 bg-gradient-to-tr from-violet-300 to-blue-950 rounded-full animate-pulse" />
        <div className="w-full h-1/2 absolute bottom-0 bg-white/10 backdrop-blur-lg" />
      </div>
    </div>
  );
}
