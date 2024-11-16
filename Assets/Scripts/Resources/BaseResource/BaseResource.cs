public abstract class ResourceBase : IResource
{
    protected GameResources _gameResources;
    public int Amount { get; set; }
    public abstract ResourceType Type { get; }

    public ResourceBase(GameResources gameResources, int amount)
    {
        _gameResources = gameResources;
        Amount = amount;
    }

    public void Add(int amount)
    {
        Amount += amount;
        UpdateGameResources();
    }

    public void Subtract(int amount)
    {
        if (HasEnough(amount))
        {
            Amount -= amount;
            UpdateGameResources();
        }
    }

    public bool HasEnough(int amount) => Amount >= amount;

    protected abstract void UpdateGameResources(); 
}