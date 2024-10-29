using UnityEngine;

[CreateAssetMenu(fileName = "Build", menuName = "ScriptableObjects/Resource Upgrade")]
public class UpgradeResource : ScriptableObject
{
    [SerializeField] private double _temeBuild;
    [SerializeField] private int _coins;
    [SerializeField] private int _bonds;
    [SerializeField] private int _oil;
    [SerializeField] private int _coal;
    [SerializeField] private int _ore;
    [SerializeField] private int _wood;

    public double TimeBuild => _temeBuild;
    public int Coins => _coins;
    public int Bonds => _bonds;
    public int Oil => _oil;
    public int Coal => _coal;
    public int Ore => _ore;
    public int Wood => _wood;
}
