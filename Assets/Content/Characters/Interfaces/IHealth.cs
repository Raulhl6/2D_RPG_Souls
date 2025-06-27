using UnityEngine;
using UnityEngine.Events;

public interface IHealth
{
    // Events
    UnityEvent OnTakeDamage { get; }
    UnityEvent OnHeal { get; }
    UnityEvent OnDeath { get; }
    
    // Properties
    int CurrentHealth { get; }
    int MaxHealth { get; }
    bool IsDead { get; }

    // Methods
    void InitHealth(int health, int maxHealth);
    void TakeDamage(int amount);
    void Heal(int amount);
}
