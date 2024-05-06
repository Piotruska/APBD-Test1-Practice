using System.Data.Common;
using Microsoft.Data.SqlClient;
using PharmacyDB.Models;
using PharmacyDB.Models.DTOs;

namespace PharmacyDB.Repositories;

public class MyRepository : ImyRepository
{
    private readonly IConfiguration _configuration;

    public MyRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<DTODoctorAndPerscription> GetDoctorPerscriptionsAsync(int idDoc)
    {
        SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        
        
        await sqlConnection.OpenAsync();

        var dtoDoctorAndPerscription = new DTODoctorAndPerscription();
        
        try
        { 
            sqlCommand.CommandText = $"SELECT * FROM Doctor " +
                                   $"WHERE IdDoctor = @idDoc ";
            sqlCommand.Parameters.AddWithValue("@idDoc", idDoc);
            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            dtoDoctorAndPerscription._doctor.idDoctor = (int)reader["IdDoctor"];
            dtoDoctorAndPerscription._doctor.FirstName = (string)reader["FirstName"];
            dtoDoctorAndPerscription._doctor.LastName = (string)reader["LastName"];
            dtoDoctorAndPerscription._doctor.Email = (string)reader["Email"];
            
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandText = $"SELECT * FROM Prescription" +
                                     $" WHERE IdDoctor = @idDoc ";
            sqlCommand.Parameters.AddWithValue("@idDoc", idDoc);
            reader.Dispose();
            
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var record = new Perscription();
                record.IdPrescription = (int)reader["IdPrescription"];
                record.date = (DateTime)reader["Date"];
                record.dueDate = (DateTime)reader["DueDate"];
                record.IdPatient = (int)reader["IdPatient"];
                record.IdDoctor = (int)reader["IdDoctor"];
                dtoDoctorAndPerscription._list.Add(record);
            }



        }
        catch (SqlException exp)
        {
            return null;
        }
        sqlConnection.Dispose();
        sqlCommand.Dispose();
        return dtoDoctorAndPerscription;
    }

    public async Task<int> DeleteDoctor(int idDoc)
    {
        SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        
        await sqlConnection.OpenAsync();

        DbTransaction transaction = await sqlConnection.BeginTransactionAsync();
        sqlCommand.Transaction = (SqlTransaction)transaction;
        int affectedcount = 0;
        
        try
        {
            sqlCommand.CommandText = $"DELETE FROM Prescription_Medicament WHERE IdPrescription " +
                                     $"IN (SELECT IdPrescription FROM Prescription WHERE IdDoctor = @idDoc)";
            sqlCommand.Parameters.AddWithValue("@idDoc", idDoc);
            affectedcount += sqlCommand.ExecuteNonQuery(); //when updating / deleting for example
            
            sqlCommand.Parameters.Clear();
            
            sqlCommand.CommandText = $"DELETE FROM Prescription WHERE IdDoctor = @idDoc";
            sqlCommand.Parameters.AddWithValue("@idDoc", idDoc);
            affectedcount += sqlCommand.ExecuteNonQuery(); //when updating / deleting for example
            
            sqlCommand.Parameters.Clear();
            
            sqlCommand.CommandText = $"DELETE FROM Doctor WHERE IdDoctor = @idDoc";
            sqlCommand.Parameters.AddWithValue("@idDoc", idDoc);
            affectedcount += sqlCommand.ExecuteNonQuery(); //when updating / deleting for example
            
            
            // var reader = sqlCommand.ExecuteReader(); // to read a list of objects 
            // var affectedCount = sqlCommand.ExecuteNonQuery(); //when updating / deleting for example


            await transaction.CommitAsync();
        }
        catch (SqlException exp)
        {
            await transaction.RollbackAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
        }
        
        sqlConnection.Dispose();
        sqlCommand.Dispose();
        
        return affectedcount;

    }

    
}