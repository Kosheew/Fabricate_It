using UnityEngine;

public class RedEnemyFactory : EnemyFactory
{
    public override Dragon CreateDragon()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/DragonRed");
        var onj = GameObject.Instantiate(prefab);
        var dragon = onj.AddComponent<DragonRed>();

        return dragon;
    }

    public override Goblin CreateGoblin()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/GoblinRed");
        var onj = GameObject.Instantiate(prefab);
        var goblin = onj.AddComponent<GoblinRed>();

        return goblin;
    }
}

