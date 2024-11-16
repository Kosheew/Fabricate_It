public class WoodResource : ResourceBase
{
    public override ResourceType Type => ResourceType.Wood;

    public WoodResource(GameResources gameResources) : base(gameResources, gameResources.Wood) { }

    protected override void UpdateGameResources() => _gameResources.Wood = Amount;
}