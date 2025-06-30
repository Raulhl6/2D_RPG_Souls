using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData data;
    public IPlayerModel Model { get; private set; }
    
    private PlayerStateMachine _stateMachine;
    
    private void Awake()
    {
        Model = PlayerModel.CreatePlayerModel(this, data);
        _stateMachine = PlayerStateMachine.CreatePlayerStateMachine(this);
    }

    private void Start()
    {
        

    }

    private void Update()
    {
        _stateMachine.Update();
        Model.AnimationsController.UpdateMovementParameters(Model.LocomotionController.MoveDirection);
        Model.LocomotionController.HandleMovement();
    }

    
}