namespace HotelManagementAPI.Interfaces
{
    public interface IRepo<k, T>
    {
        ICollection<T> GetAll();


        T Update(T item);
        T Delete(k key);

        T Add(T item);



    }
}
