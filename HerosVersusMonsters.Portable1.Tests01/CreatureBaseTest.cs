using Microsoft.Pex.Framework.Exceptions;
// <copyright file="CreatureBaseTest.cs">Copyright ©  2015</copyright>

using System;
using HerosVersusMonsters.Portable;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HerosVersusMonsters.Portable.Tests
{
    [TestClass]
    [PexClass(typeof(CreatureBase))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CreatureBaseTest
    {

        [PexMethod]
        [PexAllowedException(typeof(TraceAssertionException))]
        public void EquipItem([PexAssumeNotNull]CreatureBase target, InventoryItem inventoryItem)
        {
            target.EquipItem(inventoryItem);
            // TODO: add assertions to method CreatureBaseTest.EquipItem(CreatureBase, InventoryItem)
        }
    }
}
