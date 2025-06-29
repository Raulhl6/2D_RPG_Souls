using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputsReader : MonoBehaviour, PlayerInputActions.IPlayerActions
{
    
    #region Singleton
    public static PlayerInputsReader Instance { get; private set; }

    private void InitSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion


    #region Unity Methods

    private void Awake()
    {
        InitSingleton();
        InitPlayerInputActions();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        _playerInputActions.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Disable();
    }

    #endregion


    #region Input Actions

    private PlayerInputActions _playerInputActions;

    private void InitPlayerInputActions()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.SetCallbacks(this);
    }

    #endregion


    #region Events
    

    public Vector2 MoveDirection { get; private set; }
    
    public void OnMovement(InputAction.CallbackContext context)
    {

        switch (context.phase)
        {
            case InputActionPhase.Performed:
                MoveDirection = context.ReadValue<Vector2>();
                break;
            case InputActionPhase.Canceled:
                MoveDirection = Vector2.zero;
                break;
        }
    }
    #endregion
    
}
