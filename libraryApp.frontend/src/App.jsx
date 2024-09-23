import React from 'react';
import MessagePage from './components/messagePage';
import BorrowRequests from './components/BorrowRequest';
import BorrowedBooksList from './components/BorrowedBooks';
import Login from './components/Login';
import Register from './components/Register';
import BookList from './components/BookList';
import BookEditor from './components/WritePage';


function App() {
  return (
    <div>
      <BookEditor/>
    </div>
  );
}

export default App;
