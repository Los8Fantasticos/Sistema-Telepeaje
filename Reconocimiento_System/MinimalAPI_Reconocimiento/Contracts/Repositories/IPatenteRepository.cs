using MinimalAPI_Reconocimiento.Models.ApplicationModel;

namespace MinimalAPI_Reconocimiento.Contracts.Repositories
{
    public interface IPatenteRepository
    {
        public Task<PatenteModel> GetPatente(string PatenteDTO);
    }
}
