using UnityEngine;
using UnityEngine.Events;

public interface ILocomotion
{

    float MoveSpeed { get; }
    Rigidbody2D Rb { get; }
    bool IsGrounded { get; }
    
    void HandleMovement();
    void EnableMovementEvents();
    void DisableMovementEvents();
}
