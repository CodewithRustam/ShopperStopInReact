import Header from './Header';
import PropTypes from 'prop-types';
import Footer from './Footer';
import { AuthProvider } from '../ProtectedLoginComponent/AuthContext';
import { CartProvider } from '../ProductComponents/CartProvider';

const Layout = ({ children }) => {

    return (
        <div>
            <AuthProvider>
                <CartProvider>
                   <Header />
                   <div className="container">
                     {children}
                   </div>
                   < Footer />
                </CartProvider>
             </AuthProvider>

          </div>

    );
};
Layout.propTypes = {
    children: PropTypes.node.isRequired
};

export default Layout;
