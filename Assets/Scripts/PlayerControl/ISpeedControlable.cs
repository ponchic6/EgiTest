namespace PlayerControl
{
    public interface ISpeedControlable
    {
        public void SetBaseSpeed();
        public void IncreaseSpeed(float addingSpeed);
        public float CurrentSpeed { get; }
    }
}