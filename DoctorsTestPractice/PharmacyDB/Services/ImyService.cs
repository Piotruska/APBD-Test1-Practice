using PharmacyDB.Models.DTOs;

namespace PharmacyDB.Services;

public interface ImyService
{
    public Task<DTODoctorAndPerscription> GetDoctorPerscriptionsAsync(int idDoc);
    public Task<int> DeleteDoctor(int idDoc);
}