using System.Runtime.InteropServices.JavaScript;

namespace PharmacyDB.Models;

public class Perscription
{
    public int IdPrescription { get; set; }
    public DateTime date { get; set; }
    public DateTime dueDate { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }

}