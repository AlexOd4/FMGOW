using UnityEngine;

public class LizardHealth : MonoBehaviour, IHealth
{
    public float maxHealth;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public bool Damage(float damage)
    {
        bool dead = false;
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            dead = true;
            currentHealth = 0;
            Death();
        }
        return dead;

    }
    public void Heal(float heal)
    {
        currentHealth += heal;
        if(currentHealth > maxHealth)
        {
            currentHealth=maxHealth;
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

}
