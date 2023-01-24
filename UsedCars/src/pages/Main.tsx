import { useCallback, useEffect, useState } from 'react';
import axios from 'axios';
import CarCard from '../components/CarCard';
import ICar from '../interfaces/ICar';
import Header from '../components/Header';
import '../styles/Cards.css';

function Main() {
  const [loading, setLoading] = useState(true);
  const [cars, setCars] = useState([]);

  const getCarsFromApi = useCallback(async () => {
    const res = await axios.get('https://localhost:7036/api/Car');
    setCars(res.data.sort((a: ICar, b: ICar) => a.price - b.price));
    setLoading(false);
  }, []);

  useEffect(() => {
    getCarsFromApi();
  }, []);

  return (
    <>
      <Header />
      <div className="cards-container">
        {loading ? (
          <p>Loading...</p>
        ) : (
          cars.map((car: ICar) => {
            return <CarCard key={car.id} car={car} />;
          })
        )}
      </div>
    </>
  );
}

export default Main;
