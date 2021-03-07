using Business.Concrete;
using Colorful;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using Console = Colorful.Console;

namespace ConsoleUI
{
    class Program
    {
        public static object CarManager { get; private set; }

        static void Main(string[] args)
        {
            int _secim;
            bool _loop = true;

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            do
            {
                System.Console.Clear();
                System.Console.WriteLine("<<< CAR RENTAL PROJECT >>>");
                Console.WriteLine("--------------------------");
                Console.WriteLine("[ 1 ] - Araç Ekleme");
                Console.WriteLine("[ 2 ] - Araç Listeleme - <Tamamı>");
                Console.WriteLine("[ 3 ] - Araç Listeleme - <Markasına Göre>");
                Console.WriteLine("[ 4 ] - Araç Listeleme - <Rengine Göre>");
                Console.WriteLine("[ 5 ] - Araç Güncelleme");
                Console.WriteLine("[ 6 ] - Araç Silme");
                Console.WriteLine("[ 7 ] - Marka Ekleme");
                Console.WriteLine("[ 8 ] - Marka Listeleme");
                Console.WriteLine("[ 9 ] - Renk Ekleme");
                Console.WriteLine("[ 10] - Renk Listeleme");
                Console.WriteLine("\n[ 99] - ÇIKIŞ");
                Console.WriteLine("--------------------------");

                Console.Write("\nSeciminiz: ");
                _secim = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (_secim)
                {
                    case 1:
                        ListToBrands(brandManager);
                        Console.WriteLine();
                        ListToColors(colorManager);
                        Console.WriteLine();
                        AddToCar(carManager);
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 2:
                        ListToCars(carManager);
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 3:
                        ListToBrands(brandManager);
                        ListToCarsByBrandId(carManager);
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();

                        break;
                    case 4:
                        ListToColors(colorManager);
                        ListToCarsByColorId(carManager);

                        System.Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        System.Console.ReadLine();
                        break;

                    case 5:
                        UpdateToCar(carManager);
                        System.Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        System.Console.ReadLine();
                        break;
                    case 6:
                        DeleteToCar(carManager);
                        System.Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        System.Console.ReadLine();
                        break;
                    case 7:
                        ListToBrands(brandManager);
                        AddToBrand(brandManager);
                        System.Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        System.Console.ReadLine();
                        break;
                    case 8:
                        ListToBrands(brandManager);
                        System.Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        System.Console.ReadLine();
                        break;
                    case 9:
                        ListToColors(colorManager);
                        AddToColor(colorManager);
                        System.Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        System.Console.ReadLine();
                        break;
                    case 10:
                        ListToColors(colorManager);
                        System.Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        System.Console.ReadLine();
                        break;
                    case 99:
                        _loop = false;
                        break;
                }
            } while (_loop);
        }

        private static void AddToColor(ColorManager colorManager)
        {
            string _colorName;
            System.Console.Write("\nEklemek istediğiniz yeni Renk Adı : ");
            _colorName = System.Console.ReadLine();

            Color color = new Color
            {
                ColorName = _colorName
            };

            var result = colorManager.Add(color);
            Console.WriteLine(result.Message);

        }

        private static void AddToBrand(BrandManager brandManager)
        {
            string _brandName;
            System.Console.Write("\nEklemek istediğiniz yeni Marka Adı : ");
            _brandName = System.Console.ReadLine();

            Brand brand = new Brand
            {
                BrandName = _brandName
            };

            brandManager.Add(brand);
        }

        private static void ListToCarsByColorId(CarManager carManager)
        {
            System.Console.Write("Listelemek istediğiniz Renk ID : ");
            int listColorId = Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("---------------------------------------------------------------------------------------------");
            System.Console.WriteLine(String.Format("| {0,-5}| {1,-10}| {2,-10}| {3,-10}| {4,-15}| {5,-30}|", "ID", "BRAND ID", "COLOR ID", "MODEL YEAR", "DAILY PRICE", "DESCRIPTION"));
            System.Console.WriteLine("---------------------------------------------------------------------------------------------");

            foreach (var car in carManager.GetCarsByColorId(listColorId).Data)
            {
                System.Console.WriteLine(String.Format("| {0,-5}| {1,-10}| {2,-10}| {3,-10}| {4,-15}| {5,-30}|", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));
            }
            System.Console.WriteLine("---------------------------------------------------------------------------------------------");
        }

