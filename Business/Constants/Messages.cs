using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //static verdiğimizde new 'lemiyoruz.
   public static class Messages
    {
        //değişken isimlerini büyük yazdık çünkü public'ler Pascal Case yazılır.
        public static string CarAdded = "Araç Eklendi";
        public static string CarDeleted = "Araç Silindi";
        public static string CarUpdated = "Araç Güncellendi";
        public static string CarAddError = "Eklenecek Araç Sistemde Mevcut";
        public static string CarNameInvalid = "Araç İsmi Geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarListed = "Araçlar Listelendi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandListed ="Marka Listeleniyor..";
        public static string BrandAddError = "Eklenecek Model Sistemde Mevcut";

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorListed = "Renkler Listeleniyor...";
        public static string ColorAddError = "Eklenecek Renk Sistemde Mevcut";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerDeleted = "Müşteri Silindi";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserDeleted = "Kullanıcı Silindi";

        public static string RentalAdded = "Araç Kiralama Başarılı";
        public static string RentalAddError = "Araç Kiralanmıştır";
        public static string RentalUpdated = "Kiralama İşlemi Güncellendi";
        public static string RentalDeleted = "Kiralama İşlemi Kaldırıldı";
        public static string RentalReturnDate = "Araç Teslim Alındı";
        public static string RentalReturnDateError = "Araç Daha Önce Teslim Alınmış";

        public static string CarNameInvalidAndDailyPriceInvalid = "Araba ismi ve Günlük ücret geçersiz";


        public static string CarImagesLimitExceeded = "Resim limiti aşıldığı için yeni resim eklenemedi";
        public static string CarImageCarIdNotEmpty = "Resim eklenirken araç ID' si boş bırakılamaz";
        public static string CarImageAdded = "Araç resmi eklendi";
        public static string CarImageDeleted = "Araç resmi silindi";
        public static string CarImageUpdated = "Araç resmi güncellendi";

        public static string Successful { get; internal set; }
       
    }
}
