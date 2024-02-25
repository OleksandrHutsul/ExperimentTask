using ExperimentTask.Models;

namespace ExperimentTask.Interfaces
{
    public interface IExperimentResultRepository
    {
        //метод призначений для отримання результату експерименту за допомогою токена пристрою та ключа.
        //Він повертає об’єкт типу ExperimentResult асинхронно.
        Task<ExperimentResult> GetExperimentResultAsync(string deviceToken, string experimentKey); 
        //з допомогою цього метода ми додаємо дані до БД
        Task AddExperimentResultAsync(ExperimentResult experimentResult);
        //з допомогою цього метода ми отримуємо дані з БД та повертаємо їх у вигляді списку об'єктів 
        Task<List<ExperimentResult>> GetAllExperimentResultsAsync();
    }
}