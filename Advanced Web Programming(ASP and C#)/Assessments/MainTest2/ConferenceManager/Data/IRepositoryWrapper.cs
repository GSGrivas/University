namespace ConferenceManager.Data
{
    public interface IRepositoryWrapper
    {
        IPaperRepository Paper { get; }
        ITopicRepository Topic { get; }
    }
}
