using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using ToDoList.Models;
using System;

namespace ToDoList.Tests
{


  [TestClass]
  public class ItemTests : IDisposable
  {
    // we've added a new property
    public IConfiguration Configuration { get; set; }


    public void Dispose()
    {
      Item.ClearAll();
    }


    // we've added a constructor
    public ItemTests()
    {
      IConfigurationBuilder builder = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
      DBConfiguration.ConnectionString = Configuration["ConnectionStrings:TestConnection"];
    }

    //New tests for SQL
    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
    {
      //Arrange
      List<Item> newList = new List<Item> { };
      
      //Act
      List<Item> result = Item.GetAll();
      
      //Assert
      CollectionAssert.AreEqual(newList, result);
}

    [TestMethod]
    public void ReferenceTypes_ReturnsTrueBecauseBothItemsAreSameReference_bool()
    {
      // Arrange, Act
      Item firstItem = new Item("Mow the lawn");
      Item copyOfFirstItem = firstItem;
      copyOfFirstItem.Description = "Learn about C#";

      // Assert
      Assert.AreEqual(firstItem.Description, copyOfFirstItem.Description);
    }

    [TestMethod]
    public void ValueTypes_ReturnsTrueBecauseValuesAreTheSame_Bool()
    {
      // Arrange, Act
      int test1 = 1;
      int test2 = 1;

      // Assert
      Assert.AreEqual(test1, test2);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ItemList()
    {
      //Arrange
      Item testItem = new Item("Mow the lawn");

      //Act
      testItem.Save();
      List<Item> result = Item.GetAll();
      List<Item> testList = new List<Item>{testItem};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

  [TestMethod] // updated test of GetAll() below.
  public void GetAll_ReturnsItems_ItemList()
  {
    //Arrange
    string description01 = "Walk the dog";
    string description02 = "Wash the dishes";
    Item newItem1 = new Item(description01);
    newItem1.Save(); // New code
    Item newItem2 = new Item(description02);
    newItem2.Save(); // New code
    List<Item> newList = new List<Item> { newItem1, newItem2 };

    //Act
    List<Item> result = Item.GetAll();

    //Assert
    CollectionAssert.AreEqual(newList, result);
  }
  
    [TestMethod] // updated test of Find() below.
    public void Find_ReturnsCorrectItemFromDatabase_Item()
    {
      //Arrange
      Item newItem = new Item("Mow the lawn");
      newItem.Save();
      Item newItem2 = new Item("Wash dishes");
      newItem2.Save();

      //Act
      Item foundItem = Item.Find(newItem.Id);
      //Assert
      Assert.AreEqual(newItem, foundItem);
    }



  }
}

    // Previous tests

//     [TestMethod]
//     public void ItemConstructor_CreatesInstanceOfItem_Item()
//     {
//       Item newItem = new Item("test");
//       Assert.AreEqual(typeof(Item), newItem.GetType());
//     }

//     [TestMethod]
//     public void GetDescription_ReturnsDescription_String()
//     {
//       //Arrange
//       string description = "Walk the dog.";

//       //Act
//       Item newItem = new Item(description);
//       string result = newItem.Description;

//       //Assert
//       Assert.AreEqual(description, result);
//     }

//     [TestMethod]
//     public void SetDescription_SetDescription_String()
//     {
//       //Arrange
//       string description = "Walk the dog.";
//       Item newItem = new Item(description);

//       //Act
//       string updatedDescription = "Do the dishes";
//       newItem.Description = updatedDescription;
//       string result = newItem.Description;

//       //Assert
//       Assert.AreEqual(updatedDescription, result);
//     }

    // [TestMethod]
    // public void GetAll_ReturnsEmptyList_ItemList()
    // {
    //   // Arrange
    //   List<Item> newList = new List<Item> { };

    //   // Act
    //   List<Item> result = Item.GetAll();

    //   // Assert
    //   CollectionAssert.AreEqual(newList, result);
    // }



//     [TestMethod]
//     public void GetAll_ReturnsItems_ItemList()
//     {
//       //Arrange
//       string description01 = "Walk the dog";
//       string description02 = "Wash the dishes";
//       Item newItem1 = new Item(description01);
//       Item newItem2 = new Item(description02);
//       List<Item> newList = new List<Item> { newItem1, newItem2 };

//       //Act
//       List<Item> result = Item.GetAll();

//       //Assert
//       CollectionAssert.AreEqual(newList, result);
//     }
//   }
// }