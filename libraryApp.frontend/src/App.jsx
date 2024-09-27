import React from 'react';
import BorrowRequestsPage from './components/borrowRequestsPage'; // BorrowRequestsPage bileşenini içe aktar

function App() {
  return (
    <div className="App">
      <BorrowRequestsPage /> {/* BorrowRequestsPage bileşenini burada render ediyoruz */}
    </div>
  );
}

export default App;
