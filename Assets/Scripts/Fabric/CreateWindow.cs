using UnityEngine;
using UnityEngine.UI;

public class CreateWindow : MonoBehaviour
{
    [SerializeField] private Button _createDragonButton;
    [SerializeField] private Button _createGoblinButton;

    private EnemyFactory _enemyFactory;

    private void Awake()
    {
        _enemyFactory = new RedEnemyFactory();

        _createDragonButton.onClick.AddListener(() =>
        {
            CreateRedDragon();
        });
        _createGoblinButton.onClick.AddListener(() =>
        {
            CreateRedGoblin();
        });
    }

    private void CreateRedDragon()
    {
        var dragon = _enemyFactory.CreateDragon();
    }

    private void CreateRedGoblin()
    {
        var goblin = _enemyFactory.CreateGoblin();
    }
}

