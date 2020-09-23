using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ZombieSlayerZ.Domain;
using ZombieSlayerZ.Domain.Entities;
using ZombieSlayerZ.Domain.Spawners;

namespace ZombieSlayerZ.UnitTests.Domain
{
    [TestFixture]
    public class GameManagerShould
    {

        private GameManager _sut;
        private ILootSpawner _lootSpawner;
        private IZombieSpawner _zombieSpawner;

        [SetUp]
        public void Init()
        {
            _lootSpawner = A.Fake<ILootSpawner>();
            _zombieSpawner = A.Fake<IZombieSpawner>();
            _sut = new GameManager(_lootSpawner, _zombieSpawner);
        }

        [Test]
        public void PlayerIsAlive_ShouldBeTrue()
        {
            _sut.PlayerIsAlive().Should().BeTrue();
        }

        [Test]
        public void Spawn_VerifyCallsToSpawnInterfaces()
        {
            _sut.Spawn();
            A.CallTo(() => _lootSpawner.Spawn(A<int>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _zombieSpawner.Spawn(A<int>._)).MustHaveHappenedOnceExactly();
        }
    }
}
