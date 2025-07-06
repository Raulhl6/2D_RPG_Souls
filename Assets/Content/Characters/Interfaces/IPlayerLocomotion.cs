using UnityEngine;

public interface IPlayerLocomotion
{

    float MoveSpeed { get; }
    Rigidbody2D Rb { get; }
    GroundDetector GroundCheck { get; }
    
    void HandleMovement();
    void EnableMovementEvents();
    void DisableMovementEvents();
    void Jump(bool jumpButtonPressed);
}
