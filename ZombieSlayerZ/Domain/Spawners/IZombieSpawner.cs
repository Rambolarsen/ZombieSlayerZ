using System.Collections.Generic;
using ZombieSlayerZ.Domain.Entities;

namespace ZombieSlayerZ.Domain.Spawners
{
    public interface IZombieSpawner : ISpawner<IEnumerable<Zombie>>
    {
    }
}