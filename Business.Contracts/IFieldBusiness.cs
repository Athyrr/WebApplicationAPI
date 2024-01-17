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

        //GetById
        public Task<Field> GetFieldByIdAsync(int id);

        //Search
        public Task<List<Field>> SearchAsync(string search);

        //Post
        public Task<Field> CreateFieldAsync(Field field);


        //Put
        public Task<Field> ChangeFieldAsync(Field field);

        //Delete
        public Task<string> BurnFieldAsync(int id);
    }
}
