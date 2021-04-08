# ReCapProject - Araç Kirala Sistemi

Merhaba, bu proje sayın Engin Demiroğ hocamızın ücretsiz olarak sunduğu 'Yazılım Geliştirici Yetiştirme Kampı' için verilen ödevler doğrultusunda geliştirilmiştir.Projemiz genel olarak katmanlı mimariye uygun şekilde tasarlanmıştır . OOP olarak entity framework kullanılmakla birlikte IoC prensibi ve SOLID ilkelerine uygun bir şekilde geliştirilmektedir . AutoFac ve FluentValidation paketleri kullanılmaktadır .
## Kullanılan Teknolojiler & Alt Yapılar 
- C# Vers. 7.3
- Restful Web Api Vers. .Net Core 3.1
- Katmanlı Mimari
- Temel Result Türü
- Interceptor, Aspectler
- Cache, Validate, Authorize Aspect
- Autofac
- Fluent Validation
- Json Web Token
- Repository Design Pattern
- Asenkron Yapı



ReCapProject içerisinde DataAccess > Concrete > EntityFramework içerisinde bulunan ReCapContext dosyasının içerisine kullanılacak veritabanı türünün ayarları ve bağlantı cümlesi yapılmalıdır. Varsayılan ayarlar Sql Server içindir. 
![Screen Shot 8 04 2021 at 23 10](https://user-images.githubusercontent.com/63123956/114091019-cfa87a80-98c0-11eb-9027-c2c874cfeef7.png)








Token ayarları için, WebAPI > appsettings.json dosyasına token kimliği ile ilgili ayar yapılması önerilir.
![Screen Shot 8 04 2021 at 23 22](https://user-images.githubusercontent.com/63123956/114091471-6bd28180-98c1-11eb-8bcb-ffd33a2d93c7.png)
