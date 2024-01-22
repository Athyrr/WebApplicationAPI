using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IFlowerBusiness
    {
        // GetAll 
        public Task<List<Flower>> GetFlowersAsync();
        /// <summary>
        /// Get flowers list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get flowers list</returns>

        //GetById
        public Task<Flower> GetFlowerByIdAsync(int id);
        /// <summary>
        /// Get 1 flower by ID
        /// </summary>
        /// <param name="search"></param>
        /// <returns>Get 1 flower by ID</returns>

        //Search
        public Task<List<Flower>> SearchAsync(string search);
        /// <summary>
        ///Search 1 flower by flower prop
        /// </summary>
        /// <param name="flower"></param>
        /// <returns> Search 1 flower by flower prop</returns>

        //Post
        public Task<Flower> PlantFlowerAsync(Flower flower);
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="flower"></param>
        /// <returns>Create</returns>


        //Put
        public Task<Flower> ChangeFlowerAsync(Flower flower);
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Edit</returns>

        //Delete
        public Task<string> BurnFlowerAsync(int id);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete</returns>


    }
}
