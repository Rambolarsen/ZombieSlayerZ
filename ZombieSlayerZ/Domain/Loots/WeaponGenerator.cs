using System;
using System.Collections.Generic;
using System.Linq;
using ZombieSlayerZ.Data;

namespace ZombieSlayerZ.Domain.Loots
{
    public class WeaponGenerator : ILootGenerator<Weapon>
    {
        private readonly Random _random;
        private readonly List<WeaponType> _weaponTypes;

        public WeaponGenerator(IRepository<WeaponType> weaponTypeRepository)
        {
            _weaponTypes = weaponTypeRepository.GetAll().ToList();
            _random = new Random();
        }

        public Weapon GenerateLoot(int level)
        {
            WeaponType weaponType = GetWeaponType();
            if (weaponType == null)
                return null;
            LootQuality lootQuality = GetLootQualityForWeapon();
            return new Weapon(weaponType, lootQuality, level);
        }

        private WeaponType GetWeaponType()
        {
            var index = _random.Next(_weaponTypes.Count + 5);
            if (index >= _weaponTypes.Count)
                return null;

            var weaponType = _weaponTypes[index];
            return weaponType;
        }

        private LootQuality GetLootQualityForWeapon()
        {
            var rarityRoll = _random.Next(1, 100);

            if (rarityRoll == 100)
                return LootQuality.Legendary;
            if (rarityRoll > 90)
                return LootQuality.Epic;
            if (rarityRoll > 75)
                return LootQuality.Rare;
            if (rarityRoll > 50)
                return LootQuality.Uncommon;

            return LootQuality.Common;
        }
    }

    public class WeaponType
    {
        public WeaponType(string name, double baseMultiplier)
        {
            Name = name;
            BaseMultiplier = baseMultiplier;
        }

        public string Name { get; private set; }

        public double BaseMultiplier { get; private set; }

        public override string ToString() => Name;
    }
}