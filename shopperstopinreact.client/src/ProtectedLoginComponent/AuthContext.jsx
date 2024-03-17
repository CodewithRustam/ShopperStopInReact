import { createContext, useState, useContext } from 'react';
import PropTypes from 'prop-types';

const AuthContext = createContext();
export const useAuth = () => useContext(AuthContext);

export const AuthProvider = ({ children }) => {

    // Initialize isLoggedIn based on whether user is logged in or not from localStorage
    const [isLoggedIn, setIsLoggedIn] = useState(() => {
        const storedValue = localStorage.getItem('userLoginDetails');
        return !!storedValue; // Convert storedValue to boolean
    });

    const login = async (EmailOrMobile, Password) => {
        try {
            console.log(isLoggedIn);
            console.log(JSON.stringify({ EmailOrMobile, Password }));
            const response = await fetch('http://localhost:5223/api/User/LoginInCheck', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ EmailOrMobile, Password }),
            });

            if (response.ok) {
                const responseData = await response.json();
                localStorage.setItem('userLoginDetails', JSON.stringify(responseData));
                setIsLoggedIn(true);
            } else {
                throw new Error('Login failed');
            }
        } catch (error) {
            console.error('Login error:', error.message);
        }
    };


    const logout = () => {
        setIsLoggedIn(false);
        localStorage.removeItem('userLoginDetails'); 
    };

    return (
        <AuthContext.Provider value={{ isLoggedIn, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};
AuthProvider.propTypes = {
    children: PropTypes.node.isRequired
};