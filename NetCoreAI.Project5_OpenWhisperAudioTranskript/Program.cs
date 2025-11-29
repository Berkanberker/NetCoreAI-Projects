using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        
        string apiKey = "BURAYA KEY GELECEK";
        string modelName = "gemini-2.0-flash";
        string audioFilePath = "Sütün İçine Neden Yaprak Atılır .mp3";


        if (!File.Exists(audioFilePath))
        {
            Console.WriteLine("Ses dosyası bulunamadı.");
            return;
        }

        Console.WriteLine("Ses dosyası yükleniyor...");

        // Ses dosyasını Base64'e çevir
        var audioBytes = File.ReadAllBytes(audioFilePath);
        var audioBase64 = Convert.ToBase64String(audioBytes);

        // İstek URL'i
        string url = $"https://generativelanguage.googleapis.com/v1beta/models/{modelName}:generateContent?key={apiKey}";

        // JSON isteği hazırla
        var requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new object[]
                    {
                        new
                        {
                            inline_data = new
                            {
                                mime_type = "audio/mpeg",
                                data = audioBase64
                            }
                        },
                        new { text = "Please transcribe this audio in Turkish." }
                    }
                }
            }
        };

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        Console.WriteLine("Ses dosyası işleniyor, lütfen bekleyiniz...");

        using var httpClient = new HttpClient();
        var response = await httpClient.PostAsync(url, content);
        var responseText = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            try
            {
                var jsonDoc = JsonDocument.Parse(responseText);
                var text = jsonDoc.RootElement
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString();

                Console.WriteLine("\n--- Transkript ---");
                Console.WriteLine(text);
            }
            catch
            {
                Console.WriteLine("Cevap ayrıştırılamadı:");
                Console.WriteLine(responseText);
            }
        }
        else
        {
            Console.WriteLine($"Hata: {response.StatusCode}");
            Console.WriteLine(responseText);
        }
    }
}
