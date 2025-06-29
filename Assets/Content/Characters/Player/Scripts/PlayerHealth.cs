using UnityEngine;

public class PlayerHealth : CharacterHealth
{
    public static PlayerHealth CreatePlayerHealth(MonoBehaviour context, PlayerData playerData)
    {
        PlayerHealth playerHealth = context.GetComponent<PlayerHealth>();
        if (!playerHealth)
        {
            playerHealth = context.gameObject.AddComponent<PlayerHealth>();
        }
        playerHealth.InitHealth(playerData.health, playerData.maxHealth);
        
        return playerHealth;
    }
}
