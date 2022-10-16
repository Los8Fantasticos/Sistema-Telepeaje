using Microsoft.EntityFrameworkCore;

using MinimalAPI_Reconocimiento.Contracts.Repositories;
using MinimalAPI_Reconocimiento.Models.ApplicationModel;

namespace MinimalAPI_Reconocimiento.Infrastructure.Repositories
{
    public class PatenteRepository : IPatenteRepository
    {
        private readonly ApplicationDbContext _context;
        public PatenteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PatenteModel> GetPatente(string PatenteDTO)
        {
            var result = await _context.Patente.Where(x => x.Patente == PatenteDTO).AsNoTracking().FirstOrDefaultAsync();
            return result;
        }
    }
}
