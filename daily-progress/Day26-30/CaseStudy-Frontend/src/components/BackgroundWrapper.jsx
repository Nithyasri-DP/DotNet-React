import React from 'react';
import background from '../assets/bgimage.jpg';

const BackgroundWrapper = ({ children }) => {
  return (
    <div
      className="d-flex align-items-center justify-content-center vh-100"
      style={{
        backgroundImage: `url(${background})`,
        backgroundSize: 'cover',
        backgroundPosition: 'center',
      }}
    >
      <div
        className="p-4 shadow"
        style={{
          minWidth: '340px',
          maxWidth: '400px',
          width: '100%',
          backgroundColor: 'rgba(255, 255, 255, 0.6)',  
          borderRadius: '12px',
        }}
      >
        {children}
      </div>
    </div>
  );
};

export default BackgroundWrapper;
