using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string DailyPriceInvalid = "Araç eklenemedi. Günlük bedel 0 olamaz.";
        public static string CarDeleted = "Araç silindi";
        public static string CarUpdated = "Araç bilgisi güncellendi";
        public static string BrandAdded = "Marka bilgisi eklendi";
        public static string BrandNameInvalid = "Başarısız. Marka adı 2 harften az olamaz.";
        public static string BrandDeleted = "Marka bilgisi silindi";
        public static string BrandUpdated = "Marka bilgisi güncellendi";
        public static string ColorAdded = "Renk bilgisi eklendi";
        public static string ColorNameInvalid = "Renk bilgisi eklenemedi";
        public static string ColorDeleted = "Renk bilgisi silindi";
        public static string ColorUpdated = "Renk bilgisi güncellendi";
        public static string InfoGenerated = "İstenen bilgi oluşturuldu";
        public static string ListGenerated = "Listeleme tamamlandı";
        public static string UserDeleted = "Üye silindi";
        public static string UserUpdated = "Üye bilgisi güncellendi";
        public static string UserAdded = "Üye eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerAdded="Müşteri eklendi";
        public static string CustomerUpdated="Müşteri bilgisi güncellendi";
        public static string RentalDeleted="Kiralama bilgisi silindi";
        public static string RentalFailed="Kiralama başarısız. Araç hala kirada";
        public static string RentalSuccess="Kiralama başarılı";
        public static string RentalUpdated = "Kiralama bilgisi güncellendi";
        public static string AddImageOperationFailed="Bir araca ait en fazla 5 adet resim olabilir";
        public static string ImageAdded="Resim eklendi";
        public static string ImageUpdated="Resim güncellendi";
        public static string ImageDeleted="Resim Silindi";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kullanıcı kayıt edildi";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Şifre hatalı";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string UserAlreadyExists="Kullanıcı zaten mevcut";
        public static string AccessTokenCreated="Giriş anahtarı oluşturuldu";
    }
}
