using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly GardenContext _context;

        public FlowerRepository(GardenContext context)
        {
            _context = context;
        }

        //Delete
        public async Task<string> BurnFlowerAsync(int id)
        {
            string mess = "success";

            var rowsDeleted = await _context.Flowers.Where(f => f.Id == id).ExecuteDeleteAsync();

            if (rowsDeleted == 0)
            {
                mess = "ID not found :(";
                throw new Exception(mess);
            }

            return mess;

        }

        //Edit
        public async Task<Flower> ChangeFlowerAsync(Flower flower)
        {
            var rowsUpdated = await _context.Flowers.Where(f => f.Id == flower.Id).ExecuteUpdateAsync(
                u =>
                u.SetProperty(f => f.NbPetal, flower.NbPetal)
                .SetProperty(f => f.Name, flower.Name)
                );

            if (rowsUpdated == 0)
            {
                throw new Exception("Id non trouvé");
            }
            return flower;
        }

        //Get
        public async Task<Flower?> GetFlowerByIdAsync(int id)
            => await _context.Flowers.Include(f=>f.Field).FirstOrDefaultAsync(f => f.Id == id); //Include pour join quand je rajouterai une entité liée

        //Get All
        public async Task<List<Flower>> GetFlowersAsync()
             => await _context.Flowers.ToListAsync();

        //Create
        public async Task PlantFlowerAsync(Flower flower)
        {
            await _context.Flowers.AddAsync(flower);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Flower>> SearchAsync(string search)
            => await _context.Flowers.Where(f =>
            EF.Functions.Like(f.Id.ToString(), $"%{search}%") ||
            EF.Functions.Like(f.Name, $"%{search}%") ||
            EF.Functions.Like(f.NbPetal.ToString(), $"%{search}%")
            ).ToListAsync();
    }
}
