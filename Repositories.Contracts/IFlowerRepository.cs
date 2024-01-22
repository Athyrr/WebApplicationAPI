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
        public Task<List<Flower>> GetFlowersAsync();
        /// <summary>
        ///Get 1 flower
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Get 1 flower</returns>

        //GetById
        public Task<Flower> GetFlowerByIdAsync(int id);
        /// <summary>
        ///List flowers
        /// </summary>
        /// <param name="search"></param>
        /// <returns> List flowers</returns>

        //Search
        public Task<List<Flower>> SearchAsync(string search);
        /// <summary>
        ///Search by flower prop
        /// </summary>
        /// <param name="flower"></param>
        /// <returns> Search by flower prop</returns>

        //Post
        public Task PlantFlowerAsync(Flower flower);
        /// <summary>
        /// create
        /// </summary>
        /// <param name="flower"></param>
        /// <returns>create</returns>


        //Put
        public Task<Flower> ChangeFlowerAsync(Flower flower);
        /// <summary>
        /// edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns>edit</returns>

        //Delete
        public Task<string> BurnFlowerAsync(int id);
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete</returns>


    }
}
