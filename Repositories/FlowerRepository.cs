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
        public async Task BurnFlower(int id)
        {
            Flower? flower = await _context.Flowers.FirstOrDefaultAsync(f => f.Id == id);
            _context.Flowers.Remove(flower);
            await _context.SaveChangesAsync();
        }

        //Edit
        public async Task ChangeFlower(Flower flower)
        {
            Flower? flowerToModify = await _context.Flowers.FirstOrDefaultAsync(f => f.Id == flower.Id);
            flowerToModify.Name = flower.Name;
            flowerToModify.NbPetal = flower.NbPetal;

            await _context.SaveChangesAsync();
        }

        //Get
        public async Task<Flower?> GetFlowerById(int id)
            => await _context.Flowers.FirstOrDefaultAsync(f => f.Id == id);

        //Get All
        public async Task<List<Flower>> GetFlowers()
             => await _context.Flowers.ToListAsync();

        //Create
        public async Task PlantFlower(Flower flower)
        {
            await _context.Flowers.AddAsync(flower);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Flower>> Search(string search)
            => await _context.Flowers.Where(f =>
            EF.Functions.Like(f.Id.ToString(), $"%{search}%") ||
            EF.Functions.Like(f.Name, $"%{search}%")
            ).ToListAsync();
    }
}
