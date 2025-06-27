using UnityEngine;

public class PlayerStateMachine
{
    #region Constructor
    private PlayerStateMachine() {}

    public static PlayerStateMachine CreatePlayerStateMachine(PlayerManager player)
    {
        PlayerStateMachine stateMachine = new PlayerStateMachine();
        stateMachine.InitStateMachine(player);
        
        
        return stateMachine;
    }
    #endregion
    
    
    private StateMachine _stateMachine;

    private IState _idleState;
    private IState _moveState;

    private void InitStateMachine(PlayerManager player)
    {
        _stateMachine = new StateMachine();
        
        _idleState = new PlayerIdleState(player);
        _moveState = new PlayerMoveState(player);
        
        //At(_idleState, _moveState, new FuncPredicate(() => ));
        
        
        _stateMachine.SetState(_idleState);
    }

    public void Update()
    {
        _stateMachine.Update();
    }
    
    private void At(IState from,  IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);
    private void Any(IState to, IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);

    
    
}
