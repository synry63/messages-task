using messages_task_api.IServices;
using messages_task_api.Models;

namespace messages_task_api.Services
{
    public sealed class HistoryLogService : IHistoryLogService
    {
        private readonly MessagesTaskContext _context;

        private enum HistoryLogsType
        {
            LOGIN = 1,
            LOGOUT = 2,
        }

        public HistoryLogService(MessagesTaskContext context)
        {
            _context = context;

        }
        public void AddloginLog(Guid userId)
        {
            var log = new HistoryLog { 
                DateCreated= DateTime.Now,
                UserId = userId,
                TypeLog = (int)HistoryLogsType.LOGIN
            };
            _context.HistoryLogs.Add(log);
            _context.SaveChanges();
        }

        public void AddLogoutLog(Guid userId)
        {
            var log = new HistoryLog
            {
                DateCreated = DateTime.Now,
                UserId = userId,
                TypeLog = (int)HistoryLogsType.LOGOUT
            };
            _context.HistoryLogs.Add(log);
            _context.SaveChanges();
        }
    }
}
