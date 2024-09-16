using System;
using System.Collections.Generic;

[Serializable] 
public class GameData
{
    public Currency CurrencyData;
    public Resurces ResurcesData;
    public ProductionResources ProductionResourcesData;
    public UniqueResources UniqueResourcesData;
}

[Serializable]
public class Currency
{
    public int Bonds;
    public int Coins;
}

[Serializable] 
public class Resurces
{
    public int Oil;
    public int Ñoal;
    public int Ore;
    public int Tree;
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