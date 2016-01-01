using Microsoft.Pex.Framework.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HerosVersusMonsters.Portable;
using Microsoft.Pex.Framework.Generated;
// <copyright file="CreatureBaseTest.EquipItem.g.cs">Copyright ©  2015</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace HerosVersusMonsters.Portable.Tests
{
    public partial class CreatureBaseTest
    {

[TestMethod]
[PexGeneratedBy(typeof(CreatureBaseTest))]
[PexRaisedException(typeof(TraceAssertionException))]
public void EquipItemThrowsTraceAssertionException871()
{
    using (PexTraceListenerContext.Create())
    {
      InventoryItem inventoryItem;
      Monster monster;
      inventoryItem = new InventoryItem();
      inventoryItem.ShortName = (string)null;
      inventoryItem.Description = (string)null;
      inventoryItem.Price = 0;
      inventoryItem.Weight = 0;
      inventoryItem.IsEquipped = false;
      inventoryItem.Slot = default(ItemSlotType?);
      monster = new Monster(0, 0, 0, 0, 0, 0);
      ((CreatureBase)monster).AddToInventory(inventoryItem);
      this.EquipItem((CreatureBase)monster, inventoryItem);
    }
}
    }
}
