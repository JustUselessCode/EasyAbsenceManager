using Microsoft.Office.Interop.Outlook;

namespace EasyAbsenceManager.Helper
{
    internal class CalendarHelper
    {
        public static string GetCalendarWeekFromEmailSubject(MailItem Email)
        {
            var subject = Email.Subject;
            return subject.Split('_')[4];
        }
    }
}
