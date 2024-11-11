using UnityEngine;

[CreateAssetMenu(fileName = "Build", menuName = "ScriptableObjects/Resource Upgrade")]
public class UpgradeResource : ScriptableObject
{
    [Header("Time")]
    [SerializeField] private double _temeBuild;

    [Header("Resources")]
    [SerializeField] private GameResources _upgradeResources;

    [Header("Income")]
    [SerializeField] private int _income;

    public double TimeBuild => _temeBuild;
    public int Income => _income;
    public GameResources UpgradeResources => _upgradeResources;

}
