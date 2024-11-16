public class BondResource : ResourceBase
{
    public override ResourceType Type => ResourceType.Bond;

    public BondResource(GameResources gameResources) : base(gameResources, gameResources.Bonds) { }

    protected override void UpdateGameResources() => _gameResources.Bonds = Amount;
}