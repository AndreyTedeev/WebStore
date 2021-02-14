using WebStore.Entities;

namespace WebStore.Interfaces
{
    public interface ICartService
    {
        void Add(int id);

        void Remove(int id);

        void Decrement(int id);

        void Clear();

        Cart Cart { get; }

    }
}
