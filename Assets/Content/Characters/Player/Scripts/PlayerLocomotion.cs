using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLocomotion : IPlayerLocomotion
{

    #region Constructor

    private PlayerLocomotion() {}

    public static PlayerLocomotion CreatePlayerLocomotion(MonoBehaviour context, PlayerData data, PlayerInputsReader inputsReader)
    {
        if (!context) return null;
        
        PlayerLocomotion playerLocomotion = new PlayerLocomotion();
        
        Rigidbody2D rb = context.GetComponent<Rigidbody2D>();
        playerLocomotion.Rb = rb ? rb : context.AddComponent<Rigidbody2D>();
        playerLocomotion.GroundCheck = context.GetComponentInChildren<GroundDetector>();
        playerLocomotion.MoveSpeed = data.speed;
        playerLocomotion._playerTransform = context.transform;
        playerLocomotion._inputsReader = inputsReader;
        
        return playerLocomotion;
    }

    #endregion
    
    public float MoveSpeed { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public GroundDetector GroundCheck { get; private set; }
    public bool IsGrounded { get; private set; } = true;
    
    private PlayerInputsReader _inputsReader;
    private Transform _playerTransform;
    private Vector2 _velocity = Vector2.zero;
    private Vector3 _localScale = Vector3.one;
    
    public void HandleMovement()
    {
        _velocity.x = _inputsReader.MoveDirection.x * (MoveSpeed * Time.fixedDeltaTime);
        _velocity.y = Rb.linearVelocity.y;
        Rb.linearVelocity = _velocity;
    }

    public void EnableMovementEvents()
    {
        _inputsReader.OnMoveEvent += LookSpriteRight;
        
    }

    public void DisableMovementEvents()
    {
        _inputsReader.OnMoveEvent -= LookSpriteRight;
    }

    public void Jump(bool jumpButtonPressed)
    {
        Rb.AddForce(Vector2.up * (jumpButtonPressed ? 1000 : 0));
        
        // TODO: DELETE THIS
        IsGrounded = false;
        
    }

    private void LookSpriteRight(bool isRight)
    {
        _localScale = _playerTransform.localScale;
        _localScale.x = isRight ? Mathf.Abs(_playerTransform.localScale.x)  : -Mathf.Abs(_playerTransform.localScale.x);
        _playerTransform.localScale = _localScale;
    }
}
