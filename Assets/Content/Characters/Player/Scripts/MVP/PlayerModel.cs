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
        
        playerModel.InitHealthController();
        
        return playerModel;
    }

    
    #endregion
    
    
    #region Health
    public IHealth HealthController { get; set; }

    private void InitHealthController()
    {
        HealthController = _context.GetComponent<IHealth>();
        HealthController.InitHealth(_playerData.health, _playerData.maxHealth);
    }

    #endregion


    
    public float MoveSpeed { get; private set; } = 5f;


    

    public void SetMoveSpeed(float speed)
    {
        MoveSpeed = Mathf.Clamp(speed, 0.1f, 20f);
    }

    
    
}
