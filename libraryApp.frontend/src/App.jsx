import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'; 
import Login from './components/Login';
import Register from './components/Register';
import FirstPage from './components/FirstPage';
import MyBooks from './components/MyBooks';
import BookList from './components/BookList';
import BorrowedBooksList from './components/BorrowedBooksList';
import BorrowRequests from './components/BorrowRequests';
import MessagePage from './components/MessagePage';
import WritePage from './components/WritePage';
import HomePage from './components/HomePage';
import BorrowAndUserRequest from './components/borrowAndUserRequest';
import ChangeRole from './components/changeRolePage';


function App() {
  return (
    <Router> 
      <Routes>
        <Route path="/" element={< ChangeRole/>} />
        <Route path="/MyBooks" element={<MyBooks />} />
        <Route path="/BookList" element={<BookList />} />
        <Route path="/BorrowedBooksList" element={<BorrowedBooksList />} />
        <Route path="/BorrowRequests" element={<BorrowRequests />} />
        <Route path="/Login" element={<Login />} />
        <Route path="/MessagePage" element={<MessagePage />} />
        <Route path="/Register" element={<Register />} />
        <Route path="/WritePage" element={<WritePage />} />
        <Route path="/HomePage" element={<HomePage />} />
      </Routes>
    </Router>
  );
}

export default App;
