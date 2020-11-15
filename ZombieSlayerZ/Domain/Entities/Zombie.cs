namespace ZombieSlayerZ.Domain.Entities
{
    public class Zombie : IHumanoid
    {
        public double Speed { get; set; }
        public double AttackRating { get; set; }
        public double DefenseRating { get; set; }
        public double Health { get; set; }
        public double CurrentHealth { get; set; }
        public Horde Horde { get; }
        public HumanoidState State { get; set; } = HumanoidState.Idle;
    }
}