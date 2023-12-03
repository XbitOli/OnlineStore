namespace OnlineStore
{
    public interface IItemTakeable : IItemAvailable
    {
        void Remove(Good good, int amount);
    }
}