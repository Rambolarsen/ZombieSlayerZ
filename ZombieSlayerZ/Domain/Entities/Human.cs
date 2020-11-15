using ZombieSlayerZ.Domain.Loots;

namespace ZombieSlayerZ.Domain.Entities
{
    public class Human : IHumanoid
    {
        public Human()
        {
            Health = 100;
            CurrentHealth = Health;
        }

        public double Speed { get; set; }
        public double AttackRating { get; set; }
        public double DefenseRating { get; set; }
        public double Health { get; set; }
        public double CurrentHealth { get; set; }
        public Weapon WeaponEquipped { get; set; }
        public HumanoidState State { get; set; } = HumanoidState.Idle;

        public double Attack() => AttackRating + (WeaponEquipped?.GetDamage() ?? 0);
    }
}