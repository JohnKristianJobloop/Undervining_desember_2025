using System;

namespace solid_principles_examples;

public class Depenceny_Inversion_Prinsiple_Example
{

}

public class DatabaseHandler(SqlDatabase database) : IDatabaseHandler
{
    public void SaveToDatabase(Order order)
    {
        database.Save(order);
    }
}

public class SqlDatabase
{
    public void Save(Order order)
    {
        
    }
}