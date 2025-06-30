using UnityEngine;

public class PlayerModel : IPlayerModel
{

    #region Constructor
    private PlayerModel() { }

    public static IPlayerModel CreatePlayerModel(MonoBehaviour context, PlayerData data)
    {
        PlayerModel playerModel = new PlayerModel
        {
            HealthController = PlayerHealth.CreatePlayerHealth(context, data),
            LocomotionController = PlayerLocomotion.CreatePlayerLocomotion(context, data),
            AnimationsController = PlayerAnimatorController.CreatePlayerAnimatorController(context)
        };

        return playerModel;
    }
    
    #endregion
    
    public IHealth HealthController { get; set; }
    public ILocomotion LocomotionController { get; set; }
    public PlayerAnimatorController AnimationsController { get; set; }
}
