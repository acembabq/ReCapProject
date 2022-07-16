using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemoryCarDal
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        { // veriler db
            _cars = new List<Car> {
            new Car { CarID = 1, BrandID = 2, ColorID = 4, DailyPrice = 400000, ModelYear = 2016, Description = "Huawei telefon 256 gb" },
            new Car { CarID = 2, BrandID = 1, ColorID = 3, DailyPrice = 300000, ModelYear = 2012, Description = "Ford Fiesta" },
            new Car { CarID = 3, BrandID = 5, ColorID = 1, DailyPrice = 250000, ModelYear = 2008, Description = "Tofaş" },
            new Car { CarID = 4, BrandID = 5, ColorID = 2, DailyPrice = 800000, ModelYear = 2020, Description = "Mercedes" }
        };

           
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        { //linq
            Car carToDelete = null;

            carToDelete = _cars.SingleOrDefault(c => c.CarID == car.CarID);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int colorID)
        {
            return _cars.Where(c => c.ColorID == colorID).ToList();
        }

        public void Update(Car car)
        {   //linq
            Car carToUpdate = null;

            carToUpdate = _cars.SingleOrDefault(c => c.CarID == car.CarID);
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}