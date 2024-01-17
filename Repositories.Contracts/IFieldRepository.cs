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

        //GetById
        public Task<Field> GetFieldByIdAsync(int id);

        //Search
        public Task<List<Field>> SearchAsync(string search);

        //Post
        public Task CreateFieldAsync(Field field);


        //Put
        public Task<Field> ChangeFieldAsync(Field field);

        //Delete
        public Task<string> BurnFieldAsync(int id);

    }
}
