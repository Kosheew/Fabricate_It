public class OilResource : ResourceBase
{
    public override ResourceType Type => ResourceType.Oil;

    public OilResource(GameResources gameResources) : base(gameResources, gameResources.Oil) { }

    protected override void UpdateGameResources() => _gameResources.Oil = Amount;
}