using UnityEngine;

public interface ILocomotion
{
 
    Vector2 MoveDirection { get; }
    float MoveSpeed { get; }
    Rigidbody2D Rigidbody { get; }
    
    
}
