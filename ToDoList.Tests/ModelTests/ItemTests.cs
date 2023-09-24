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

//     [TestMethod]
//     public void GetAll_ReturnsEmptyList_ItemList()
//     {
//       // Arrange
//       List<Item> newList = new List<Item> { };

//       // Act
//       List<Item> result = Item.GetAll();

//       // Assert
//       CollectionAssert.AreEqual(newList, result);
//     }

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