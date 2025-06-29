using UnityEngine;

public class PlayerBaseState : IState
{
    protected readonly PlayerController player;


    protected PlayerBaseState(PlayerController player) 
    {
        this.player = player;
    }

    public virtual void OnEnter()
    {
        // noop
    }

    public virtual void Update()
    {
        // noop
    }

    public virtual void FixedUpdate()
    {
        // noop
    }

    public virtual void OnExit()
    {
        // noop
    }

    
}
