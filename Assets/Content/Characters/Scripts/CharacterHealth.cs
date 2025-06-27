using UnityEngine;
using UnityEngine.Events;

public abstract class CharacterHealth : MonoBehaviour, IHealth
{
    public UnityEvent OnTakeDamage { get; } = new UnityEvent();
    public UnityEvent OnHeal { get; } = new UnityEvent();
    public UnityEvent OnDeath { get; } = new UnityEvent();
    public int CurrentHealth { get; private set; }
    public int MaxHealth { get; private set; }
    public bool IsDead => CurrentHealth <= 0;


    public void InitHealth(int health, int maxHealth)
    {
        CurrentHealth = health;
        MaxHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);

        if (CurrentHealth <= 0)
        {
            OnDeath.Invoke();
        }
        else
        {
            OnTakeDamage.Invoke();
        }
    }
    public void Heal(int amount)
    {
        CurrentHealth = Mathf.Max(MaxHealth, CurrentHealth + amount);
        OnHeal.Invoke();
    }
}
