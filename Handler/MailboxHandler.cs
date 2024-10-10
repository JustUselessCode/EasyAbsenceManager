using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Outlook;
using Folder = Microsoft.Office.Interop.Outlook.Folder;

namespace EasyAbsenceManager.Handler
{
    internal static class MailboxHandler
    {
        public static readonly string _CompletedFolderName = "EasyAbsenceManager - Krankmeldungen";

        private static readonly Regex _SickNotePattern = new Regex(@"^Krankmeldung_[\w]+_[\w]+[a-zA-Z]{2}[0-9]{3}_KW\d{2}");

        public static bool CreateCompletionFolder(Application _App)
        {
            var _Session = _App.Session;
            Folder folderExisting = null;
            var inBox = (Folder)_Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            try
            {
                folderExisting = (Folder)inBox.Folders[_CompletedFolderName];
                return true;
            }
            catch (COMException ex)
            {

                if (folderExisting is null)
                {
                    //ThisAddIn._Log.WriteEntry(ex.StackTrace);
                    try
                    {
                        var completedFolder = (Folder)inBox.Folders.Add(_CompletedFolderName, OlDefaultFolders.olFolderInbox);

                        return false;
                    }
                    catch (System.Exception folderCreationEx)
                    {
                        //ThisAddIn._Log.WriteEntry(folderCreationEx.StackTrace);
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
        }

        public static List<MailItem> FindAllSickNoteMailsInMailBox(Application _App)
        {
            var _Session = _App.Session;
            var mailItems = new List<MailItem>();
            var Emails = _Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox).Items;

            foreach (var mail in Emails)
            {
                try
                {
                    MailItem Email = (MailItem)mail;

                    if (Email is MailItem it && _SickNotePattern.IsMatch(it.Subject))
                    {
                        mailItems.Add(it);
                    }
                }
                catch (System.Exception ex)
                {
                    //ThisAddIn._Log.WriteEntry(ex.StackTrace);
                    continue;
                }
            }

            return mailItems;
        }

        public static void MoveEmails(Application _App, List<MailItem> _Emails)
        {
            var _Session = _App.ActiveExplorer().Session;

            try
            {
                foreach (var mail in _Emails) 
                {
                    mail.Move((Folder)_Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox).Folders[_CompletedFolderName]);
                }
            }
            catch (System.Exception ex)
            {
                //ThisAddIn._Log.WriteEntry(ex.StackTrace);
            }
        }

        public static List<string> CreateDataSourceForListBox(List<MailItem> _Emails)
        {
            var list = new List<string>();
            foreach (MailItem Email in _Emails)
            {
                list.Add(Email.Subject);
            }
            return list;
        }
    }
}