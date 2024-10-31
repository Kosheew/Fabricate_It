using UnityEngine;

[CreateAssetMenu(fileName = "Build", menuName = "ScriptableObjects/Resource Upgrade")]
public class UpgradeResource : ScriptableObject
{
    [Header("Time")]
    [SerializeField] private double _temeBuild;

    [Header("Paymant")]
    [SerializeField] private int _coins;
    [SerializeField] private int _bonds;

    [Header("Resources")]
    [SerializeField] private int _oil;
    [SerializeField] private int _coal;
    [SerializeField] private int _ore;
    [SerializeField] private int _wood;

    [Header("Income")]
    [SerializeField] private int _income;
    public double TimeBuild => _temeBuild;
    public int Coins => _coins;
    public int Bonds => _bonds;
    public int Oil => _oil;
    public int Coal => _coal;
    public int Ore => _ore;
    public int Wood => _wood;
    public int Income => _income;
}
