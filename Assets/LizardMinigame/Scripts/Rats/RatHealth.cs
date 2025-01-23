using UnityEngine;

public class RatHealth : MonoBehaviour, IHealth
{
    public float maxHealth;
    private float currentHealth;
    private bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public bool Damage(float damage)
    {
        bool dead = false;
        if (!isDead) 
        {    
            currentHealth -= damage;
            //RatHordeManager.instance.DamageHorde(Mathf.CeilToInt(damage));
        }
        if (currentHealth <= 0)
        {
            dead = true;
            isDead = true;
            currentHealth = 0;
            Death();
        }
        return dead;

    }
    public void Heal(float heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Death()
    {
        GameManager.instance.AddPoint((int)maxHealth);
        Destroy(gameObject);
    }

}
