import ICar from '../interfaces/ICar';

interface Props {
  car: ICar;
}

function CarCard({ car }: Props) {
  return (
    <div className="car-card">
      <img src={`https://localhost:7036/${car.image}`} alt="" />
      <div className="card-info">
        <h2>{car.name}</h2>
        <p>{car.brand}</p>
        <p>{car.model}</p>
        <h3>{`R$ ${car.price.toLocaleString()}`}</h3>
      </div>
    </div>
  );
}

export default CarCard;
