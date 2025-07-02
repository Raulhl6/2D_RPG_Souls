
public interface IPlayerModel
{
    IHealth HealthController { get; set; }
    ILocomotion LocomotionController { get; set; }
    PlayerAnimatorController AnimationsController { get; set; }
    PlayerInputsReader InputsReader { get; set; }
}
