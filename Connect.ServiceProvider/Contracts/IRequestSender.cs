namespace Connect.ServiceProvider
{
    using System.Threading.Tasks;

    public interface IRequestSender<T>
    {
        Task<T> Get(T command);
        Task<T> Post(T command);
    }
}
