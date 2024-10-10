using System;
using System.IO;
using System.Linq;
using EasyAbsenceManager.Forms;
using System.Collections.Generic;
using EasyAbsenceManager.Entities;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace EasyAbsenceManager.Handler
{
    internal static class AttachmentHandler
    {

        //private static string readonly _AttachmentPath = @"\intranet\SchILD-NRW\Dokumentenverwaltung\";
        public static readonly string _AttachmentPath = $@"C:\Users\tzander\Documents\Berufsschule\Fächer\SWD\Block - 5\";
        public static string CurrentAttachmentPath { get; set; } = string.Empty;

        public static void TryDownloadAndRenameAttachment(Outlook.Application _App, List<MailItem> _Emails)
        {
            try
            {
                foreach (var _Email in _Emails)
                {
                    foreach (Attachment _Attachment in _Email.Attachments)
                    {

                        var AttachmentInfo = new AttachmentInfo(_Email);
                        var FullPath = CreateNeccessaryDirectories(AttachmentInfo.LastName, AttachmentInfo.FirstName, AttachmentInfo.Class, AttachmentInfo.CalendarWeek, DateTime.Now.Year);
                        AttachmentInfo.Path = FullPath;
                        AttachmentInfo.MimeType = GetAttachmentFileType(_Attachment);
                        CurrentAttachmentPath = AttachmentInfo.Path;
                        AttachmentInfo.DocumentNumber = FindDocumentNumber(CurrentAttachmentPath, AttachmentInfo.CalendarWeek);
                        var AttachmentName = AttachmentInfo.CreateAttachmentName();
                        _Attachment.SaveAsFile(CurrentAttachmentPath + AttachmentName);
                    }
                    if (_Email.Attachments.Count > 0)
                    {
                        _Email.Move(_App.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox).Folders[MailboxHandler._CompletedFolderName]);
                    }
                    else
                    {
                        var NoAttachmentForm = new NoAttachmentsForm();
                        NoAttachmentForm.HeaderLabel.Text = $"In der E-Mail: {_Email.Subject} wurde kein Anhang gefunden.";
                        NoAttachmentForm.HeaderLabel.Font = new System.Drawing.Font("Arial", 11);
                        NoAttachmentForm.InfoLabel.Text = "Soll die E-Mail trotzdem in den EasyAbsenceManager - Krankmeldungen Ordner verschoben werden?";
                        NoAttachmentForm.InfoLabel.Font = new System.Drawing.Font("Arial", 11);
                        NoAttachmentForm.ShowDialog();

                        if (NoAttachmentForm.DialogResult == System.Windows.Forms.DialogResult.OK)
                        {
                            _Email.Move(_App.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox).Folders[MailboxHandler._CompletedFolderName]);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            catch (System.Exception ex)
            {
                //ThisAddIn._Log.WriteEntry(ex.StackTrace);
            }
        }



        public static string CreateNeccessaryDirectories(string Nachname, string Vorname, string Klasse, string KW, int year)
        {
            var RequiredPath = $@"{_AttachmentPath}{Klasse}\{Nachname}, {Vorname}\{year}\";
            if (!Directory.Exists(RequiredPath))
            {
                try
                {
                    Directory.CreateDirectory(RequiredPath);
                    return RequiredPath;

                }
                catch (System.Exception ex)
                {
                    return string.Empty;
                }
            }
            return RequiredPath;
        }

        public static string FindDocumentNumber(string Path, string CalendarWeek)
        {
            var DirInfo = new DirectoryInfo(Path);
            var Files = DirInfo.GetFiles();
            //var NumberString = string.Empty;
            var NumberOfFiles = 1;

            if (Files.Length == 0)
            {
                return "01";
            }
            else
            {
                foreach (var _File in Files.Where(f => f.Name.Contains(CalendarWeek)))
                {
                    NumberOfFiles++;
                }
                return NumberOfFiles < 10 ? ("0" + NumberOfFiles.ToString()) : NumberOfFiles.ToString();
            }
        }



        public static string GetAttachmentFileType(Attachment attachment)
        {
            if (attachment == null)
            {
                throw new ArgumentNullException(nameof(attachment));
            }

            string fileName = attachment.FileName;
            int lastDotIndex = fileName.LastIndexOf('.');

            if (lastDotIndex == -1)
            {
                return string.Empty;
            }

            return fileName.Substring(lastDotIndex + 1).ToLower();
        }
    }
}