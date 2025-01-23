using UnityEngine;

public interface IHealth
{
    public bool Damage(float damage);
    public void Heal(float heal);

    public void Death();
}
