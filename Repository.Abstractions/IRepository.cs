namespace Repository.Abstractions
{
    public interface IRepository<T>
    {

        T Get(int id);
    }
}