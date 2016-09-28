namespace Connect.ServiceProvider
{
    public interface IServiceProvider<T>
    {   
        T Handle(T command);
    }
}
