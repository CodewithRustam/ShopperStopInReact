import { useState} from 'react';
import { useAuth } from './AuthContext';
import { Navigate } from 'react-router-dom'; // Import Redirect from react-router-dom


const LoginPage = () => {
    const [formData, setFormData] = useState({ username: '', password: '' });
    const { login, isLoggedIn } = useAuth();

    const handleSubmit = (e) => {
        e.preventDefault();
        const { username, password } = formData;
        if (username.trim() && password.trim()) {
            login(username, password); // Call the login function with username and password
        } else {
            // Handle empty username or password (e.g., display error message)
            console.error('Username and password are required.');
        }
    };

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };
    if (isLoggedIn) {
        // If user is logged in, redirect to home page
        return <Navigate to="/" />;
    }
    return (
            <div className="container d-flex justify-content-center p-5">
                <div className="card bg-dark text-light" style={{ width: '30%' }}>
                    <div className="card-body p-4">
                        <form onSubmit={handleSubmit}>
                            <fieldset>
                                <legend className="card-title h3 text-center mb-4">Login</legend>
                                <div className="mb-3">
                                    <label htmlFor="username" className="form-label">Username</label>
                                    <input
                                        type="text"
                                        id="username"
                                        name="username"
                                        className="form-control"
                                        placeholder="Enter your username"
                                        value={formData.username}
                                        onChange={handleChange}
                                    />
                                </div>
                            </fieldset>
                            <fieldset>
                                <div className="mb-3">
                                    <label htmlFor="password" className="form-label">Password</label>
                                    <input
                                        type="password"
                                        id="password"
                                        name="password"
                                        className="form-control"
                                        placeholder="Enter your password"
                                        value={formData.password}
                                        onChange={handleChange}
                                    />
                                </div>
                            </fieldset>
                            <button type="submit" className="btn btn-danger mt-3 float-end">Login</button>
                        </form>
                    </div>
                </div>
            </div>
    );
};


export default LoginPage;
