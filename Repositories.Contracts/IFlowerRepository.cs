using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IFlowerRepository
    {
        // GetAll 
        public Task<List<Flower>> GetFlowers();

        //GetById
        public Task<Flower> GetFlowerById(int id);

        //Search
        public Task<List<Flower>> Search(string search);

        //Post
        public Task PlantFlower(Flower flower);


        //Put
        public Task ChangeFlower(Flower flower);

        //Delete
        public Task BurnFlower(int id);

    }
}
