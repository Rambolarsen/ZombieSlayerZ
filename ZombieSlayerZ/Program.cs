using Autofac;
using System;
using ZombieSlayerZ.Data;
using ZombieSlayerZ.Domain;
using ZombieSlayerZ.Domain.Loots;
using ZombieSlayerZ.Domain.Spawners;

namespace ZombieSlayerZ
{
    internal class Program
    {
        private static IContainer Container { get; set; }
        private static IGameManager _gameManager;

        private static void Main(string[] args)
        {
            RegisterAssemblyTypes();

            using var scope = Container.BeginLifetimeScope();
            _gameManager = scope.Resolve<IGameManager>();

            while (_gameManager.PlayerIsAlive())
            {
                _gameManager.StartRound();
                //spawn round logic
                _gameManager.Spawn();
                //display current stats
                Console.WriteLine(_gameManager.DisplayCurrentStats());
                //select action
                DisplayActions();

                GameAction action = GetGameActionFromConsole(Console.ReadLine());

                //run action logic
                switch (action)
                {
                    case GameAction.Search:
                        Console.WriteLine("Searching for loot...");
                        var loot = _gameManager.GetLoot();
                        Console.WriteLine(loot.ToString());
                        if (loot.Weapon != null)
                        {
                            Console.WriteLine("Equip the weapon?(y/n): ");
                            var equip = Console.ReadLine();
                            if (equip.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                                _gameManager.EquipWeapon(loot.Weapon);
                        }
                        else
                        {
                            Console.ReadLine();
                        }
                        break;

                    case GameAction.Fight:
                        //Check for zombies to fight.
                        //fight zombies.

                        break;

                    case GameAction.Run:
                        Console.WriteLine("You ran away!");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            }
        }

        private static void RegisterAssemblyTypes()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GameManager>().As<IGameManager>();
            builder.RegisterType<LootSpawner>().As<ILootSpawner>();
            builder.RegisterType<ZombieSpawner>().As<IZombieSpawner>();
            builder.RegisterType<WeaponGenerator>().As<ILootGenerator<Weapon>>();
            builder.RegisterType<WeaponTypeRepository>().As<IRepository<WeaponType>>();

            Container = builder.Build();
        }

        private static GameAction GetGameActionFromConsole(string action)
        {
            if (Enum.TryParse<GameAction>(action, out var gameAction))
                return gameAction;

            Console.Clear();
            Console.WriteLine(_gameManager.DisplayCurrentStats());
            DisplayActions();
            Console.WriteLine("Invalid action!");
            return GetGameActionFromConsole(Console.ReadLine());
        }

        private static void DisplayActions()
        {
            Console.WriteLine("Select action:");
            Console.WriteLine("1.Search for loot.");
            Console.WriteLine("2.Use consumable.");
            Console.WriteLine("3.Fight nearby zombies.");
            Console.WriteLine("4.Run!");
        }
    }

    public enum GameAction
    {
        Search = 1,
        UseConsumable = 2,
        Fight = 3,
        Run = 4
    }
}