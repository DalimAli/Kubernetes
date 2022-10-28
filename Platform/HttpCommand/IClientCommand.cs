namespace Platform.HttpCommand
{
    public interface IClientCommand
    {
         Task Post(string message);
    }
}