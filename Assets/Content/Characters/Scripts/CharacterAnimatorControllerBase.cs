using UnityEngine;

public abstract class CharacterAnimatorControllerBase
{
    
    protected CharacterAnimatorControllerBase() {}

    protected Animator _animator;

    private static readonly int XVelocity = Animator.StringToHash("xVelocity");
    private static readonly int YVelocity = Animator.StringToHash("yVelocity");

    public virtual void UpdateMovementParameters(Vector2 movement)
    {
        _animator.SetFloat(XVelocity, movement.x, 0.1f, Time.deltaTime);
        _animator.SetFloat(YVelocity, movement.y, 0.1f, Time.deltaTime);
    }

    public void PlayInstantAnimation(int hash, int layer)
    {
        _animator.Play(hash, layer, 0f);
    }

    public void PlayCrossAnimation(int hash, int layer, float transitionDuration = 0.2f)
    {
        _animator.CrossFade(hash, transitionDuration, layer);
    }

}
