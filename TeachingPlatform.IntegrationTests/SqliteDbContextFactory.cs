using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using TeachingPlatform.Infra.Context;

namespace TeachingPlatform.Test
{
    public class SqliteDbContextFactory
    {
        private TeachingContext _context;
        private DbConnection _connection;

        public (TeachingContext Context, DbConnection connection) CreateContext()
        {

            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<TeachingContext>()
                .UseSqlite(_connection) // Use SQLite in-memory database
                .Options;

            _context = new TeachingContext(options);
            _context.Database.EnsureCreated(); // Ensure the schema is applied

            return (_context, _connection);
        }
    }
}

