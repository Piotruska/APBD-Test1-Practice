using System.Runtime.InteropServices.JavaScript;

namespace PharmacyDB.Models;

public class Perscription
{
    public int IdPrescription { get; set; }             // FORGOTTO ADD { get; set; } result blanck jason return
    public DateTime date { get; set; }                 // FORGOTTO ADD { get; set; } result blanck jason return
    public DateTime dueDate { get; set; }             // FORGOTTO ADD { get; set; } result blanck jason return
    public int IdPatient { get; set; }                // FORGOTTO ADD { get; set; } result blanck jason return
    public int IdDoctor { get; set; }                 // FORGOTTO ADD { get; set; } result blanck jason return

}