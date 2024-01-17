using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FieldRepository : IFieldRepository
    {
        private readonly GardenContext _context;

        public FieldRepository(GardenContext gardenContext)
        {
            _context = gardenContext;
        }

        public async Task<string> BurnFieldAsync(int id)
        {
            string mess = "success";

            var rowsDeleted = await _context.Fields.Where(f => f.Id == id).ExecuteDeleteAsync();

            if (rowsDeleted == 0)
            {
                mess = "ID not found :(";
                throw new Exception(mess);
            }

            return mess;
        }

        public async Task<Field> ChangeFieldAsync(Field field)
        {
            var rowsUpdated = await _context.Fields.Where(f => f.Id == field.Id).ExecuteUpdateAsync(
                           u =>
                           u.SetProperty(f => f.Name, field.Name)
                           .SetProperty(f => f.Area, field.Area)
                           );

            if (rowsUpdated == 0)
            {
                throw new Exception("Id non trouvé");
            }
            return field;
        }

        public async Task CreateFieldAsync(Field field)
        {
            await _context.Fields.AddAsync(field);
            await _context.SaveChangesAsync();
        }

        public async Task<Field?> GetFieldByIdAsync(int id)
            => await _context.Fields.Include(f => f.Flowers).FirstOrDefaultAsync(f => f.Id == id);


        public async Task<List<Field>> GetFieldsAsync()
            => await _context.Fields.ToListAsync();


        public async Task<List<Field>> SearchAsync(string search)
            => await _context.Fields.Where(f =>
                 EF.Functions.Like(f.Id.ToString(), $"%{search}%") ||
                 EF.Functions.Like(f.Name, $"%{search}%") ||
                 EF.Functions.Like(f.Area.ToString(), $"%{search}%")
                 ).ToListAsync();
    }
}
