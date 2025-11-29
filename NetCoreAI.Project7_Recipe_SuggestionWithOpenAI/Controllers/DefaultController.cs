using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project7_Recipe_SuggestionWithOpenAI.Models;

namespace NetCoreAI.Project7_Recipe_SuggestionWithOpenAI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GeminiService _geminiService;

        // Dependency Injection ile servisi alıyoruz
        public DefaultController(GeminiService geminiService)
        {
            _geminiService = geminiService;
        }

        [HttpGet]
        public IActionResult CreateRecipe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(string ingredients)
        {
            // Gemini servisinden veriyi çekiyoruz
            var result = await _geminiService.GetRecipeAsync(ingredients);

            // Gemini genelde Markdown (**kalın**, *madde*) formatında döner.
            // View tarafında düzgün görünmesi için basit bir replace yapabilir veya olduğu gibi gönderebilirsiniz.
            ViewBag.Recipe = result;

            return View();
        }
    }
}