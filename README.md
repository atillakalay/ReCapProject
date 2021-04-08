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

###ReCapProject içerisinde Libraries > DataAccess > Concrete > EntityFramework > Contexts içerisinde bulunan ReCapContext dosyasının içerisine kullanılacak veritabanı türünün ayarları ve bağlantı cümlesi yapılmalıdır. Varsayılan ayarlar Sql Server içindir.

###Token ayarları için, Presentations > WebAPI > appsettings.json dosyasına token kimliği ile ilgili ayar yapılması önerilir.

###ReCapProject içerisinde Presentations > AngularUI > src > environments klasörü içerisinde bulunan environment.ts dosyasının içerisindeki apiUrl adlı değişkene Web API bağlantısı için gerekli ip adresi ve portu verilmelidir.
