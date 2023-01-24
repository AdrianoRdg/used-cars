import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import Login from './pages/Login';
import Main from './pages/Main';

function App() {
  const router = createBrowserRouter([
    {
      path: '/',
      element: <Main />,
    },
    {
      path: '/login',
      element: <Login />,
    },
  ]);

  return <RouterProvider router={router} />;
}

export default App;
