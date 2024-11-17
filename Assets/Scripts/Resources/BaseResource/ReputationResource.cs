using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationResource : ResourceBase
{
    public override ResourceType Type => ResourceType.Wood;

    public ReputationResource(GameResources gameResources) : base(gameResources, gameResources.Wood) { }

    protected override void UpdateGameResources() => _gameResources.Reputation = Amount;
}
