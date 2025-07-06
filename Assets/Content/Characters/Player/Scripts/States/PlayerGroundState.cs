using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(PlayerController player) : base(player)
    {
    }
    
    private bool _isRunning;

    public override void OnEnter()
    {
        ApplyGroundInitAnimation();
        player.Model.InputsReader.OnJumpEvent += player.Model.LocomotionController.Jump;
    }

    public override void Update()
    {
        HandleGroundState();
    }

    public override void FixedUpdate()
    {
        player.Model.LocomotionController.HandleMovement();
    }

    public override void OnExit()
    {
        player.Model.InputsReader.OnJumpEvent -= player.Model.LocomotionController.Jump;
    }

    private void HandleGroundState()
    {
        if (player.Model.InputsReader.MoveDirection.x == 0)
        {
            if (_isRunning)
            {
                player.Model.AnimationsController.PlayInstantAnimation(PlayerAnimatorController.IdleHash, 0);
                _isRunning = false;
            }
            
        }
        else
        {
            if (!_isRunning)
            {
                player.Model.AnimationsController.PlayInstantAnimation(PlayerAnimatorController.RunHash, 0);
                _isRunning = true;
            }
            
        }
    }

    private void ApplyGroundInitAnimation()
    {
        _isRunning = player.Model.InputsReader.MoveDirection.x != 0;

        player.Model.AnimationsController.PlayInstantAnimation(
            _isRunning ? PlayerAnimatorController.RunHash : PlayerAnimatorController.IdleHash, 0);
    }
}
