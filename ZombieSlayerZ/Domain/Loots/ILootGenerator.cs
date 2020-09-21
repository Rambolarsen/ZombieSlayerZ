using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieSlayerZ.Domain.Loots
{
    public interface ILootGenerator<T>
    {
        T GenerateLoot(int level);
    }
}
