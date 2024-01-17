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
    public class FieldBusiness : IFieldBusiness
    {
        private readonly IFieldRepository _fieldRepository;

        public FieldBusiness(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<string> BurnFieldAsync(int id)
        {
            string mess = await _fieldRepository.BurnFieldAsync(id);

            return mess;
        }

        public async Task<Field> ChangeFieldAsync(Field field)
        {
            try
            {
                Field? fieldToChange = await _fieldRepository.GetFieldByIdAsync(field.Id);
                return fieldToChange;
            }
            catch (Exception)
            {
                throw new Exception("Id non trouvé");
            }
        }

        public async Task<Field> CreateFieldAsync(Field field)
        {
            await _fieldRepository.CreateFieldAsync(field);
            return field;
        }

        public async Task<Field> GetFieldByIdAsync(int id)
        {
            var field = await _fieldRepository.GetFieldByIdAsync(id);
            return field;
        }

        public async Task<List<Field>> GetFieldsAsync()
        {
            var fields = await _fieldRepository.GetFieldsAsync();
            return fields;
        }

        public async Task<List<Field>> SearchAsync(string search)
        {
            var fieldSearched = await _fieldRepository.SearchAsync(search);
            return fieldSearched;
        }
    }
}
