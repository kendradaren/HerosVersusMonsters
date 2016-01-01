using System;
using HerosVersusMonsters.Portable.Creatures;
using HerosVersusMonsters.Portable.Inventory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HerosVersusMonsters.Portable.Tests
{
    [TestClass]
    public class HeroTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var hero = new Hero(10, 10, 10, 10, 10, 10);
            Assert.IsNotNull(hero);
        }

        [TestMethod]
        public void EquipWeaponTest()
        {
            var weapon = InventoryHelper.CreateWeapon();
            var hero = new Hero(10, 10, 10, 10, 10, 10);
            hero.EquipWeapon(weapon);
            Assert.AreSame(weapon, hero.Slots[weapon.Slot.Value]);

        }
        [TestMethod]
        public void EquipShieldTest()
        {
            var shield = InventoryHelper.CreateShield();
            var hero = new Hero(10, 10, 10, 10, 10, 10);
            hero.EquipShield(shield);
            Assert.AreSame(shield, hero.Slots[shield.Slot.Value]);

        }

        [TestMethod]
        public void EnsureCanOnlyEquipOneWeapon()
        {
            var weapon1 = InventoryHelper.CreateWeapon();
            var weapon2 = InventoryHelper.CreateWeapon();

            var hero = new Hero(10, 10, 10, 10, 10, 10);
            hero.EquipWeapon(weapon1);
            hero.EquipWeapon(weapon2);
            Assert.AreSame(weapon2, hero.Slots[weapon2.Slot.Value]);

        }

        [TestMethod]
        public void EnsureCanEquipShieldAndOneHandedWeapon()
        {
            var weapon1 = InventoryHelper.CreateWeapon();
            weapon1.Slot = ItemSlotType.OneHandedWeapon;
            var shield = InventoryHelper.CreateShield();

            var hero = new Hero(10, 10, 10, 10, 10, 10);
            hero.EquipWeapon(weapon1);
            hero.EquipShield(shield);
            Assert.AreSame(weapon1, hero.Slots[ItemSlotType.OneHandedWeapon]);
            Assert.AreSame(shield, hero.Slots[ItemSlotType.Shield]);
        }

        [TestMethod]
        public void EnsureEquipShieldUnEquipsTwoHandedWeapon()
        {
            var weapon1 = InventoryHelper.CreateWeapon();
            weapon1.Slot = ItemSlotType.TwoHandedWeapon;
            var shield = InventoryHelper.CreateShield();

            var hero = new Hero(10, 10, 10, 10, 10, 10);
            hero.EquipWeapon(weapon1);
            hero.EquipShield(shield);
            Assert.IsNull(hero.Slots[ItemSlotType.TwoHandedWeapon]);
            Assert.AreSame(shield, hero.Slots[ItemSlotType.Shield]);
        }

        [TestMethod]
        public void EnsureTwoHandedWeaponUnEquipsOneHandedAndShield()
        {
            var weapon1 = InventoryHelper.CreateWeapon();
            weapon1.Slot = ItemSlotType.OneHandedWeapon;
            var weapon2 = InventoryHelper.CreateWeapon();
            weapon2.Slot = ItemSlotType.TwoHandedWeapon;
            var shield = InventoryHelper.CreateShield();

            var hero = new Hero(10, 10, 10, 10, 10, 10);
            hero.EquipShield(shield);
            hero.EquipWeapon(weapon1);
            Assert.AreSame(weapon1, hero.Slots[ItemSlotType.OneHandedWeapon]);
            Assert.AreSame(shield, hero.Slots[ItemSlotType.Shield]);

            hero.EquipWeapon(weapon2);
            Assert.IsNull(hero.Slots[ItemSlotType.Shield]);
            Assert.IsNull(hero.Slots[ItemSlotType.OneHandedWeapon]);
            Assert.AreSame(weapon2, hero.Slots[ItemSlotType.TwoHandedWeapon]);
        }


        [TestMethod]
        public void EnsureTwoHandedWeaponUnEquipsShield()
        {
            var weapon1 = InventoryHelper.CreateWeapon();
            weapon1.Slot = ItemSlotType.TwoHandedWeapon;
            var shield = InventoryHelper.CreateShield();

            var hero = new Hero(10, 10, 10, 10, 10, 10);
            hero.EquipShield(shield);
            hero.EquipWeapon(weapon1);
            Assert.IsNull(hero.Slots[ItemSlotType.Shield]);
            Assert.AreSame(weapon1, hero.Slots[ItemSlotType.TwoHandedWeapon]);
        }
    }
}
