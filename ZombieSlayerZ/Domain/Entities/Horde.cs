using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieSlayerZ.Domain.Entities
{
    public class Horde
    {
        private readonly List<Zombie> _zombies = new List<Zombie>();
        public IReadOnlyCollection<Zombie> Zombies => _zombies.AsReadOnly();

        public double TotalHealth => Zombies.Sum(x => x.CurrentHealth);

        public double TotalDamage => Zombies.Sum(x => x.AttackRating);

        public double Speed => Zombies.Max(x => x.Speed);
    }
}
