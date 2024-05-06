using PharmacyDB.Models.DTOs;

namespace PharmacyDB.Repositories;

public interface ImyRepository
{
    public Task<DTODoctorAndPerscription> GetDoctorPerscriptionsAsync(int idDoc);
    public Task<int> DeleteDoctor(int idDoc);
}