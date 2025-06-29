using UnityEngine;

public class PlayerLocomotion : ILocomotion
{

    #region Constructor

    private PlayerLocomotion() {}

    public static PlayerLocomotion CreatePlayerLocomotion(Rigidbody2D rigidbody)
    {
        PlayerLocomotion playerLocomotion = new PlayerLocomotion()
        {
            Rigidbody = rigidbody
        };
        
        
        
        return playerLocomotion;
    }

    #endregion

    public Vector2 MoveDirection  => PlayerInputsReader.Instance.MoveDirection;
    public float MoveSpeed { get; }
    public Rigidbody2D Rigidbody { get; private set; }
    
}
