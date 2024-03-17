import { useCart } from '../ProductComponents/CartProvider';
import { useAuth } from '../ProtectedLoginComponent/AuthContext';

const Header = () => {
    const { cart } = useCart();
    const { isLoggedIn, logout } = useAuth();
    let handleLogout = () => {
        logout();
    }
    console.log(typeof cart);
    const productCounts = cart.reduce((counts, item) => {
        counts[item.productId] = (counts[item.productId] || 0) + 1;
        return counts;
    }, {});
    //const totalItems = cart.reduce((total, item) => total + item.quantity, 0);

    return (
        <nav className="navbar navbar-expand-lg bg-dark fixed-top" data-bs-theme="dark">
            <div className="container-fluid">
                <a className="navbar-brand fs-4 fw-bold" href="/">ShopperStop</a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarColor01">
                    <ul className="navbar-nav me-auto">
                        <li className="nav-item">
                            <a className="nav-link active" href="#">Home
                                <span className="visually-hidden">(current)</span>
                            </a>
                        </li>
                        <li style={{ marginLeft:'350px' }}>
                            <form className="d-flex">
                                <input className="form-control me-sm-2" type="search" placeholder="Search" />
                                <button className="btn btn-secondary my-2 my-sm-0" type="submit">Search</button>
                            </form>
                        </li>
                    </ul>
                    <div>
                        {isLoggedIn ? <div><button onClick={handleLogout} className="btn btn-danger">Logout</button></div> :
                            <div><a href="/login" className="btn btn-primary">Login</a></div>
                        }
                    </div>
                  
                    {isLoggedIn ?<a href="/cartItems" className="bg-dark border-0 position-relative ms-4 me-4">
                            <i className="bi bi-bag-check-fill text-light fs-2"></i>
                            <span className="position-absolute top-0 start-100 translate-middle badge rounded-5 bg-danger" style={{ fontSize: "8px", marginTop: '6px' }}>
                                <span style={{ fontSize: '12px', fontWeight: 'bolder' }}>{Object.keys(productCounts).length}</span>
                            </span>
                        </a> :
                        <a href="/cartItems" className="bg-dark border-0 position-relative ms-4 me-4">
                            <i className="bi bi-bag-x-fill text-light fs-2"></i>
                        </a> 
                    }

                </div>
            </div>
        </nav>
    );
};

export default Header;
