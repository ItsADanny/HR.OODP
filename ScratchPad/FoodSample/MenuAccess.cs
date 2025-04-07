using Microsoft.Data.Sqlite;
using Dapper;

public class MenuAccess {

    private static SqliteConnection _connection = new SqliteConnection($"Data Source={Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent}/Local.db");
    private static string Table = "Menu";

    public MenuAccess() { }

    public List<FoodItem> GetFoodItems() {
        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<FoodItem>(sql).ToList();
    }

    public void Write(FoodItem Item) {
        string sql = $"INSERT INTO {Table} (id, name, description, price) VALUES (@ID, @Name, @Description, @Price)";
        _connection.Execute(sql, Item);
    }

    public void CloseConnection() {
        MenuAccess._connection.Close();
    }
}