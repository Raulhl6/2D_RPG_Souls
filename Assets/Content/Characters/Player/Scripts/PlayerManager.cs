using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerData data;
    public IPlayerModel playerModel { get; private set; }
    
    private PlayerStateMachine _stateMachine;
    
    private void Awake()
    {
        _stateMachine = PlayerStateMachine.CreatePlayerStateMachine(this);
    }

    private void Start()
    {
        playerModel = PlayerModel.CreatePlayerModel(this, data);

    }

    private void Update()
    {
        _stateMachine.Update();
    }

    
}