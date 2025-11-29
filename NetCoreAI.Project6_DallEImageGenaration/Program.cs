using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

class Program
{
    public static async Task Main(string[] args)
    {
        string apiKey = "BURAYA KEY GELECEK";
        Console.Write("Görsel açıklamasını gir: ");
        string prompt = Console.ReadLine();

        using (HttpClient client = new HttpClient())
        {
            string endpoint = $"https://generativelanguage.googleapis.com/v1beta/models/imagen-3.0:generateImage?key={apiKey}";

            var requestBody = new
            {
                prompt = new { text = prompt }
            };

            string jsonBody = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(endpoint, content);
            string responseString = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject(responseString);

            Console.WriteLine("\nAPI Yanıtı:");
            Console.WriteLine(responseString);

            try
            {
                string base64Image = result.candidates[0].image.base64;
                byte[] imageBytes = Convert.FromBase64String(base64Image);
                File.WriteAllBytes("cikti.png", imageBytes);
                Console.WriteLine("\n✅ Görsel başarıyla 'cikti.png' olarak kaydedildi!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n⚠️ Görsel verisi bulunamadı veya dönüştürülürken hata oluştu:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
