using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoFixture.NUnit3;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using ZombieSlayerZ.Domain;
using ZombieSlayerZ.Domain.Spawners;

namespace ZombieSlayerZ.UnitTests.Domain
{
    [TestFixture]
    public class GameManagerShould
    {

        [Test]
        public void OnNew_PlayerIsAlive_ShouldBeTrue()
        {
            //Arrange
            var lootSpawner = A.Fake<ILootSpawner>();
            var zombieSpawner = A.Fake<IZombieSpawner>();
            var sut = new GameManager(lootSpawner, zombieSpawner);

            //Assert
            sut.PlayerIsAlive().Should().BeTrue();
        }

        [Test]
        public void OnSpawn_VerifyCallsToLootSpawner_V1()
        {
            //Arrange
            var lootSpawner = A.Fake<ILootSpawner>();
            var zombieSpawner = A.Fake<IZombieSpawner>();
            var sut = new GameManager(lootSpawner, zombieSpawner);

            //Act
            sut.Spawn();

            //Assert
            A.CallTo(() => lootSpawner.Spawn(A<int>._)).MustHaveHappenedOnceExactly();            
        }

        [Test]
        public void Spawn_VerifyCallsToLootSpawner_V2()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoFakeItEasyCustomization());
            var mocklootSpawner = fixture.Freeze<Fake<ILootSpawner>>();
            var sut = fixture.Create<GameManager>();

            //Act
            sut.Spawn();

            //Assert
            mocklootSpawner.CallsTo(x => x.Spawn(A<int>._)).MustHaveHappenedOnceExactly();
        }

        [Test]
        [AutoFakeItEasyData]
        public void Spawn_VerifyCallsToLootSpawner_V3([Frozen] Fake<ILootSpawner> mockLootSpawner, GameManager sut)
        {
            //Act
            sut.Spawn();

            //Assert
            mockLootSpawner.CallsTo(x => x.Spawn(A<int>._)).MustHaveHappenedOnceExactly();
        }
    }
}
