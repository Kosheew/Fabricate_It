public class CoinResource : ResourceBase
{
    public override ResourceType Type => ResourceType.Coin;

    public CoinResource(GameResources gameResources) : base(gameResources, gameResources.Coins) { }

    protected override void UpdateGameResources() => _gameResources.Coins = Amount;
}