using GreenhouseNursery.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GreenhouseNursery.Data
{
    public class PlantRepository : IPlantRepository
    {
        private readonly AppDbContext _appDbContext;

        public PlantRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        // Add a Plant
        public void AddPlant(Plant plant)
        {
            _appDbContext.Plants.Add(plant);
            _appDbContext.SaveChanges();
        }

        // Get details of all Plants
        public IQueryable<Plant> GetAllPlants()
        {
            return _appDbContext.Plants;
        }

        // Get details of a specified Category
        public Category GetCategory(int id)
        {
            return _appDbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        // Get details of all Plants in the specified Category
        public IQueryable<Plant> GetPlantsInCategory(int categoryId)
        {
            return (IQueryable<Plant>)_appDbContext.Plants.FirstOrDefault(p => p.CategoryId == categoryId);
        }

        // Get details of all Plants together with their Category details
        public IQueryable<Plant> GetPlantsWithCategoryDetails()
        {
            return _appDbContext.Plants
        .Include(f => f.Category);
        }

        // Get details of a single Plant together with the Plant's Category details
        public Plant GetPlantWithCategoryDetails(int id)
        {
            return (Plant)_appDbContext.Plants
        .Include(f => f.Category)
        .FirstOrDefault(p => p.PlantId == id);
        }
    }
}
