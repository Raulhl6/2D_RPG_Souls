
public interface IPlayerModel
{
    IHealth HealthController { get; set; }
    float MoveSpeed { get; }

    void SetMoveSpeed(float speed);
}
