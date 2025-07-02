
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputsReader : PlayerInputActions.IPlayerActions
{
    
    public event UnityAction<bool> OnMove = delegate { };
    public Vector2 MoveDirection { get; private set; }
    
    private PlayerInputActions _playerInputActions;
    
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
                        OnMove.Invoke(true);
                        break;
                    case < 0:
                        OnMove.Invoke(false);
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
    
}
