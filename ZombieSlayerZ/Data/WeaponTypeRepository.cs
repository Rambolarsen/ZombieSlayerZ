using System;
using System.Collections.Generic;
using System.Text;
using ZombieSlayerZ.Domain.Loots;

namespace ZombieSlayerZ.Data
{
    public class WeaponTypeRepository : IRepository<WeaponType>
    {
        public ICollection<WeaponType> GetAll()
        {
            return new List<WeaponType>()
            {
                new WeaponType("ZombieArm", 1.2),
                new WeaponType("ZombieFoot", 1.5),
                new WeaponType("Katana", 2),
                new WeaponType("Crowbar", 3),
                new WeaponType("ChainSaw", 5)
            };
        }
    }
}
