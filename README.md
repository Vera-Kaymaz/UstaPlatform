# UstaPlatform - Şehrin Uzmanlık Platformu

## Proje Hakkında
Arcadia şehri için geliştirilmiş, vatandaşları uzmanlarla (tesisatçı, elektrikçi, marangoz) buluşturan akıllı bir platform. Dinamik fiyatlandırma, rota planlama ve iş takibi özelliklerine sahiptir.

## Teknolojiler
- .NET 8.0
- C#
- xUnit (Testler için)
- SOLID Prensipleri
- Plug-in Mimarisi

## Proje Yapısı
```
UstaPlatform/
├── UstaPlatform.Domain/        # Çekirdek entity sınıfları
├── UstaPlatform.Pricing/       # Fiyatlandırma sistemi ve kurallar
├── UstaPlatform.Infrastructure/# Yardımcı sınıflar ve koleksiyonlar
├── UstaPlatform.App/           # Ana uygulama ve iş akışı
└── UstaPlatform.Tests/         # Unit testler (Opsiyonel)
```

## Kurulum ve Çalıştırma

### Gereksinimler
- .NET 8.0 SDK veya üzeri
- Visual Studio 2022 veya Visual Studio Code

### Kurulum Adımları
1. Projeyi bilgisayarınıza indirin
2. `UstaPlatform.sln` dosyasını Visual Studio'da açın
3. Solution'ı build edin: `Build > Build Solution`
4. Ana proje olarak `UstaPlatform.App` seçin
5. Uygulamayı çalıştırın: `Debug > Start Without Debugging`

### Demo Çalıştırma
1. Uygulamayı çalıştırın - temel senaryo otomatik olarak çalışacaktır
2. DLL eklentisi testi için:
   - `LoyaltyDiscountRule.dll` dosyasını `UstaPlatform.App/bin/Debug/net8.0/` klasörüne kopyalayın
   - Uygulamayı yeniden çalıştırın

## Tasarım Kararları ve Mimari

### Katmanlı Mimari
Proje, SOLID prensiplerine uygun olarak 4 ana katmandan oluşur:

1. **Domain Katmanı**: Core entity'ler (Master, Citizen, Request, WorkOrder)
2. **Pricing Katmanı**: Fiyatlandırma kuralları ve motoru
3. **Infrastructure Katmanı**: Yardımcı sınıflar ve özel koleksiyonlar
4. **App Katmanı**: Ana uygulama ve iş akışı

### SOLID Prensipleri Uygulamaları

#### Açık/Kapalı Prensibi (OCP)
```csharp
public interface IPricingRule
{
    decimal Apply(decimal basePrice, WorkOrder workOrder);
}
```
Yeni fiyat kuralı eklemek için mevcut kodu değiştirmeye gerek yoktur. Sadece `IPricingRule` interface'ini implemente eden yeni bir sınıf oluşturulur.

#### Tek Sorumluluk Prensibi (SRP)
- Her sınıf tek bir sorumluluğa sahiptir
- `PricingEngine`: Sadece fiyat hesaplama
- `MatchingEngine`: Sadece usta eşleştirme
- `Schedule`: Sadece çizelge yönetimi

#### Bağımlılıkların Tersine Çevrilmesi (DIP)
```csharp
public class PricingEngine
{
    private readonly List<IPricingRule> _rules; // Somut sınıflara değil, interface'e bağımlı
}
```

### Plug-in (Eklenti) Mimarisi

#### Nasıl Çalışır?
1. **Interface Tabanlı Tasarım**: Tüm fiyat kuralları `IPricingRule` interface'ini implemente eder
2. **Runtime Assembly Loading**: Uygulama başlangıçta belirtilen klasördeki DLL'leri tarar
3. **Reflection ile Keşif**: DLL içindeki `IPricingRule` implemente eden sınıfları bulur
4. **Dinamik Yükleme**: Bulunan kuralları otomatik olarak fiyat motoruna ekler

#### Kod Örneği:
```csharp
public void LoadRulesFromAssembly(string assemblyPath)
{
    var assembly = Assembly.LoadFrom(assemblyPath);
    var ruleTypes = assembly.GetTypes()
        .Where(t => typeof(IPricingRule).IsAssignableFrom(t));
    
    foreach (var type in ruleTypes)
    {
        var rule = (IPricingRule)Activator.CreateInstance(type);
        _rules.Add(rule);
    }
}
```

#### Eklenti Geliştirme:
Yeni bir kural eklemek için:
1. Yeni Class Library projesi oluştur
2. `IPricingRule` interface'ini implemente et
3. DLL olarak derle
4. Ana uygulamanın çalışma dizinine kopyala

### İleri C# Özellikleri

#### init-only Properties
```csharp
public int Id { get; init; } // Nesne oluştuktan sonra değiştirilemez
```

#### Özel Koleksiyon - IEnumerable<T>
```csharp
public class Route : IEnumerable<(int X, int Y)>
{
    public void Add(int x, int y) // Koleksiyon başlatıcı desteği
}
```

#### Dizinleyici (Indexer)
```csharp
public List<WorkOrder> this[DateOnly date] // schedule[tarih] şeklinde erişim
```

## Temel İş Akışı
1. Vatandaş talep açar
2. Sistem uygun ustayı bulur
3. İş emri oluşturulur
4. Fiyat hesaplanır
5. İş emri ustaya atanır ve çizelgeye eklenir

## Testler
Proje xUnit testlerini içerir. Testleri çalıştırmak için:
1. Test Explorer'ı açın: `Test > Test Explorer`
2. Tüm testleri çalıştırın

## Geliştirici
- Şevval Kaymaz
