using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [Header("STATS")]
    [Space(10)]
    
    [Header("HP")]
    public int health = 100;
    public int maxHealth = 100;
}