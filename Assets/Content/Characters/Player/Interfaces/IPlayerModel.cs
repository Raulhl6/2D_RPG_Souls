
public interface IPlayerModel
{
    IHealth HealthController { get; set; }
    IPlayerLocomotion LocomotionController { get; set; }
    PlayerAnimatorController AnimationsController { get; set; }
    PlayerInputsReader InputsReader { get; set; }
}
