import { useNavigate } from 'react-router-dom';
import '../styles/Header.css';

function Header() {
  const navigate = useNavigate();

  return (
    <header>
      <div className="header-item">
        <h1>Verzel</h1>
      </div>
      <div className="header-item">
        <button type="button" onClick={() => navigate('/login')}>
          Login
        </button>
      </div>
    </header>
  );
}

export default Header;
