using SchoolManagement.Protocols;

namespace SchoolManagement.Database
{
  public class DatabaseManager
  {
    readonly IDatabase Database;

    public DatabaseManager(IDatabase database)
    {
      Database = database;
    }
  }
}
