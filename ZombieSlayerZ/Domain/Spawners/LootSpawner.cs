using ZombieSlayerZ.Domain.Loots;

namespace ZombieSlayerZ.Domain.Spawners
{
    public class LootSpawner : ILootSpawner
    {
        private readonly ILootGenerator<Weapon> _weaponGenerator;

        public LootSpawner(ILootGenerator<Weapon> weaponGenerator)
        {
            _weaponGenerator = weaponGenerator;
        }

        public Loot Spawn(int level)
        {
            var weapon = _weaponGenerator.GenerateLoot(level);
            return new Loot(weapon);
        }
    }
}