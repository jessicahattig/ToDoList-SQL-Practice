using System.Collections.Generic;
using MySqlConnector;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; set; }

    public Item(string description)
    {
      Description = description;
    }
    public Item(string description, int id)
    {
      Description = description;
      Id = id;
    }

    public override bool Equals(System.Object otherItem)
    {
      if (!(otherItem is Item))
      {
        return false;
      }
      else
      {
        Item newItem = (Item) otherItem;
        bool descriptionEquality = (this.Description == newItem.Description);
        return descriptionEquality;
      }
    }
    
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    public void Save()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "INSERT INTO items (description) VALUES (@ItemDescription);";

      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ItemDescription";
      param.Value = this.Description;
      cmd.Parameters.Add(param);    

      cmd.ExecuteNonQuery();

      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    public static List<Item> GetAll()
  {
      List<Item> allItems = new List<Item> { };

      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM items;";

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
          int itemId = rdr.GetInt32(0);
          string itemDescription = rdr.GetString(1);
          Item newItem = new Item(itemDescription, itemId);
          allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }



  public static void ClearAll()
  {
    MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
    conn.Open();
    
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = "DELETE FROM items;";
    cmd.ExecuteNonQuery();
    
    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
      }
    }

    public static Item Find(int searchId)
    {
          // Temporarily returning placeholder item to get beyond compiler errors until we refactor to work with database.
    Item placeholderItem = new Item("placeholder item");
    return placeholderItem;
    }
  }
}