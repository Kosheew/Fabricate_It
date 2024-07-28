using UnityEngine;

public class PlayerModel 
{
    private const int minHealth = 0;
    private const int maxHealth = 100;

    public int CurrentHealth { get; private set; }

    public PlayerModel(int health)
    {
        CurrentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, minHealth, maxHealth);
    }
}
