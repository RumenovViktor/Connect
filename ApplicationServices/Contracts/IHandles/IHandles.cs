using Models;

namespace ApplicationServices
{
    public interface IHandles<T> where T : ICommand
    {
        T Execute(T command);
    }
}
