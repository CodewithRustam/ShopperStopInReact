import { useEffect, useState } from 'react';
import ProductList from './ProductComponents/ProductList';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import ProductDetail from './ProductComponents/ProductDetail';
import CartItems from './ProductComponents/CartItems';
import LoginPage from './ProtectedLoginComponent/LoginPage';
import ProtectedRoute from './ProtectedLoginComponent/ProtectedRoute';
function App() {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        populateProductsData();
    }, []);

    async function populateProductsData() {
        const response = await fetch('http://localhost:5223/api/Product/ProductsGet');
        const data = await response.json();
        setProducts(data);
    }
    return (
        <>
            <Router>
                <Routes>
                    <Route path="/" element={<ProductList products={products} />} />
                    <Route path="/product/:id" element={<ProtectedRoute requireAuth={false }><ProductDetail products={products} /></ProtectedRoute>}/>
                    <Route path="/cartItems" element={<ProtectedRoute requireAuth={true }><CartItems /></ProtectedRoute>} />
                    <Route path="/login" element={<LoginPage />} />
                </Routes>
            </Router>            
        </>
    );
    
   
}

export default App;