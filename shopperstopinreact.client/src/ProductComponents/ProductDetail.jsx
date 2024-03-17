import PropTypes from 'prop-types';
import { useParams } from 'react-router-dom';
import { useState, useEffect } from 'react'
import { useCart } from './CartProvider';
import { Navigate } from 'react-router-dom'; // Import Redirect from react-router-dom

let ProductDetail = ({ products }) => {
    const { id } = useParams();
    const { addToCart, isAddedToCart } = useCart(); 
    const [product, setProduct] = useState(null);

    useEffect(() => {
        const parsedId = parseInt(id);
        const foundProduct = products.find(product => product.productId === parsedId);
        setProduct(foundProduct);
    }, [id, products]);

    let calculateDiscount = (price, maxPrice) => {
        console.log(isAddedToCart+" product Detail");
        let discount = (maxPrice - price) / maxPrice;
        let percentDiscount = discount * 100;
        return percentDiscount.toFixed(0);
    }
    if (!isAddedToCart) {
        return <Navigate to="/login" />;
    }

        return (
            <>
                {
                    product &&
                    <div className="row mb-5 mt-3 text-light">
                        <div className="col-4">
                            <img
                                src={`data:image/png;base64,${product.image}`}
                                className="img-fluid rounded-1"
                                alt={`Product ${product.productId}`}
                                style={{ height: "500px", width: "100%" }}
                                />
                                <div className="d-flex justify-content-center mt-3" >
                                    <div><button onClick={() => addToCart(product)} className="btn btn-success fs-6 me-2">Add to Cart</button></div>
                                    <div><button className="btn btn-danger fs-6">Buy Now</button></div>
                                </div>
                        </div>
                        <div className="col-8">
                            <span className="fw-bold">{product.brand}</span><br />
                            <div style={{ fontSize: '15px', lineHeight: '16px' }}>{product.productName}</div>
                            <span className="fw-bold fs-5">&#x20B9;{product.price}</span>
                            <span style={{ fontSize: '15px' }} className="text-decoration-line-through ms-2 text-secondary">&#x20B9;{product.maxPrice}</span>
                            <span className="text-success ms-2 fw-medium">{calculateDiscount(product.price, product.maxPrice)}% off</span>
                            <h6 className="mt-5">Description: </h6>
                            <div style={{ fontSize: '15px' }}>{product.description}</div>
                            
                        </div>
                    </div>
                }
            </>
        )
    }
    ProductDetail.propTypes = {
        products: PropTypes.arrayOf(
            PropTypes.shape({
                productId: PropTypes.number.isRequired,
                image: PropTypes.string.isRequired
            })
        ).isRequired
    };
    export default ProductDetail;