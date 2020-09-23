using ZombieSlayerZ.Domain.Entities;
using ZombieSlayerZ.Domain.Loots;

namespace ZombieSlayerZ.Domain
{
    public interface IGameManager
    {
        bool PlayerIsAlive();        
        Loot GetLoot();
        void Spawn();
        void StartRound();
        string DisplayCurrentStats();
        void EquipWeapon(Weapon weapon);
    }
}
