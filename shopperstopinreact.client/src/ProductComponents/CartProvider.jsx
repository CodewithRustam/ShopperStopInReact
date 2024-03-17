import { createContext, useContext, useState } from 'react';
import PropTypes from 'prop-types';
import { useAuth } from '../ProtectedLoginComponent/AuthContext';

const CartContext = createContext();

export const useCart = () => useContext(CartContext);

export const CartProvider = ({ children }) => {
    const { isLoggedIn } = useAuth(); // Get the isLoggedIn state from AuthContext

    const [cart, setCart] = useState(() => {
        const storedCart = localStorage.getItem('cart');
        return storedCart ? JSON.parse(storedCart) : [];
    });

    const [isAddedToCart, setIsAddedToCart] = useState(true);

    const addToCart = (item) => {
        if (isLoggedIn) {
            const existingItemIndex = cart.findIndex((cartItem) => cartItem.productId === item.productId);

            if (existingItemIndex !== -1) {
                const updatedCart = [...cart];
                updatedCart[existingItemIndex].quantity += 1;
                setCart(updatedCart);
                localStorage.setItem('cart', JSON.stringify(updatedCart));
            } else {
                const updatedCart = [...cart, { ...item, quantity: 1 }];
                setCart(updatedCart);
                localStorage.setItem('cart', JSON.stringify(updatedCart));
            }
        } else {
            console.log("User must be logged in to add items to the cart.");
            setIsAddedToCart(false);
            console.log(isAddedToCart);
        }
    };

    const removeFromCart = (removeCartItem) => {
        const updatedCart = cart.filter((item) => item.productId !== removeCartItem.productId);
        setCart(updatedCart);
        localStorage.setItem('cart', JSON.stringify(updatedCart));
    };
    const decreaseQuantity = (decreasedItem) => {
        const updatedCart = cart.map((item) => {
            if (item.productId === decreasedItem.productId) {
                // Check if the quantity is greater than 1
                if (item.quantity > 1) {
                    return { ...item, quantity: item.quantity - 1 };
                } else {
                    // If quantity is 1 or less, remove the item from the cart
                    return null;
                }
            }
            return item;
        }).filter(Boolean); // Filter out null values (removed items)

        setCart(updatedCart);
        localStorage.setItem('cart', JSON.stringify(updatedCart));
    };
    const calculateTotalPrice = () => {
        let totalPrice = 0;
        cart.forEach((item) => {
            totalPrice += item.price * item.quantity;
        });
        return totalPrice;
    };
    return (
        <CartContext.Provider value={{ cart, addToCart, removeFromCart, decreaseQuantity, calculateTotalPrice,isAddedToCart }}>
            {children}
        </CartContext.Provider>
    );
};
CartProvider.propTypes = {
    children: PropTypes.node.isRequired
};

