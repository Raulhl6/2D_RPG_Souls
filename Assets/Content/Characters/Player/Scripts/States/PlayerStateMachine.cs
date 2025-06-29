using UnityEngine;

public class PlayerStateMachine
{
    #region Constructor
    private PlayerStateMachine() {}

    public static PlayerStateMachine CreatePlayerStateMachine(PlayerController player)
    {
        PlayerStateMachine stateMachine = new PlayerStateMachine();
        stateMachine.InitStateMachine(player);
        
        
        return stateMachine;
    }
    #endregion
    
    
    private StateMachine _stateMachine;

    private IState _idleState;
    private IState _moveState;

    private void InitStateMachine(PlayerController player)
    {
        _stateMachine = new StateMachine();
        
        _idleState = new PlayerIdleState(player);
        _moveState = new PlayerMoveState(player);
        
        // TODO: Ponerlo en funcion a parte para tener en cuenta la y
        At(_idleState, _moveState, new FuncPredicate(() => player.playerModel.LocomotionController.MoveDirection.x > 0f));
        At(_moveState, _idleState, new FuncPredicate(() => player.playerModel.LocomotionController.MoveDirection.x <= 0f));
        
        
        _stateMachine.SetState(_idleState);
    }

    public void Update()
    {
        _stateMachine.Update();
    }
    
    private void At(IState from,  IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);
    private void Any(IState to, IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);

    
    
}
