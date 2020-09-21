using System.Collections.Generic;

namespace ZombieSlayerZ.Data
{
    public interface IRepository<T>
    {
        ICollection<T> GetAll();
    }
}