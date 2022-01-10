using Models;

namespace Data.Interfaces
{
    public interface ICluster<T>
    {
        public T Get(GetMessage model);
    }
}
