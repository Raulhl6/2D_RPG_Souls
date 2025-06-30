using Unity.VisualScripting;
using UnityEngine;

public class PlayerLocomotion : ILocomotion
{

    #region Constructor

    private PlayerLocomotion() {}

    public static PlayerLocomotion CreatePlayerLocomotion(MonoBehaviour context, PlayerData data)
    {
        if (!context) return null;
        
        PlayerLocomotion playerLocomotion = new PlayerLocomotion();
        
        Rigidbody2D rb = context.GetComponent<Rigidbody2D>();
        playerLocomotion.Rb = rb ? rb : context.AddComponent<Rigidbody2D>();
        playerLocomotion.MoveSpeed = data.speed;
        
        return playerLocomotion;
    }

    #endregion

    public Vector2 MoveDirection  => PlayerInputsReader.Instance.MoveDirection;
    public float MoveSpeed { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public bool IsGrounded { get; } = true;
    public void HandleMovement()
    {
        Rb.linearVelocity = MoveDirection * MoveSpeed * Time.fixedDeltaTime;
    }
}
