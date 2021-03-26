using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages 
    {
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };

        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UsersListed = "Kullanıcılar listelendi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomersListed = "Müşteriler listelendi";

        public static string RentalAdded = "Araba kiralandı";
        public static string RentalListed = "Kiralama listelendi";
        public static string CarUndelivered = "Araba henüz teslim edilmeemiş";

        public static string ImageLimitExpiredForCar = "Bir arabaya maximum 5 fotoğraf eklenebilir";
        public static string InvalidImageExtension = "Geçersiz dosya uzantısı, fotoğraf için kabul edilen uzantılar" + string.Join(",", ValidImageFileTypes);
        public static string CarImageMustBeExists = "Böyle bi resim bulunamadı";
        public static string CarHaveNoImage = "Arabaya ait bi resim yok";


        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string PasswordChanged = "Parola değiştirildi";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "";

        public static string CardSaved = "Kartınız kaydedildi.";
        public static string CardDeleted = "Kartınız silindi.";
    }
}
