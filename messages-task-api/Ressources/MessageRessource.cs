namespace messages_task_api.Ressources
{
    public sealed record MessageResource(Guid Id,string SenderEmail, string Body);
    public sealed record PersistMessageResource(string SenderEmail, string Body,Guid UserId);
}
