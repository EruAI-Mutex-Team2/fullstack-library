import Login from "./components/Login";
import Register from "./components/Register";

function App() {
  return (
    <div className="flex w-full h-screen">
      <div className="w-full flex items-center justify-center lg:w-1/2">
   <Login />
        {/* <Register /> */}
      </div>
      <div className="hidden relative lg:flex h-full w-1/2 items-center justify-center bg-gray-200 ">
        <div className="w-60 h-60 bg-gradient-to-tr from-violet-300 to-blue-950 rounded-full animate-pulse"/>
        <div className="w-full h-1/2 absolute bottom-0 bg-white/10 backdrop-blur-lg "/>
      </div>
    </div>
  );
}

export default App;
