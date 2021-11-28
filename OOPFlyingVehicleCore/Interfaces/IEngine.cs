namespace OOPFlyingVehicleCore.Interfaces
{
    public interface IEngine : IAboutable
    {
        bool IsStarted { get; set; }
        void Start();
        void Stop();
    }
}
