using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] arg)
        {

            CarManager carManager1 = new CarManager(new EfCarDal());
            List<Car> cars = carManager1.GetAll();

            Console.WriteLine("Tüm arabaları gösterdik:\n");

            foreach (Car car in carManager1.GetAll())
            {
                Console.WriteLine(car.Description + "" + car.DailyPrice + "" + car.ModelYear);
            }
            Console.WriteLine("-----------------------------");

            Console.WriteLine("Verilen bilgilerle yeni arabamızı ekledik.\n");

            //carManager1.Add(new Car
            //{
            //    Id = 6,
            //    BrandId = 5,
            //    ColorId = 5,
            //    ModelYear = "2017",
            //    DailyPrice = 5500000,
            //    Description = "Ferrari 488 GTB Silver"
            //});

            //Id' si 5 olan arabayı sildik tablomuzdan. Bu komut bir kere çalıştığında sildiği için 2. defa denersek çalışmaz.
            //carManager1.Delete(new Car { Id = 6});

            //Id'si 3 olan arabayı güncelledik.
            carManager1.Update(new Car { Id = 3, DailyPrice = 600000, Description = "Mercedes Benz" });

            foreach (Car car in carManager1.GetAll())
            {
                Console.WriteLine(car.Description + "|" + car.DailyPrice + "|" + car.ModelYear);
            }
            Console.WriteLine("--------------------------------");
            ////Console.WriteLine("Araba Id' sine göre araba bilgilerini sildik.\n");
            ////carManager1.Delete(new Car { Id = 2 });

            //foreach (Car car in carManager1.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}
            //Console.WriteLine("---------------------------");
            Console.WriteLine("Güncellemek istediğimiz ürün bilgilerini gönderdik." +
                "Eger Id doğruysa verilen bilgilerle ilgili güncelleme yapılacak.Aksi halde yapılayacaktır.\n");
            carManager1.Update(new Car
            {
                Id = 3,
                BrandId = 4,
                ColorId = 2,
                DailyPrice = 10000,
                Description = "Tesla Model S",
                ModelYear = 2021
            });

            foreach (Car car in carManager1.GetAll())
            {
                Console.WriteLine(car.Description + "\n" + car.DailyPrice + "\n" + car.ModelYear);
            }

            CarManager carManager2 = new CarManager(new EfCarDal());

            foreach (var car in carManager2.GetCarsByBrandId(1))
            {
                Console.WriteLine("BrandId:{0} Description:{1}", car.BrandId, car.Description);
            }

            Console.WriteLine("---------------------Dto Kullandık-----------------");

            foreach (var carDetail in carManager2.GetCarDetails())
            {
                Console.WriteLine(carDetail.CarName + "/" + carDetail.BrandName + "/" + carDetail.ColorName + "/" + carDetail.DailyPrice);
            }



        }
    }
}


////SOLID
////Open Closed Principle 
////yaptığın yazılıma yeni bir özellik ekliyorsan mevcuttaki hiçbir koduna dokunamazsın (InMemoryCarDal ---> EfCarDal)
//static void Main(string[] args)
//{
//    CarTest();
//    //BrandTest();
//    //ColorTest();

//}
//private static void ColorTest()
//{
//    //ColorManager colorManager = new ColorManager(new EfColorDal());
//    //colorManager.Add(new Color { ColorId = 4, ColorName = "Blue" });//--Color Ekleme
//    //colorManager.Update(new Color { ColorId = 4, ColorName = "Gray" });//--Color Güncelleme
//    //colorManager.Delete(new Color { ColorId = 4, ColorName = "Gray" });//--Color Silme
//    //Console.WriteLine(colorManager.GetById(2).ColorName);//--istenilen id ye göre ColorName veriyor
//    //foreach (var color in colorManager.GetAll().Data)
//    //{
//    //    Console.WriteLine(color.ColorName);
//    //}
//}
//private static void BrandTest()
//{
//    BrandManager brandManager = new BrandManager(new EfBrandDal());
//    //brandManager.Add(new Brand { BrandId = 7, BrandName = "Superb" });//--Brand ekleme
//    //brandManager.Update(new Brand { BrandId = 7, BrandName = "Golf" });//--Brand Güncelleme
//    //brandManager.Delete(new Brand { BrandId = 7, BrandName = "R50" });//--Brand silme
//    Console.WriteLine(brandManager.GetById(2).Data.BrandName);//--isteilen id ye göre BrandName veriyor--Data ile verdik
//                                                              //foreach (var brand in brandManager.GetAll()) //--tümünü listeler
//                                                              //{
//                                                              //    Console.WriteLine(brand.BrandName);
//                                                              //}
//}
//private static void CarTest()
//{
//    CarManager carManager = new CarManager(new EfCarDal());
//    //Resut kısmı test etme
//    var result = carManager.GetCarDetails();
//    if (result.success)
//    {
//        foreach (var car in result.Data)
//        {
//            Console.WriteLine(car.CarName + " " + car.BrandName);
//        }

//    }
//    else
//    {
//        Console.WriteLine(result.Message);
//    }
//    //carManager.Add(new Car
//    //{
//    //    Id = 7,
//    //    BrandId = 7,
//    //    ColorId = 2,
//    //    ModelYear = 2015,
//    //    DailyPrice = 100,
//    //    Description = "Kullanımı rahat olan bir araba"
//    //});// **********Car EKLEME**********
//    //carManager.Update(new Car {Id = 7,BrandId=7,ColorId=2,CarName="Mini Cooper",
//    // ModelYear=2019,DailyPrice=95,Description="Anlatılmaz yaşanır" });    // ************Car GÜNCELLEME ************

//    // carManager.Delete(new Car {Id = 7,BrandId=7,ColorId=2,CarName="Mini Cooper",
//    // ModelYear=2019,DailyPrice=95,Description="Anlatılmaz yaşanır" });    //************* Car SİLME***************

//    // Console.WriteLine(carManager.GetById(2).CarName);// *******istenilen id ye göre CarName veriyor************

//    //Console.WriteLine("\n" + "-----Şuan Elimizde bulunan Arabalar----" + "\n");
//    //foreach (var car in carManager.GetCarDetails())
//    //{
//    //    Console.WriteLine( 

//    //        car.CarName +" "+ car.BrandName+" "+ car.ColorName+" "+" Günlük Ücreti : "+ car.DailyPrice+ " Tl"

//    //        );
//    // Console.WriteLine 

//    //(// Aşağıda sıraladıklarım GetAll() metoduna ait

//    //     "Araba id :" + car.Id + "\n" +
//    //     "Araba Marka id : " + car.BrandId + "\n" +
//    //     "Araba Renk id : " + car.ColorId + "\n" +
//    //     "Araba Model yılı :" + car.ModelYear + "\n" +
//    //     "Arabanın Günlük ücreti :  " + car.DailyPrice + "\n" +
//    //     "Araba Açıklama : " + car.Description + "\n"

//    //);
//}
//    }
//}
