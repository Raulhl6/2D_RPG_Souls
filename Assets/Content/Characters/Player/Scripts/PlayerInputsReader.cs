
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputsReader : PlayerInputActions.IPlayerActions
{

    #region Construct

    private PlayerInputsReader() {}

    public static PlayerInputsReader CreatePlayerInputsReader()
    {
        PlayerInputsReader inputsReader = new PlayerInputsReader
        {
            _playerInputActions = new PlayerInputActions()
        };

        inputsReader._playerInputActions.Player.SetCallbacks(inputsReader);
        
        return inputsReader;
    }

    #endregion

    
    #region Events
    public event UnityAction<bool> OnMoveEvent = delegate { };
    public event UnityAction<bool> OnJumpEvent = delegate { };

    #endregion
    

    #region InputAction
    private PlayerInputActions _playerInputActions;
    public Vector2 MoveDirection { get; private set; }
    
    public void EnableInputs() => _playerInputActions.Enable();
    public void DisableInputs() => _playerInputActions.Disable();
    public void OnMovement(InputAction.CallbackContext context)
    {

        switch (context.phase)
        {
            case InputActionPhase.Started:
                MoveDirection = context.ReadValue<Vector2>();
                switch (MoveDirection.x)
                {
                    case > 0:
                        OnMoveEvent.Invoke(true);
                        break;
                    case < 0:
                        OnMoveEvent.Invoke(false);
                        break;
                }
                break;
            case InputActionPhase.Performed:
                MoveDirection = context.ReadValue<Vector2>();
                break;
            case InputActionPhase.Canceled:
                MoveDirection = Vector2.zero;
                break;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            OnJumpEvent.Invoke(true);
        }
    }
    #endregion
    
}