        private static void ListToCarsByBrandId(CarManager carManager)
        {
            System.Console.Write("Listelemek istediğiniz Marka ID : ");
            int listBrandId = Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("---------------------------------------------------------------------------------------------");
            System.Console.WriteLine(String.Format("| {0,-5}| {1,-10}| {2,-10}| {3,-10}| {4,-15}| {5,-30}|", "ID", "BRAND ID", "COLOR ID", "MODEL YEAR", "DAILY PRICE", "DESCRIPTION"));
            System.Console.WriteLine("---------------------------------------------------------------------------------------------");

            foreach (var car in carManager.GetCarsByBrandId(listBrandId).Data)
            {
                System.Console.WriteLine(String.Format("| {0,-5}| {1,-10}| {2,-10}| {3,-10}| {4,-15}| {5,-30}|", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));
            }
            System.Console.WriteLine("---------------------------------------------------------------------------------------------");
        }

        private static void ListToColors(ColorManager colorManager)
        {
            var result = colorManager.GetAll();
            System.Console.WriteLine(result.Message);
            System.Console.WriteLine("-------------------------");
            System.Console.WriteLine(String.Format("| {0,-5}| {1,-15}|", "ID", "RENK"));
            System.Console.WriteLine("-------------------------");

            foreach (var colors in result.Data)
            {
                System.Console.WriteLine(String.Format("| {0,-5}| {1,-15}|", colors.Id, colors.ColorName));
            }
            System.Console.WriteLine("-------------------------");
        }

        private static void ListToBrands(BrandManager brandManager)
        {
            var result = brandManager.GetAll();
            System.Console.WriteLine(result.Message);

            System.Console.WriteLine("-------------------------");
            System.Console.WriteLine(String.Format("| {0,-5}| {1,-15}|", "ID", "MARKA"));
            System.Console.WriteLine("-------------------------");

            foreach (var brands in result.Data)
            {
                System.Console.WriteLine(String.Format("| {0,-5}| {1,-15}|", brands.BrandId, brands.BrandName));
            }
            System.Console.WriteLine("-------------------------");
        }

        private static void DeleteToCar(CarManager carManager)
        {
            ListToCars(carManager);

            int _deleteId;
            System.Console.WriteLine();

            System.Console.Write("Silmek istediğiniz Kayıt ID : ");
            _deleteId = Convert.ToInt32(System.Console.ReadLine());

            Car deleteCar = new Car { Id = _deleteId };

            carManager.Delete(deleteCar);
            System.Console.WriteLine();

            System.Console.WriteLine("<<< Listenin Son Hali >>>");
            ListToCars(carManager);
        }

        private static void AddToCar(CarManager carManager)
        {
            int _brandId, _colorId, _modelYear;
            decimal _dailyPrice;
            string _description;

            ListToCars(carManager);
            Console.WriteLine();

            Console.Write("Marka ID : ");
            _brandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Renk ID : ");
            _colorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Günlük Fiyat : ");
            _dailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Model Yılı : ");
            _modelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Açıklama : ");
            _description = Console.ReadLine();
            Console.WriteLine();


            Car car = new Car()
            {
                BrandId = _brandId,
                ColorId = _colorId,
                ModelYear = _modelYear,
                DailyPrice = _dailyPrice,
                Description = _description
            };

            //carManager.Add(car);
            var result = carManager.Add(car);
            Console.WriteLine(result.Message);

            Console.WriteLine();
            ListToCars(carManager);
        }

        private static void ListToCars(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            Console.WriteLine(result.Message);

            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-5 }| {1,-30}| {2,-20}| {3,-15}| {4,-15}|", "ID", "CAR NAME", "BRAND NAME", "CAR COLOR", "DAILY PRICE"));
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            foreach (var car in result.Data)
            {
                Console.WriteLine(String.Format("| {0,-5 }| {1,-30}| {2,-20}| {3,-15}| {4,-15}|", car.Id, car.BrandName, car.ColorName, car.DailyPrice, car.CarName));
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------");
        }

        private static void UpdateToCar(CarManager carManager)
        {
            int _updateCarId, _brandId, _colorId, _modelYear;
            decimal _dailyPrice;
            string _description;

            ListToCars(carManager);
            Console.WriteLine();

            Console.Write("Güncellemek istediğiniz Kayıt ID : ");
            _updateCarId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Marka ID : ");
            _brandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Renk ID : ");
            _colorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Günlük Fiyat : ");
            _dailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Model Yılı : ");
            _modelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Açıklama : ");
            _description = Console.ReadLine();
            Console.WriteLine();

            Car updateCar = new Car
            {
                Id = _updateCarId,
                BrandId = _brandId,
                ColorId = _colorId,
                DailyPrice = _dailyPrice,
                ModelYear = _modelYear,
                Description = _description
            };

            carManager.Update(updateCar);

            Console.WriteLine("\n<<< Listenin Son Hali >>>");
            ListToCars(carManager);
        }
    }
}