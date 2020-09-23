using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieSlayerZ.Domain.Entities
{
    public interface IHumanoid
    {
        public double Speed { get; set; }

        public double AttackRating { get; set; }

        public double DefenseRating { get; set; }

        public double Health { get; set; }

        public double CurrentHealth { get; set; }

        public HumanoidState State { get; set; }
    }

    public enum HumanoidState
    {
        Idle = 0,
        Searching = 1,
        Fighting = 2,
        Fleeing = 3,
        Dead = 4,
    }
}
