namespace ZombieSlayerZ.Domain.Loots
{
    public interface ILootGenerator<T>
    {
        T GenerateLoot(int level);
    }
}