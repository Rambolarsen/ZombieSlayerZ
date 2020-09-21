using System.Collections.Generic;

namespace ZombieSlayerZ.Domain.Spawners
{
    public interface IZombieSpawner : ISpawner<IEnumerable<Zombie>>
    {
    }
}