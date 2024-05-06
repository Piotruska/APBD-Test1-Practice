namespace PharmacyDB.Models.DTOs;

public class DTODoctorAndPerscription
{
    public Doctor _doctor { get; set; }                 // FORGOTTO ADD { get; set; } result blanck jason return
    public List<Perscription> _list  { get; set; }      // FORGOTTO ADD { get; set; } result blanck jason return
     
    public DTODoctorAndPerscription()
    {
        _doctor = new Doctor();
        _list = new List<Perscription>();
    }
}