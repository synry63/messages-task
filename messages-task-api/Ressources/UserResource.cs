namespace messages_task_api.Ressources
{
    public sealed record RegisterResource(string Email, string Password);
    public sealed record UserResource(Guid Id, string Email);
    public sealed record UserProfilResource(Guid Id, string Email,int TotalNotif);
    public sealed record UserNotificationResource(Guid UserId);

}
