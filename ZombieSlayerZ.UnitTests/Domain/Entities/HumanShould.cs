using AutoFixture;
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
        public void HealthShouldBe100AndCurrentShouldBeEqual_WithAssert()
        {
            var expectedHealth = 99;
            Assert.That(_sut.Health == expectedHealth);
            _sut.CurrentHealth.Should().Be(_sut.Health);
        }

        [Test]
        public void HealthShouldBe100AndCurrentShouldBeEqual()
        {
            var expectedHealth = 99;
            _sut.Health.Should().Be(expectedHealth);
            _sut.CurrentHealth.Should().Be(_sut.Health);                
        }

        [Test]
        public void Attack_WithoutWeaponShouldGiveAttackEqualToAttackRating()
        {
            //Arrange
            var weapon = new Fixture().Create<Weapon>();
            _sut.WeaponEquipped = weapon;
            _sut.Attack().Should().Be(_sut.AttackRating + weapon.GetDamage());
        }
        
    }
}
