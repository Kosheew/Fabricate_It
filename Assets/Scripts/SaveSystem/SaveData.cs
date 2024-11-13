using System;
using System.Collections.Generic;

[Serializable] 
public class GameData
{
    public GameResources ResorcesData;
    public ProductionResources ProductionResourcesData;
    public UniqueResources UniqueResourcesData;
    public BuildData[] BuildsData;
}

[Serializable] 
public class GameResources
{
    public int Bonds;
    public int Coins;
    public int Oil;
    public int Coal;
    public int Ore;
    public int Wood;

    public List<IResource> ToResourceList()
    {
        return new List<IResource>
        {
            new BondResource(this),
            new CoinResource(this),
            new WoodResource(this),
            new OreResource(this),
            new CoalResource(this),
            new OilResource(this)
        };
    }
}

[Serializable]
public class ProductionResources
{
    public Factory factory;
    public WorkShop workShop;
}

[Serializable]
public class Factory
{
    public int Gears;
    public int Beams;
}

[Serializable]
public class WorkShop
{
    public int Steel;
    public int ProcessedWood;
}

[Serializable]
public class UniqueResources
{
    public int SteamEngine;
    public int Lamp;
    public int Kerasinka;
    public int Pump;
}

[Serializable]
public class BuildData
{
    public int IdBuilding;
    public int TimeBuilding;
    public string EndTimeBuilding;
    public string CurrentState;

    public int LevelBuild;

    public bool Bought;

    public SerializableVector3 BuildPosition;
}