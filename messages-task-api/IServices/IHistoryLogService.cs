namespace messages_task_api.IServices
{
    public interface IHistoryLogService
    {
        void AddloginLog(Guid userId);
        void AddLogoutLog(Guid userId);
    }
}
