using System.Collections.Generic;

namespace QlikBar.SDK.DotNet40
{
    public interface IRepository<T> : ICollection<T>
        where T : class
    {
        void Remove(int value);

        void Update(T value);

        T Get(int id);
    }
}