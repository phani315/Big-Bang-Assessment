namespace BookingAPI.Interfaces
{
    public interface IRepo<k, T>
    {
        ICollection<T> GetAll();

        T Get(int id);
        T Update(T item);
        T Delete(k key);

        T Add(T item);



    }
}
