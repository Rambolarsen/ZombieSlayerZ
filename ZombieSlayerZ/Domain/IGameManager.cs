using ZombieSlayerZ.Domain.Loots;

namespace ZombieSlayerZ.Domain
{
    public interface IGameManager
    {
        HumanoidState GetPlayerState();
        Loot GetLoot();
        void Spawn();
        void StartRound();
        string DisplayCurrentStats();
        void EquipWeapon(Weapon weapon);
    }
}
