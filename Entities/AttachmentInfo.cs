using EasyAbsenceManager.Helper;
using Microsoft.Office.Interop.Outlook;

namespace EasyAbsenceManager.Entities
{
    internal class AttachmentInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CalendarWeek { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public string MimeType { get; set; }
        public string Class { get; set; }
        public string Path { get; set; } = string.Empty;

        public AttachmentInfo(string FirstName, string LastName, string CalendarWeek, string DocumentNumber, string MimeType, string Class, string Path = null)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CalendarWeek = CalendarWeek;
            this.DocumentNumber = DocumentNumber;
            this.MimeType = MimeType;
            this.Class = Class;
            this.Path = Path;
        }

        public AttachmentInfo(MailItem Email)
        {
            var _Address = Email.Sender.Address;
            var AtIndex = EmailHelper.FindAtSign(_Address);
            var Addressparts = _Address.Substring(0, AtIndex).Split('.');
            this.FirstName = Addressparts[0];
            this.LastName = Addressparts[1];
            this.CalendarWeek = CalendarHelper.GetCalendarWeekFromEmailSubject(Email);
            var TemporaryName = $"{LastName}_{FirstName}_{CalendarWeek}";
            this.MimeType = "png";
            this.Class = Email.Subject.Split('_')[3];
            this.Path = Path;
        }

        public string CreateAttachmentName()
        {
            return $"{LastName}_{FirstName}_{CalendarWeek}_{DocumentNumber}.{MimeType}";
        }
    }
}
