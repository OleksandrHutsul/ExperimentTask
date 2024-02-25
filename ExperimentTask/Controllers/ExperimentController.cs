using ExperimentTask.Interfaces;
using ExperimentTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExperimentTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperimentController : Controller
    {
        //зберігаєм посилання на об'єкт, реалізуючий інтерфейс 
        private readonly IExperimentResultRepository _experimentResultRepository;

        private readonly Random _random = new Random();

        public ExperimentController(IExperimentResultRepository experimentResultRepository)
        {
            _experimentResultRepository = experimentResultRepository;
        }

        [HttpGet("{experimentKey}")]
        public async Task<IActionResult> GetExperimentResult(string experimentKey, [FromQuery] string deviceToken)
        {
            //Отримуєм результат експерименту з репозиторію за допомогою асинхронного методу 
            var experimentResult = await _experimentResultRepository.GetExperimentResultAsync(deviceToken, experimentKey);

            //цей If виконуєм для визначення, чи вже існує результат експерименту для заданого пристрою та ключа експерименту в базі даних.
            //Якщо результат є null, це означає, що в базі даних немає запису для цього конкретного експерименту та пристрою, і його потрібно створити.
            if (experimentResult == null)
            {
                /*Визначаєм декілька можливих кольорів або цін та їх вагові коефіцієнти, 
                         * потім випадковим чином вибираєм кольори або ціни з врахуванням 
                         * їхнього відсоткового взаємовідношення. Якщо experimentKey не співпадає з "button_color" або "price", 
                         * повертаєм відповідь BadRequest з повідомленням про помилку.*/
                switch (experimentKey)
                {
                    case "button_color":
                        var colors = new[] { "#FF0000", "#00FF00", "#0000FF" };
                        var weights = new[] { 0.333, 0.333, 0.334 };
                        var cumulative = weights.Select((value, index) => weights.Take(index + 1).Sum()).ToList();
                        var rand = _random.NextDouble();
                        var colorIndex = cumulative.FindIndex(a => a >= rand);
                        experimentResult = new ExperimentResult
                        {
                            DeviceToken = deviceToken,
                            Value = colors[colorIndex],
                            ExperimentKey = "button_color"
                        };
                        break;
                    case "price":
                        var prices = new[] { 10, 20, 50, 5 };
                        var weights_price = new[] { 0.75, 0.1, 0.05, 0.1 };
                        var cumulative_price = weights_price.Select((value, index) => weights_price.Take(index + 1).Sum()).ToList();
                        var rand_price = _random.NextDouble();
                        var priceIndex = cumulative_price.FindIndex(a => a >= rand_price);
                        experimentResult = new ExperimentResult
                        {
                            DeviceToken = deviceToken,
                            Value = prices[priceIndex].ToString(),
                            ExperimentKey = "price"
                        };
                        break;
                    default:
                        return BadRequest("No such action found.");
                }

                //додаєм результат до БД
                await _experimentResultRepository.AddExperimentResultAsync(experimentResult);
            }

            //Повертаєм відповідь Ok(статус 200) з об'єктом JSON, який містить ключ та значення результату експерименту.
            return Ok(new { key = experimentKey, value = experimentResult.Value });
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetExperimentStatistics()
        {
            //Отримуєм всі результати експериментів з БД за допомогою асинхронного методу 
            var experimentResults = await _experimentResultRepository.GetAllExperimentResultsAsync();

            //Групуєм результати експериментів за ключем експерименту та значенням.
            //Також робимо вибірку потрібних полів (експериментальний ключ, значення та кількість) для статистики кожного унікального експерименту та значення.
            var statistics = experimentResults
                .GroupBy(er => new { er.ExperimentKey, er.Value })
                .Select(group => new
                {
                    ExperimentKey = group.Key.ExperimentKey,
                    Value = group.Key.Value,
                    Count = group.Count()
                })
                .GroupBy(stat => stat.ExperimentKey)//друге групування результатів за ключем експерименту для обчислення загальної кількості
                                                    //пристроїв для кожного унікального експерименту.
                .Select(group => new //вибірка потрібних полів для фінальної статистики. Тепер кожна група представляється як об'єкт,
                                     //що містить ключ експерименту, загальну кількість пристроїв та список значень для цього експерименту.
                {
                    ExperimentKey = group.Key,
                    TotalDevices = group.Sum(stat => stat.Count),
                    Values = group.ToList()
                });

            //Повертаєм об'єкт Ok(статус 200) зі статистикою експерименту у форматі JSON.
            return Ok(statistics);
        }
    }
}
