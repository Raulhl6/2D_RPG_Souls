using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerController player) : base(player)
    {
    }

    public override void OnEnter()
    {
        player.Model.AnimationsController.PlayInstantAnimation(PlayerAnimatorController.RunHash, 0);
    }

    public override void Update()
    {
        
    }

    public override void OnExit()
    {
        
    }
}
