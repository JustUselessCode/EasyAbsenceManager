using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
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
