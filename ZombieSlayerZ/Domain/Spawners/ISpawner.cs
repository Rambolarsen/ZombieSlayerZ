using System.Collections.Generic;

namespace ZombieSlayerZ.Domain.Spawners
{
    public interface ISpawner<T>
    {
        T Spawn(int level);
    }
}