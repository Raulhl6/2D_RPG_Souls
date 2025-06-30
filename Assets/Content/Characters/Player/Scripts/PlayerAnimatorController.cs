using UnityEngine;

public class PlayerAnimatorController : CharacterAnimatorControllerBase
{

    public static readonly int IdleHash = Animator.StringToHash("PlayerIdle");
    public static readonly int RunHash = Animator.StringToHash("PlayerRun");
    
    public static PlayerAnimatorController CreatePlayerAnimatorController(MonoBehaviour context)
    {
        PlayerAnimatorController controller = new PlayerAnimatorController()
        {
            _animator = context.GetComponentInChildren<Animator>()
        };
        
        

        return controller;
    }
    
    
}
