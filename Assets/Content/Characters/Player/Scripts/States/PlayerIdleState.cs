using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerController player) : base(player)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("Player Idle State");
    }

    public override void Update()
    {
        
    }

    public override void OnExit()
    {
        
    }
}
