# Hospital Management Web

ASP.NET Core ve ABP Framework ile geliştirilen, bir kliniğin hasta ve randevu süreçlerini yöneten web uygulamasıdır. Flutter mobil uygulamasıyla aynı REST API ve PostgreSQL veritabanını kullanır.

## Özellikler

- Doktor seçimi ve doktor yönetimi
- Hasta arama, ekleme, düzenleme, silme ve detay görüntüleme
- Randevu oluşturma, filtreleme, tamamlama ve iptal etme
- Doktor için tarih-saat çakışma kontrolü
- Tahlil sonucu oluşturma ve görüntüleme
- Reçete oluşturma, görüntüleme ve silme
- Muayene notu oluşturma, görüntüleme ve silme
- Hasta detayında bütün sağlık geçmişini görüntüleme
- Haftalık takvim ve gerçek verilerle özet kartları
- Mobil uyumlu mor-pembe arayüz

## Teknolojiler

- .NET 10 ve ASP.NET Core
- ABP Framework
- Entity Framework Core
- PostgreSQL
- MVC / Razor Pages
- LeptonX Lite
- Docker
- Swagger / OpenAPI

## Proje Yapısı

- `Domain`: Varlıklar ve temel iş kuralları
- `Application.Contracts`: DTO ve servis arayüzleri
- `Application`: Uygulama servisleri ve eşlemeler
- `EntityFrameworkCore`: Veritabanı yapılandırması ve migration dosyaları
- `HttpApi`: REST API katmanı
- `Web`: Razor Pages kullanıcı arayüzü
- `DbMigrator`: Veritabanı migration ve başlangıç verisi aracı

## Ana Modüller

```text
Patients          Hastalar
Doctors           Doktorlar
Appointments      Randevular
LabResults        Tahlil Sonuçları
Prescriptions     Reçeteler
ExaminationNotes  Muayene Notları
```

## Yapılandırma

PostgreSQL bağlantı bilgisini aşağıdaki klasörlerde bulunan yerel ayar dosyalarına ekleyin:

```text
src/HospitalManagement.DbMigrator/appsettings.secrets.json
src/HospitalManagement.Web/appsettings.secrets.json
```

## Çalıştırma

Önce PostgreSQL veritabanını ve gerekiyorsa migration aracını çalıştırın. Ardından web projesini başlatın:

```bash
dotnet run --project src/HospitalManagement.Web/HospitalManagement.Web.csproj
```

Projeyi yerel `5000` portunda çalıştırmak için:

```bash
dotnet run --project src/HospitalManagement.Web/HospitalManagement.Web.csproj --urls http://127.0.0.1:5000
```

Tarayıcı adresi:

```text
http://127.0.0.1:5000
```

## Kontrol

```bash
dotnet build src/HospitalManagement.Web/HospitalManagement.Web.csproj --no-restore
```

## Proje Durumu

Web ve mobil uygulamalarda demo için planlanan temel klinik yönetimi özellikleri tamamlanmıştır.
