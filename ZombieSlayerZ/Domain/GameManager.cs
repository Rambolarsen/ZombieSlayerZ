using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZombieSlayerZ.Domain.Loots;
using ZombieSlayerZ.Domain.Spawners;

namespace ZombieSlayerZ.Domain
{
    public class GameManager : IGameManager
    {
        private readonly ILootSpawner _lootSpawner;
        private readonly IZombieSpawner _zombieSpawner;
        private int _currentLevel = 0;
        private Loot _loot;
        public GameManager(ILootSpawner lootSpawner, IZombieSpawner zombieSpawner)
        {
            _lootSpawner = lootSpawner;
            _zombieSpawner = zombieSpawner;
            Player = new Human();
        }

        public void StartRound() => _currentLevel++;
            

        private readonly List<Zombie> _zombies = new List<Zombie>();
        public IReadOnlyCollection<Zombie> Zombies => _zombies;

        public void Spawn()
        {
            _loot = _lootSpawner.Spawn(_currentLevel);
            _zombies.AddRange(_zombieSpawner.Spawn(_currentLevel));
        }

        public Human Player { get; set; }

        public ICollection<Horde> Hordes { get; set; }

        public Loot GetLoot()
        {
            Player.State = HumanoidState.Searching;            
            return _loot;
        }

        public HumanoidState GetPlayerState() => Player.State;

        public string DisplayCurrentStats()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Current level: {_currentLevel}");
            stringBuilder.AppendLine($"Current Health: {Player.CurrentHealth}");
            stringBuilder.AppendLine($"Weapon equipped: {Player.WeaponEquipped?.ToString() ?? "No weapon equipped."}");
            stringBuilder.AppendLine("----------------------------------");
            return stringBuilder.ToString();
        }

        public void EquipWeapon(Weapon weapon)
        {
            Player.WeaponEquipped = weapon;
        }
    }
}
