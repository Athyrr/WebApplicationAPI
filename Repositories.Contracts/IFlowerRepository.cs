﻿using Entities;
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
        public Task<List<Flower>> GetFlowersAsync();

        //GetById
        public Task<Flower> GetFlowerByIdAsync(int id);

        //Search
        public Task<List<Flower>> SearchAsync(string search);

        //Post
        public Task PlantFlowerAsync(Flower flower);


        //Put
        public Task<Flower> ChangeFlowerAsync(Flower flower);

        //Delete
        public Task<string> BurnFlowerAsync(int id);

    }
}
