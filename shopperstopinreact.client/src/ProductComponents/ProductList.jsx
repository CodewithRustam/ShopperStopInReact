import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import { useAuth } from '../ProtectedLoginComponent/AuthContext';
import { ToastContainer, toast } from 'react-toastify';
import { useEffect } from 'react';


const ProductList = ({ products }) => {
    const {isLoggedIn } = useAuth();

    let calculateDiscount = (price, maxPrice) => {
        let discount = (maxPrice - price) / maxPrice;
        let percentDiscount = discount * 100;
        return percentDiscount.toFixed(0);
    }
    useEffect(() => {
        if (isLoggedIn) {
            toast.success('Login Successful !!', {
                autoClose: 2000
            });
        }
    }, [isLoggedIn]);

    return (
        <>
            <div>
            <ToastContainer position="top-right" />
                <div className="row" >
                    {products.map((product) => (
                        <div key={product.productId} className="col-lg-3 col-md-4 col-sm-6 mb-3">
                            <div className="card border border-0">
                                <Link to={`/product/${product.productId}`}>
                                    <img
                                        src={`data:image/png;base64,${product.image}`}
                                        className="card-img-top img-fluid shadow-lg"
                                        alt={`Product ${product.productId}`}
                                        style={{ height: "350px", width: "100%" }}
                                    />
                                </Link>
                                <div className="card-footer bg-dark text-white" style={{ height: "100px" }}>
                                    <span className="fw-bold">{product.brand}</span><br />
                                    <div style={{ fontSize: '15px', lineHeight: '15px' }}>{product.productName.slice(0, 65)}</div>
                                    <span className="fw-bold fs-5">&#x20B9;{product.price}</span>
                                    <span style={{ fontSize: '15px' }} className="text-decoration-line-through ms-2 text-secondary">&#x20B9;{product.maxPrice}</span>
                                    <span className="text-success ms-2 fw-medium">{calculateDiscount(product.price, product.maxPrice)}% off</span>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
            
        </>
    );
};

ProductList.propTypes = {
    products: PropTypes.arrayOf(
        PropTypes.shape({
            productId: PropTypes.number.isRequired,
            image: PropTypes.string.isRequired
        })
    ).isRequired
};

export default ProductList;
