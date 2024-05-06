namespace PharmacyDB.Models.DTOs;

public class DTODoctorAndPerscription
{
    public Doctor _doctor { get; set; }
    public List<Perscription> _list  { get; set; }
    
    public DTODoctorAndPerscription()
    {
        _doctor = new Doctor();
        _list = new List<Perscription>();
    }
}