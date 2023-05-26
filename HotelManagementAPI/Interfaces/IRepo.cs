namespace HotelManagementAPI.Interfaces
{
    public interface IRepo<k, T>
    {
        ICollection<T> GetAll();

        T Get(k key);


    }
}
