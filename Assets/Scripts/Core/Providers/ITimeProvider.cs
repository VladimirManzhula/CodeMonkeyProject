namespace Core.Providers
{
    public interface ITimeProvider
    {
        float DeltaTime { get; }
    }
}