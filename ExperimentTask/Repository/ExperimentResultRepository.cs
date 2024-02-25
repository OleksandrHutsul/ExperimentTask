using ExperimentTask.Data;
using ExperimentTask.Interfaces;
using ExperimentTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ExperimentTask.Repository
{
    public class ExperimentResultRepository:IExperimentResultRepository
    {
        private readonly DataContext _context;

        public ExperimentResultRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ExperimentResult> GetExperimentResultAsync(string deviceToken, string experimentKey)
        {
            //з допомогою цього метода отримуєм результат експерименту за заданими deviceToken та experimentKey.
            return await _context.ExperimentResults.FirstOrDefaultAsync(e => e.DeviceToken == deviceToken && e.ExperimentKey == experimentKey);
        }

        public async Task AddExperimentResultAsync(ExperimentResult experimentResult)
        {
            //з допомогою цього метода додаєм новий результат експерименту до бази даних. Використовуєм метод Add для додавання нового
            //об'єкту до контексту бази даних
            _context.ExperimentResults.Add(experimentResult);
            //викликаєм асинхронний метод SaveChangesAsync для збереження змін в базі даних.
            await _context.SaveChangesAsync();
        }

        public async Task<List<ExperimentResult>> GetAllExperimentResultsAsync()
        {
            //повертаєм всі результати експериментів. Використовуєм метод ToListAsync,
            //який асинхронно отримує всі результати та повертає їх у вигляді списку.
            return await _context.ExperimentResults.ToListAsync();
        }
    }
}
