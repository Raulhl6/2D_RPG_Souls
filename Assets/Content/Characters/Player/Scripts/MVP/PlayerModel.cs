using UnityEngine;

public class PlayerModel : IPlayerModel
{

    #region Constructor
    
    private MonoBehaviour _context;
    private PlayerData _playerData;
 
    private PlayerModel() { }

    public static IPlayerModel CreatePlayerModel(MonoBehaviour context, PlayerData data)
    {
        PlayerModel playerModel = new PlayerModel
        {
            _context = context,
            _playerData = data
        };

        playerModel.HealthController = PlayerHealth.CreatePlayerHealth(context, data);
        
        
        return playerModel;
    }
    
    #endregion
    
    public IHealth HealthController { get; set; }
    public ILocomotion LocomotionController { get; set; }

    public float MoveSpeed { get; private set; } = 5f;


    

    public void SetMoveSpeed(float speed)
    {
        MoveSpeed = Mathf.Clamp(speed, 0.1f, 20f);
    }

    
    
}
