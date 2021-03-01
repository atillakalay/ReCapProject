using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string RentalAdded = "Kiralama işlemi başarılı";
        public static string RentalDeleted = "Kiralama işlemi silindi";
        public static string RentalUpdated = "Kiralama işlemi güncellendi";
        public static string CheckReturnDate = "Araç geri dönüş tarihini kontrol ediniz !";
        public static string CarNameInvalid = "Araç ismi geçersiz";

        public static string CarAdded = "Araç başarıyla eklendi";
        public static string CarDeleted = "Araç silme işlemi başarılı";
        public static string CarUpdated = "Araç güncelleme işlemi başarılı";
        public static string CarList = "Araç listeleme işlemi başarılı";

        public static string BrandsListed = "Araç markaları başarıyla listelendi";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandDeleted = "Marka başarıyla silindi";
        public static string BrandUpdated = "Marka başarıyla güncellendi";


        public static string UserAdded = "Kullanıcı başarıyla Eklendi";
        public static string UserDeleted = "Kullanıcı başarıyla silindi";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi";

        public static string CategoryAdded = "Kategori başarıyla Eklendi";
        public static string CategoryDeleted = "Kategori başarıyla silindi";
        public static string CategoryUpdated = "Kategori başarıyla güncellendi";

        public static string ColorAdded = "Renk başarıyla Eklendi";
        public static string ColorDeleted = "Renk başarıyla silindi";
        public static string ColorUpdated = "Renk başarıyla güncellendi";

        public static string CustomerAdded = "Müşteri başarıyla Eklendi";
        public static string CustomerDeleted = "Müşteri başarıyla silindi";
        public static string CustomerUpdated = "Müşteri başarıyla güncellendi";

        public static string CarImageAdded = "Araç resmi başarıyla eklendi";
        public static string CarImageUpdated = "Araç resmi başarıyla güncellendi";
        public static string CarImageDeleted = "Araç resmi başarıyla silindi";

        public static string CarImageLimitExcited = "Bir aracın 5 'den fazla resmi olamaz";
        public static string CarNameAlreadyExist = "Bu isim başka bir araç mevcut";
        public static string IncorrectFileExtension = "Kabul edilmeyen dosya uzantısı";

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered;
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Erişim sağlandı";
        internal static string SuccessfullyRegister="Başarıyla oluşturuldu";
        internal static User InValidUser;
        internal static string SuccessfullyLogin="Başarıyla giriş yapıldı";
        internal static string ValidUser;
    }
}
