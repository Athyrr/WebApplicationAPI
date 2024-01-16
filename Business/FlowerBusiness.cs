using Business.Contracts;
using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class FlowerBusiness : IFlowerBusiness
    {
        private readonly IFlowerRepository _flowerRepository;

        public FlowerBusiness(IFlowerRepository flowerRepository)
        {
            _flowerRepository = flowerRepository;
        }


        public async Task<string> BurnFlowerAsync(int id)
        {
            string mess = await _flowerRepository.BurnFlowerAsync(id);

            return mess;
        }

        public async Task<Flower> ChangeFlowerAsync(Flower flower)
        {
            try
            {
                Flower? flowerToChange = await _flowerRepository.GetFlowerByIdAsync(flower.Id);
                return flowerToChange;
            }
            catch (Exception)
            {
                throw new Exception("Id non trouvé");
            }
        }

        public async Task<Flower> GetFlowerByIdAsync(int id)
        {
            var flower = await _flowerRepository.GetFlowerByIdAsync(id);
            return flower;
        }

        public async Task<List<Flower>> GetFlowersAsync()
        {
            var flowers = await _flowerRepository.GetFlowersAsync();
            return flowers;
        }

        public async Task<Flower> PlantFlowerAsync(Flower flower)
        {
            await _flowerRepository.PlantFlowerAsync(flower);
            return flower;
        }

        public async Task<List<Flower>> SearchAsync(string search)
        {
            var flowersSearched = await _flowerRepository.SearchAsync(search);
            return flowersSearched;
        }
    }
}
