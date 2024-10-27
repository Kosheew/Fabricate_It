using System;
using UnityEngine;

[CreateAssetMenu(fileName ="Build", menuName = "ScriptableObjects/Build")]
public class BuildSettings : ScriptableObject
{
    [Header("Mesh Building")]
    [SerializeField] private Mesh _meshUnderConstruction;
    [SerializeField] private Mesh _meshBuilding;
    [SerializeField] private Mesh _meshDestroyed;

    [Header("Cost Building Construction")]
    [SerializeField] private BuildCost[] _costPriceLevel;
    [SerializeField] private BuildResources[] _buildResources;
    public Mesh MeshUnderConstrucrion => _meshUnderConstruction;
    public Mesh MeshBuilding => _meshBuilding;
    public Mesh MeshDestroyed => _meshDestroyed;
    public BuildCost[] CostPriceLevel => _costPriceLevel;
    public BuildResources[] BuildResources => _buildResources;
}

[Serializable]
public class BuildCost
{
    public float TimeBuild;
    public int Coins;
    public int Bonds;
}

[Serializable]
public class BuildResources
{  
    public int Oil;
    public int Coal;
    public int Ore;
    public int Tree;
}