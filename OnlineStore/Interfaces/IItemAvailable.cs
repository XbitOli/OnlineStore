namespace OnlineStore
{
    public interface IItemAvailable
    {
        bool IsAvailable(Good good, int amount);
    }
}