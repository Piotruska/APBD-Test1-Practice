using PharmacyDB.Models.DTOs;
using PharmacyDB.Repositories;

namespace PharmacyDB.Services;

public class MyService : ImyService
{
    private ImyRepository _repository;

    public MyService(ImyRepository repository)
    {
        _repository = repository;
    }

    public async Task<DTODoctorAndPerscription> GetDoctorPerscriptionsAsync(int idDoc)
    {
        return await _repository.GetDoctorPerscriptionsAsync(idDoc);
    }

    public async Task<int> DeleteDoctor(int idDoc)
    {
        return await _repository.DeleteDoctor(idDoc);
    }
}