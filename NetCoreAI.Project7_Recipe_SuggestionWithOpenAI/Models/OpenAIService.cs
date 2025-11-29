using System.Text;
using System.Text.Json;

namespace NetCoreAI.Project7_Recipe_SuggestionWithOpenAI.Models
{
    public class GeminiService
    {
        private readonly HttpClient _httpClient;

       
        private readonly string apiKey = "BURAYA KEY GELECEK";

        public GeminiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetRecipeAsync(string ingredients)
        {
            
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={apiKey}";

            

            var prompt = $"Sen yardımcı bir şefsin. Kullanıcı sana şu metni gönderdi: '{ingredients}'. " +
                         $"KURAL: Eğer bu metin mantıklı yemek malzemeleri içeriyorsa (örneğin domates, biber, et vb.) harika bir tarif ver. " +
                         $"ANCAK: Eğer kullanıcı alakasız bir şey sorduysa, sohbet etmeye çalışıyorsa veya anlamsız harfler girdiyse, " +
                         $"sadece şu cevabı ver: 'Ben sadece lezzetli yemek tarifleri hazırlayabilirim. Lütfen bana elinizdeki malzemeleri söyleyin.'";

           
            var requestBody = new
            {
                contents = new[]
                {
            new
            {
                parts = new[]
                {
                    new { text = prompt }
                }
            }
        }
            };

            var jsonRequest = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            // İsteği gönderiyoruz
            var response = await _httpClient.PostAsync(url, content);
            var responseBody = await response.Content.ReadAsStringAsync();

            // Hata Kontrolü
            if (!response.IsSuccessStatusCode)
            {
                return $"API HATASI! Kod: {response.StatusCode}. Mesaj: {responseBody}";
            }

            // Başarılıysa JSON'ı parse edip cevabı alıyoruz
            try
            {
                var doc = JsonDocument.Parse(responseBody);
                return doc.RootElement
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString();
            }
            catch (Exception ex)
            {
                return $"JSON OKUMA HATASI: {ex.Message}. Gelen Veri: {responseBody}";
            }
        }
    }
}