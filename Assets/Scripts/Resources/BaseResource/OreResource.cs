public class OreResource : ResourceBase
{
    public override ResourceType Type => ResourceType.Ore;

    public OreResource(GameResources gameResources) : base(gameResources, gameResources.Ore) { }

    protected override void UpdateGameResources() => _gameResources.Ore = Amount;
}