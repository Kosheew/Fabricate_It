public class CoalResource : ResourceBase
{
    public override ResourceType Type => ResourceType.Coal;

    public CoalResource(GameResources gameResources) : base(gameResources, gameResources.Coal) { }

    protected override void UpdateGameResources() => _gameResources.Coal = Amount;
}