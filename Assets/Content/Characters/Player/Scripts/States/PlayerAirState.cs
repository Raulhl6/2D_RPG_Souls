using UnityEngine;

public class PlayerAirState : PlayerBaseState
{
    public PlayerAirState(PlayerController player) : base(player)
    {
    }

    private bool _isFalling;

    public override void OnEnter()
    {
        _isFalling = player.Model.LocomotionController.Rb.linearVelocity.y < 0;
        player.Model.AnimationsController.PlayInstantAnimation(
            _isFalling ? PlayerAnimatorController.FallingHash : PlayerAnimatorController.JumpHash, 0);
    }

    public override void Update()
    {
        HandleAirState();
        
    }

    public override void FixedUpdate()
    {
        player.Model.LocomotionController.HandleMovement();
    }

    public override void OnExit()
    {
        
    }

    private void HandleAirState()
    {
        if (player.Model.LocomotionController.Rb.linearVelocity.y >= 0)
        {
            if (_isFalling)
            {
                player.Model.AnimationsController.PlayInstantAnimation(PlayerAnimatorController.JumpHash, 0);
                _isFalling = false;
            }
        }
        else
        {
            if (!_isFalling)
            {
                player.Model.AnimationsController.PlayInstantAnimation(PlayerAnimatorController.FallingHash, 0);
                _isFalling = true;
            }
        }
    }
}
