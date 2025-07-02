using UnityEngine;

public class PlayerStateMachine
{
    #region Constructor
    private PlayerStateMachine() {}

    public static PlayerStateMachine CreatePlayerStateMachine(PlayerController player)
    {
        PlayerStateMachine stateMachine = new PlayerStateMachine()
        {
            _player = player
        };
        
        stateMachine.InitStateMachine();
        
        
        return stateMachine;
    }
    #endregion
    
    private PlayerController _player;
    private ILocomotion PlayerLocomotionController => _player.Model.LocomotionController;
    private StateMachine _stateMachine;

    // States
    private IState _idleState;
    private IState _moveState;

    private void InitStateMachine()
    {
        _stateMachine = new StateMachine();
        
        _idleState = new PlayerIdleState(_player);
        _moveState = new PlayerMoveState(_player);
        

        At(_idleState, _moveState, new FuncPredicate(() => !IsStopped()));
        At(_moveState, _idleState, new FuncPredicate(IsStopped));
        
        
        _stateMachine.SetState(_idleState);
    }

    public void Update()
    {
        _stateMachine.Update();
    }
    
    private void At(IState from,  IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);
    private void Any(IState to, IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);

    private bool IsStopped() => PlayerLocomotionController.IsGrounded && _player.Model.InputsReader.MoveDirection.x == 0f;



}
