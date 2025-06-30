using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerController player) : base(player)
    {
    }

    public override void OnEnter()
    {
        player.Model.AnimationsController.PlayInstantAnimation(PlayerAnimatorController.IdleHash, 0);
    }

    public override void Update()
    {
        
    }

    public override void OnExit()
    {
        
    }
}
