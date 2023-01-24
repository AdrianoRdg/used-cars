import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { useState } from 'react';
import '../styles/Login.css';

function Login() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const login = async () => {
    const userInfo = {
      email,
      password,
    };

    try {
      const res = await axios.post('https://localhost:7036/api/Auth', userInfo);

      if ('token' in res.data) {
        navigate('/main');
      }
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div className="login">
      <div className="login-fields">
        <h1>Login to your account</h1>
        <form onSubmit={login} className="login-form">
          <div className="login-inputs">
            <label htmlFor="email" />
            <p>Email</p>
            <input type="text" id="email" onChange={(e) => setEmail(e.target.value)} />
            <label htmlFor="password" />
            Password
            <input
              type="text"
              id="password"
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>
          <button type="button" onClick={login}>
            Login
          </button>
        </form>
        <div className="sign-in">
          <p>You can sign up</p>
          <button type="button">Sign Up</button>
        </div>
      </div>
    </div>
  );
}

export default Login;
