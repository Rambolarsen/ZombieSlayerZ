﻿using AutoFixture;
using AutoFixture.NUnit3;
using FluentAssertions;
using NUnit.Framework;
using ZombieSlayerZ.Domain.Entities;
using ZombieSlayerZ.Domain.Loots;

namespace ZombieSlayerZ.UnitTests.Domain.Entities
{
    [TestFixture]
    public class HumanShould
    {
        private Human _sut;

        [SetUp]
        public void Init()
        {
            _sut = new Human();
        }


        [Test]
        public void OnNew_HealthShouldBe100AndCurrentShouldBeEqual_v1()
        {
            //Arrange
            var expectedHealth = 100;

            //Assert
            Assert.That(_sut.Health == expectedHealth);
            Assert.That(_sut.CurrentHealth == _sut.Health);
        }

        [Test]
        public void OnNew_HealthShouldBe100AndCurrentShouldBeEqual_v2()
        {
            //Arrange
            var expectedHealth = 100;

            //Assert
            _sut.Health.Should().Be(expectedHealth);
            _sut.CurrentHealth.Should().Be(_sut.Health);                
        }

        [Test]
        public void OnAttack_GiveAttackEqualToAttackRatingAndWeapon_v1()
        {
            //Arrange
            var weaponType = new WeaponType("TestWeapon", 1.2);
            var weapon = new Weapon(weaponType, LootQuality.Common, 1);
            _sut.WeaponEquipped = weapon;

            //Act/Assert
            _sut.Attack().Should().Be(_sut.AttackRating + weapon.GetDamage());
        }

        [Test]
        public void OnAttack_GiveAttackEqualToAttackRatingAndWeapon_v2()
        {
            //Arrange
            var weapon = new Fixture().Create<Weapon>();
            _sut.WeaponEquipped = weapon;

            //Act/Assert
            _sut.Attack().Should().Be(_sut.AttackRating + weapon.GetDamage());
        }

        [Test, AutoData]
        public void OnAttack_GiveAttackEqualToAttackRatingAndWeapon_v3(Weapon weapon, Human sut)
        {
            //Arrange
            sut.WeaponEquipped = weapon;

            //Act/Assert
            sut.Attack().Should().Be(sut.AttackRating + weapon.GetDamage());
        }

    }
}
