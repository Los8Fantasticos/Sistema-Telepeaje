using MinimalAPI_Reconocimiento.Contracts.Repositories;
using MinimalAPI_Reconocimiento.Contracts.Services;

namespace MinimalAPI_Reconocimiento.Services
{
    public class PatenteService : IPatenteService
    {
        private readonly IPatenteRepository _patenteRepository;
        public PatenteService(IPatenteRepository patenteRepository)
        {
            _patenteRepository = patenteRepository;
        }

        //validar si existe la patente en nuestra base de datos y si está activa o no.
        public async Task<bool> ValidatePatente(string PatenteDTO)
        {
            var PatenteModel = await _patenteRepository.GetPatente(PatenteDTO);
            bool exists = PatenteModel == null ? false : (PatenteModel.Active ? true : false);
            return exists;
        }
    }
}
