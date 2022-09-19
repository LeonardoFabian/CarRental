using CarRental.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CarRental.Services
{
    public interface ICategoriesRepository
    {
        Task Create(Categories category);
    }

    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly string connectionString;

        public CategoriesRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Create(Categories category)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>($@"INSERT INTO Categories(Name, CostPerDay, Passengers, Luggages, LateFeePerHour)
                                                    VALUES(@Name, @CostPerDay, @Passengers, @Luggages, @LateFeePerHour);
                                                    SELECT SCOPE_IDENTITY();", category);

            category.Id = id;
        }
    }
}
