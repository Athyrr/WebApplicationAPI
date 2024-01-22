using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IFieldRepository
    {
        // GetAll 
        public Task<List<Field>> GetFieldsAsync();
        /// <summary>
        /// Get fields list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get fields list</returns>

        //GetById
        public Task<Field> GetFieldByIdAsync(int id);
        /// <summary>
        /// Get 1 field by Id
        /// </summary>
        /// <param name="search"></param>
        /// <returns>Get 1 field by Id</returns>

        //Search
        public Task<List<Field>> SearchAsync(string search);
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="field"></param>
        /// <returns>Search</returns>

        //Post
        public Task CreateFieldAsync(Field field);
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="field"></param>
        /// <returns>Create</returns>


        //Put
        public Task<Field> ChangeFieldAsync(Field field);
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Edit</returns>

        //Delete
        public Task<string> BurnFieldAsync(int id);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete</returns>

    }
}
