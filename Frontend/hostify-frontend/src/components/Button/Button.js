import React from 'react';

export const Button = ({ variant = 'primary', className, children, ...props }) => {
  const baseClasses = 'py-2 px-4 rounded-md font-semibold focus:outline-none';
  const variantClasses = variant === 'outline'
    ? 'border border-gray-300 text-gray-600 bg-white hover:bg-gray-100'
    : 'text-white bg-primary hover:bg-primary-dark';

  return (
    <button
      className={`${baseClasses} ${variantClasses} ${className}`}
      {...props}
    >
      {children}
    </button>
  );
};
