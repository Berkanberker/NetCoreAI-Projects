# 🤖 NetCoreAI: .NET Core & Google Gemini Entegrasyonları

![.NET](https://img.shields.io/badge/.NET-8.0%20%2F%209.0-purple?style=flat-square&logo=dotnet)
![AI Model](https://img.shields.io/badge/AI-Google%20Gemini%20Pro-4285F4?style=flat-square&logo=google)
![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)
![Status](https://img.shields.io/badge/Status-Active-success?style=flat-square)

Bu proje, **.NET Core** mimarisi kullanılarak geliştirilmiş ve **Google Gemini API** (Generative AI) teknolojileriyle güçlendirilmiş kapsamlı bir yapay zeka entegrasyon çözümüdür.

Eski nesil modeller yerine Google'ın en güncel **Gemini 1.5 Pro ve Flash** modellerini kullanarak metin, analiz ve sohbet yeteneklerini .NET ortamına taşır.

---

## 🎯 Projenin Amacı

Bu projenin temel hedefleri şunlardır:
* **Modern Entegrasyon:** Google Gemini gibi yeni nesil LLM'lerin (Büyük Dil Modelleri) .NET ekosistemine best-practice'lere uygun entegre edilmesi.
* **Maliyet & Performans:** OpenAI alternatiflerine göre daha hızlı ve maliyet etkin (Google AI Studio) çözümler üretmek.
* **Modüler Yapı:** Chatbot, öneri sistemleri ve görsel analiz gibi farklı AI yeteneklerini birbirinden bağımsız servisler halinde sunmak.
* **Eğitim:** N-Tier (Katmanlı) mimari üzerinde yapay zeka servislerinin nasıl kurgulanacağını göstermek.

---

## 🧠 Uygulama Özellikleri

Proje aşağıdaki temel yeteneklere sahiptir:

* **💬 Çok Turlu Sohbet (Multi-Turn Chat):** Bağlamı (Context) kaybetmeden kullanıcı ile devamlılığı olan sohbetler (Gemini Pro).
* **🥗 Akıllı Öneri Motoru:** Kullanıcının elindeki verilere (örn: malzemeler) göre yaratıcı içerik ve tarif üretimi.
* **⚡ Hızlı Yanıt Sistemi:** Gemini Flash modeli ile düşük gecikmeli (low-latency) metin işleme.
* **🔌 Dinamik Prompt Yönetimi:** Kullanıcı girdilerine göre şekillenen esnek prompt şablonları.
* **🔐 Güvenli API Yönetimi:** API anahtarlarının kod içine gömülmeden, ortam değişkenleri ile yönetilmesi.

---

## 📂 Proje Modülleri ve Klasör Yapısı

Çözüm içerisindeki projeler ve kullandıkları altyapılar:

| Proje Klasörü | Modül Görevi | Kullanılan Teknoloji |
| :--- | :--- | :--- |
| **📁 Project1_ApiDemo** | `Core API` | Temel bağlantı testleri ve Gemini API yapılandırması. |
| **📁 Project2_ApiConsumeUI** | `Web UI` | AI çıktılarının son kullanıcıya gösterildiği MVC arayüzü. |
| **📁 Project3_RapidApi** | `External Data` | Harici veri kaynaklarından (RapidAPI - IMDb vb.) veri beslemesi. |
| **📁 Project4_OpenAiChat** | `AI Chatbot` | **Google Gemini** tabanlı, geçmişi hatırlayan sohbet asistanı. |
| **📁 Project5_OpenWhisper...** | `Audio` | Ses verilerinin işlenmesi ve metne dökülmesi (Speech-to-Text). |
| **📁 Project6_DallEImageGen...** | `Vision/Image` | Metinsel ifadelerden görsel üretim veya analiz senaryoları. |
| **📁 Project7_Recipe_Sugges...** | `Assistant` | **Gemini** destekli akıllı yemek tarifi ve mutfak asistanı. |

*(Not: Proje klasör isimleri geliştirme sürecinden kalma referanslar içerebilir, ancak aktif motor **Google Gemini**'dir.)*

---

## 📸 Proje Galerisi (Ekran Görüntüleri)

*(Uygulama arayüzlerinden örnek görseller)*

### 1. AI Sohbet ve Asistan Arayüzü
![Chatbot Ekranı](https://via.placeholder.com/800x400?text=Buraya+Chatbot+Resmi+Gelecek)
*(Buraya resim linkini yapıştırabilirsin)*

### 2. Yemek Tarifi ve Görsel Üretim
https://github.com/Berkanberker/NetCoreAI-Projects/issues/2
---

## 🛠 Kullanılan Teknolojiler

* **Platform:** .NET Core 8 / 9
* **Dil:** C#
* **AI Provider:** Google Generative AI SDK (Gemini API)
* **Modeller:** Gemini 1.5 Pro, Gemini 1.5 Flash
* **Mimari:** N-Tier Architecture (Service, API, UI)

---

## 🚀 Kurulum ve API Ayarları

Google Gemini API kullanmak için şu adımları izleyin:

1.  **Projeyi Klonlayın:**
    ```bash
    git clone [https://github.com/Berkanberker/NetCoreAI-Projects.git](https://github.com/Berkanberker/NetCoreAI-Projects.git)
    ```

2.  **API Anahtarı Alın:**
    [Google AI Studio](https://aistudio.google.com/) adresinden ücretsiz bir API Key oluşturun.

3.  **Yapılandırma:**
    `appsettings.json` dosyasını açın ve anahtarınızı girin:
    ```json
    "Gemini": {
      "ApiKey": "BURAYA_GOOGLE_API_KEY_GELECEK"
    }
    ```

4.  **Çalıştırın:**
    Visual Studio üzerinden projeyi başlatın (F5).

---

## 📄 Lisans

Bu proje MIT lisansı altında sunulmuştur.

---
*Geliştirici: **Berkan Berker***
