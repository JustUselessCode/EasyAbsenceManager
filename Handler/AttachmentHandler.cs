using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyAbsenceManager.Helper;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;

namespace EasyAbsenceManager.Handler
{
    internal static class AttachmentHandler
    {

        //private static string readonly _AttachmentPath = @"\intranet\SchILD-NRW\Dokumentenverwaltung\";
        private static readonly string _AttachmentPath = $@"C:\Users\tzander\Documents\Berufsschule\Fächer\SWD\Block - 5\";

        public static bool TryDownloadAndRenameAttachment(Outlook.Application _App, List<MailItem> _Emails)
        {
            try
            {
                foreach (var _Email in _Emails)
                {
                    var _Attachments = _Email.Attachments;
                    foreach (Attachment _Attachment in _Attachments)
                    {
                        try
                        {
                            var name = _Attachment.FileName;
                            Console.WriteLine(_Attachment.FileName);
                            _Attachment.SaveAsFile(_AttachmentPath + CreateAttachmentName(_Email));
                        }
                        catch (System.Exception ex)
                        {
                            //ThisAddIn._Log.WriteEntry(ex.StackTrace);
                        }

                    }
                    _Email.Move(_App.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox).Folders[MailboxHandler._CompletedFolderName]);
                }
                
            }
            catch (System.Exception ex)
            {
                //ThisAddIn._Log.WriteEntry(ex.StackTrace);
            }
            return false;
        }

        public static string CreateAttachmentName(MailItem Email)
        {
            var _Address = Email.Sender.Address;
            var AtIndex = FindAtSign(_Address);
            var Addressparts = _Address.Substring(0, AtIndex).Split('.');
            var FirstName = Addressparts[0];
            var LastName = Addressparts[1];
            var CalendarWeek = CalendarHelper.GetCalendarWeekFromEmailSubject(Email);
            var TemporaryName = $"{LastName}_{FirstName}_{CalendarWeek}_";
            var DocumentNumber = FindDocumentNumber(_AttachmentPath, TemporaryName);

            return TemporaryName + $"{DocumentNumber}";
        }

        public static int FindAtSign(string address)
        {
            for (int i = 0; i < address.Length; i++)
            {
                if (address[i] == '@')
                {
                    return i;
                }
            }

            return -1;
        }

        public static string FindDocumentNumber(string location, string fileName)
        {
            DirectoryInfo directory = new DirectoryInfo(location);                                  // Besorgen der Info des Verzeichnisses
            FileInfo[] files = directory.GetFiles();                                                // Besorgen aller dateien im Verzeichnis
            if (files.Length == 0)
            {                                                                                       // sollte bisher noch kein anhang existieren
                return "01.";                                                                       // dann ist 01 die Nummer, die direkt zurückgegeben wird
            }
            int number = 1;                                                                         // zahl auf 1 setzen
            string numberstring = "0" + number;                                                     // 1 zu 01 machen
            string path = location + @"\" + fileName + numberstring;                                // pfad = Verzeichnispfad + Dateiname + zahl
            string file;                                                                            // leerer string für die spätere Nutzung
            bool available = false;                                                                 // zahl verfügbar auf nein setzen
            while (!available)
            {                                                                                       // solange kein verfügbarer name gefunden wurde
                available = true;                                                                   // wir gehen davon aus, dass der neue name verfügbar ist
                for (int i = 0; i < files.Length; i++)
                {                                                                                   // gehe alle dateinamen durch 
                    file = files[i].FullName.Split('.')[0];                                         // trenne die Dateiendung ab und speichere das in file
                    if (file == path)
                    {                                                                               // wenn file und pfad gleich sind
                        available = false;                                                          // setze verfügbar auf nein
                        i = files.Length;                                                           // beende die for schleife
                        number++;                                                                   // zähle die zahl um 1 hoch
                        if (number < 10)
                        {                                                                           // wenn die zahl kleiner als 10 ist
                            numberstring = "0" + number;                                            // setzte den numberstring auf 0 + nummer
                        }
                        else
                        {                                                                           // ansonsten
                            numberstring = number.ToString();                                       // numberstring = nummer
                        }
                        path = location + @"\" + fileName + numberstring;                           // anpassen des pfades
                    }
                }
            }
            return numberstring + ".";                                                              // gebe die nummer + "." zurück
        }
    }
}