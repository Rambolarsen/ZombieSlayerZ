namespace ZombieSlayerZ.Domain.Loots
{
    public class Loot
    {
        public Loot(Weapon weapon)
        {
            Weapon = weapon;
        }

        public Weapon Weapon { get; private set; }

        public override string ToString() =>
            Weapon?.ToString() ?? "No loot found!";
    }
}