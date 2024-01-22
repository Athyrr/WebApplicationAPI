using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IFieldBusiness
    {

        // GetAll 
        public Task<List<Field>> GetFieldsAsync();
        /// <summary>
        /// Get fields
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get fields</returns>

        //GetById
        public Task<Field> GetFieldByIdAsync(int id);
        /// <summary>
        /// Get 1 field
        /// </summary>
        /// <param name="search"></param>
        /// <returns>Get 1 field</returns>

        //Search
        public Task<List<Field>> SearchAsync(string search);
        /// <summary>
        ///Search 1 field by prop
        /// </summary>
        /// <param name="field"></param>
        /// <returns> Search 1 field by prop</returns>

        //Post
        public Task<Field> CreateFieldAsync(Field field);
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
