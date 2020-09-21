using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieSlayerZ.Domain.Spawners
{
    public class ZombieSpawner : IZombieSpawner
    {
        public IEnumerable<Zombie> Spawn(int round)
        {
            return new List<Zombie>();
        }
    }
}
