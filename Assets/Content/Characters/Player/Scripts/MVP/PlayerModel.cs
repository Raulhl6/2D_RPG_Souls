using UnityEngine;

public class PlayerModel : IPlayerModel
{

    #region Constructor
    private PlayerModel() { }

    public static IPlayerModel CreatePlayerModel(MonoBehaviour context, PlayerData data)
    {
        PlayerModel playerModel = new PlayerModel
        {
            InputsReader = PlayerInputsReader.CreatePlayerInputsReader(),
            HealthController = PlayerHealth.CreatePlayerHealth(context, data),
            AnimationsController = PlayerAnimatorController.CreatePlayerAnimatorController(context)
        };
        
        playerModel.LocomotionController = PlayerLocomotion.CreatePlayerLocomotion(context, data, playerModel.InputsReader);

        return playerModel;
    }
    
    #endregion
    
    public IHealth HealthController { get; set; }
    public ILocomotion LocomotionController { get; set; }
    public PlayerAnimatorController AnimationsController { get; set; }
    public PlayerInputsReader InputsReader { get; set; }
}
