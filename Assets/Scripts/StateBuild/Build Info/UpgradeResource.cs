using UnityEngine;

[CreateAssetMenu(fileName = "Build", menuName = "ScriptableObjects/Resource Upgrade")]
public class UpgradeResource : ScriptableObject
{
    [Header("Time")]
    [SerializeField] private int _temeBuild;

    [Header("Resources")]
    [SerializeField] private GameResources _upgradeResources;

    [Header("Income")]
    [SerializeField] private int _income;

    public int TimeBuild => _temeBuild;
    public int Income => _income;
    public GameResources UpgradeResources => _upgradeResources;

}
