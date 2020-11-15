namespace ZombieSlayerZ.Domain.Loots
{
    public class Weapon : ILootQuality
    {
        public Weapon(WeaponType weaponType, LootQuality lootQuality, int level)
        {
            Type = weaponType;
            Quality = lootQuality;
            BaseDamage = level;
        }

        public WeaponType Type { get; set; }
        public double BaseDamage { get; set; }
        public LootQuality Quality { get; set; } = LootQuality.Common;

        public double GetDamage()
        {
            return (BaseDamage + GetDamageFromQuality()) * Type.BaseMultiplier;
        }

        private double GetDamageFromQuality()
        {
            double bonusDamage = 0;
            switch (Quality)
            {
                case LootQuality.Common:
                    bonusDamage = 0;
                    break;

                case LootQuality.Uncommon:
                    bonusDamage = 2;
                    break;

                case LootQuality.Rare:
                    bonusDamage = 5;
                    break;

                case LootQuality.Epic:
                    bonusDamage = 10;
                    break;

                case LootQuality.Legendary:
                    bonusDamage = 20;
                    break;

                default:
                    break;
            }
            return bonusDamage;
        }

        public override string ToString()
        {
            return $"{Quality} {Type}: Damage {GetDamage()}";
        }
    }
}