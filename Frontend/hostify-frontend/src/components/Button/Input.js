import React from 'react';

export const Input = ({ type, placeholder, className, ...props }) => {
  return (
    <input
      type={type}
      placeholder={placeholder}
      className={`border rounded-md py-2 px-4 w-full focus:outline-none focus:ring-2 focus:ring-primary ${className}`}
      {...props}
    />
  );
};
