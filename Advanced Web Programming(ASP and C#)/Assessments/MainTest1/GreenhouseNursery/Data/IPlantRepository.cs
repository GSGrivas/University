using GreenhouseNursery.Models;
using System.Linq;


namespace GreenhouseNursery.Data
{
    public interface IPlantRepository
    {
        IQueryable<Plant> GetAllPlants();
        IQueryable<Plant> GetPlantsInCategory(int categoryId);
        IQueryable<Plant> GetPlantsWithCategoryDetails();
        Plant GetPlantWithCategoryDetails(int id);
        void AddPlant(Plant plant);

        Category GetCategory(int id);
    }
}
