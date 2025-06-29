using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerController player) : base(player)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("Player Move State");
    }

    public override void Update()
    {
        
    }

    public override void OnExit()
    {
        
    }
}
