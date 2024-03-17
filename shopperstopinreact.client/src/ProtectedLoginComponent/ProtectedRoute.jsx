import { Navigate } from 'react-router-dom';
import { useAuth } from './AuthContext'; 
import PropTypes from 'prop-types'; 

const ProtectedRoute = ({ children, requireAuth = true }) => {
    const { isLoggedIn } = useAuth();

    if (!isLoggedIn && requireAuth) {
        return <Navigate to="/login" replace />;
    }


    return children;
};

// Define propTypes
ProtectedRoute.propTypes = {
    children: PropTypes.node.isRequired, // Children prop must be provided and can be any valid React node
    requireAuth: PropTypes.bool, // Boolean indicating whether authentication is required (default: true)
};

export default ProtectedRoute;
