public interface IResource
{
    int Amount { get; set; }
    ResourceType Type { get; }
    void Add(int amount);
    void Subtract(int amount);
    bool HasEnough(int amount);
}
