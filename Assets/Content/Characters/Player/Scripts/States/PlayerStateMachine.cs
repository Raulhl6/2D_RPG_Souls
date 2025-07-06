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
    private IPlayerLocomotion PlayerIPlayerLocomotionController => _player.Model.LocomotionController;
    private StateMachine _stateMachine;

    // States
    private IState _groundState;
    private IState _airState;

    private void InitStateMachine()
    {
        _stateMachine = new StateMachine();
        
        _groundState = new PlayerGroundState(_player);
        _airState = new PlayerAirState(_player);


        At(_groundState, _airState, new FuncPredicate(IsInAir));
        At(_airState, _groundState, new FuncPredicate(() => !IsInAir()));

        
        
        _stateMachine.SetState(_groundState);
    }

    public void Update()
    {
        _stateMachine.Update();
    }

    public void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }
    
    private void At(IState from,  IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);
    private void Any(IState to, IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);
    
    private bool IsInAir() => !PlayerIPlayerLocomotionController.GroundCheck.IsGrounded;


}
