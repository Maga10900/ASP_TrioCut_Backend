using TriVibe.DAL.SqlServer.DbContexts;

namespace TriVibe.DAL.SqlServer.Repositories;

public class SqlBaseRepository
{
    protected readonly string _connectionString;
    protected readonly TrioCutDb _context;

    public SqlBaseRepository(string connectionString, TrioCutDb context)
    {
        _connectionString = connectionString;
        _context = context;
    }
}
