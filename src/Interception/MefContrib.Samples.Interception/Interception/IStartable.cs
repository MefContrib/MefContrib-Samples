namespace MefContrib.Samples.Interception
{
    public interface IStartable
    {
        bool IsStarted { get; }

        void Start();
    }
}