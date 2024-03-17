import { useCart } from '../ProductComponents/CartProvider';

function CartItems() {
    const { cart, removeFromCart, addToCart, decreaseQuantity, calculateTotalPrice } = useCart();

    const handleIncreaseQuantity = (item) => {
        addToCart(item);
    };

    const handleDecreaseQuantity = (item) => {
        decreaseQuantity(item);
    };

    const calculatePriceOnQuantity = (price, quantity) => {
        return (price * quantity).toFixed(2);
    }

    return (
        <div className="container d-flex justify-content-center">
            <div className="card p-3 mt-3 mb-3 w-75 bg-dark">
                <h2 className="text-center text-light mb-3">Cart Items</h2>
                {cart.length === 0 ? (
                    <div className="alert alert-danger p-5 text-center my-5" role="alert">
                        <h4 className="alert-heading">Your cart is empty!</h4>
                        <p>Looks like you have not added any items to your cart yet.</p>
                        <hr />
                        <p className="mb-0">Click below to start shopping!</p>
                        <a href="/" className="btn btn-dark mt-3 text-decoration-none">Shop Now</a>
                    </div>
                ) : (
                    <>
                        <table className="table table-bordered table-dark">
                            <thead className="table-danger">
                                <tr>
                                    <th scope="col">Image</th>
                                    <th scope="col">Product Name</th>
                                    <th scope="col">Price</th>
                                    <th scope="col">Quantity</th>
                                    <th scope="col">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                {cart.map((item, index) => (
                                    <tr key={index} style={{ verticalAlign: 'middle' }}>
                                        <td><img src={`data:image/png;base64,${item.image}`} alt={item.productName} style={{ width: '70px', height: '70px' }} className="img-fluid rounded-2" /></td>
                                        <td>{item.productName}</td>
                                        <td><b>&#x20B9;{calculatePriceOnQuantity(item.price, item.quantity)}</b></td>
                                        <td>
                                            <button className="badge bg-danger border-0" style={{ padding: '6px', borderRadius: '50%', marginRight: '3px' }} onClick={() => handleDecreaseQuantity(item)}>
                                                <i className="bi bi-dash" style={{ fontWeight: 'bold', fontSize: '1rem', color: 'white' }}></i>
                                            </button>
                                            <span className="badge bg-dark p-2 badge mx-1" style={{ fontSize: '1.0rem', padding: '5px' }}>{item.quantity}</span>
                                            <button className="badge bg-success border-0" style={{ padding: '6px', borderRadius: '50%', marginLeft: '3px' }} onClick={() => handleIncreaseQuantity(item)}>
                                                <i className="bi bi-plus" style={{ fontSize: '1rem', color: 'white' }}></i>
                                            </button>

                                        </td>
                                        <td><button className="btn btn-outline-light btn-sm" onClick={() => removeFromCart(item)}><i className="bi bi-trash3-fill fs-5 text-danger"></i></button></td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                        <div className="row">
                            <div className="col-12 text-end text-light">
                                <div className="text-end">
                                    <b>Total Cart Value:</b><span className="h4 ms-3">&#x20B9;{calculateTotalPrice().toFixed(2)}</span>
                                </div>
                                <div className="text-end mt-3">
                                    <a href='#' className="btn btn-outline-danger shadow-lg">Checkout<i className="bi bi-chevron-right ms-1"></i></a>
                                </div>
                            </div>
                        </div>
                    </>
                )}
            </div>
        </div>
    );
}

export default CartItems;
