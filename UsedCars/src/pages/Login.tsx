import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { useState } from 'react';

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
    <div>
      <form action="">
        <label htmlFor="email">
          Email
          <input type="text" id="email" onChange={(e) => setEmail(e.target.value)} />
        </label>
        <label htmlFor="password">
          Password
          <input
            type="text"
            id="password"
            onChange={(e) => setPassword(e.target.value)}
          />
        </label>
        <button type="button" onClick={login}>
          Login
        </button>
      </form>
    </div>
  );
}

export default Login;
