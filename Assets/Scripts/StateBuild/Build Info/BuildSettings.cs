using System;
using UnityEngine;

[CreateAssetMenu(fileName ="Build", menuName = "ScriptableObjects/Build")]
public class BuildSettings : ScriptableObject
{
    [Header("Type Build")]
    [SerializeField] private BuildTypes _buildTypes;

    [Header("Index Build")]
    [SerializeField] private int _index;

    [Header("Mesh Building")]
    [SerializeField] private Mesh _meshUnderConstruction;
    [SerializeField] private Mesh _meshBuilding;
    [SerializeField] private Mesh _meshDestroyed;

    [Header("Construction Materials")]
    [SerializeField] private Material _underConstructionMaterial;
    [SerializeField] private Material _buildingMaterial;
    [SerializeField] private Material _destroyedMaterial;
    [SerializeField] private Material _placmentMaterial;
    [SerializeField] private Material _gexMaterial;

    [Header("Cost Building Construction")]
    [SerializeField] private UpgradeResource[] _leveResources;
    public Mesh MeshUnderConstrucrion => _meshUnderConstruction;
    public Mesh MeshBuilding => _meshBuilding;
    public Mesh MeshDestroyed => _meshDestroyed;

    public Material UnderConstructionMaterial => _underConstructionMaterial;
    public Material BuildingMaterial => _buildingMaterial;
    public Material DestroyedMaterial => _destroyedMaterial;
    public Material PlacmentMaterial => _placmentMaterial;
    public Material GexMaterial => _gexMaterial;

    public int Index => _index;
    public UpgradeResource[] LeveResources => _leveResources;
    public BuildTypes BuildTypes => _buildTypes;
}