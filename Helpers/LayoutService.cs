using ExamMVC.Context;
using ExamMVC.Models;

namespace ExamMVC.Helpers
{
    public class LayoutService
    {
        ExamContext _db { get; }

        public LayoutService(ExamContext db)
        {
            _db = db;
        }
        public async Task<Setting> GetSettingAsync() => await _db.Settings.FindAsync(1);
    }
}
