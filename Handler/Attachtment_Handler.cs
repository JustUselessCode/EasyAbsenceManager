using System;
using System.IO;

public static class Attachment_Handler
{
    //oldFileName	ist der Name der Datei vor dem Verschieben. Wird größtenteils nur zum ermitteln des Dateiformates genutzt
    //Nachname		ist der Nachname des Schülers, welchem das Dokument gehört
    //Vorname		ist der Vorname des Schülers, welchem das Dokument gehört
    //Klasse		ist die Klasse, in welche der Schüler geht, zum richtigen einsortieren
    //KW			ist die Kalenderwoche, für welche das Dokument ist, für eine einfachere Dokumentensuche
    //year			ist das Jahr, für welches das Dokument ist, damit man die Dokumente auch nach Jahr unterscheiden kann
    public static void RenameAndMove(string oldFileName, string Nachname, string Vorname, string Klasse, int KW, int year)
    {
        string oldLocation = @"\intranet\SchILD-NRW\Dokumentenverwaltung\" + oldFileName;		//angeben des derzeitigen Speicherortes
        //string oldLocation = @"S:\Rick-Hartmann\SWD\Block 5\Projekt\Test\" + oldFileName;     //Testlocation
        string fileType = oldFileName.Split('.')[1];                                            //datentyp der datei zur späteren verwendung speichern
        string KWstring;                                                                        //variable zum speichern der KW als string
        if (KW < 10)
        {                                                                                        //wenn KW einstellig ist
            KWstring = "0" + KW;                                                                //setzte eine 0 davor
        }
        else
        {                                                                                       //sonst
            KWstring = KW.ToString();                                                           //nimm den String der KW
        }
        string fileName = Nachname + "_" + Vorname + "_KW" + KWstring + "_";                    //Grundgerüst für den Dateinamen zusammenbauen
                                                                                                //string newLocation = @"\intranet\SchILD-NRW\Dokumentenverwaltung\"					//den späteren Speicherort definieren
        string newLocation = @"S:\Rick-Hartmann\SWD\Block 5\Projekt\Test\"                      //Testlocation
            + Klasse + @"\" + Nachname + ", " + Vorname + @"\" + year;
        if (!Directory.Exists(newLocation))
        {                                                                                       //Sollte in diesem Jahr noch kein Dokument vorliegen
            Directory.CreateDirectory(newLocation);                                             //erstelle einen neuen Unterordner
        }
        string fileNumber = getNumber(newLocation, fileName);                                   //besorg die Dateinummer zur besseren übersicht
        newLocation = newLocation + @"\" + fileName + fileNumber + fileType;                    //füge den neuen Dateinamen dem speicherort hinzu
        System.IO.File.Move(oldLocation, newLocation);                                          //verschiebe die Datei und benenne sie dabei um
    }
    public static string getName(string oldFileName, string Nachname, string Vorname, string Klasse, int KW, int year)
    {
        string fileType = oldFileName.Split('.')[1];                                        //herausfinden des Dateitypen (PDF etc) fällt weg, wenn direkt übergeben wird
        string KWstring;                                                                    //kw string um die kw zweistellig darzustellen
        if (KW < 10)
        {                                                                                   //wenn kw einstellig ist
            KWstring = "0" + KW;                                                            //hänge eine 0 davor
        }
        else
        {                                                                                   //sonst
            KWstring = KW.ToString();                                                       //wandle die KW in einen string um
        }
        string fileName = Nachname + "_" + Vorname + "_KW" + KWstring + "_";                //dateiname(ohne dateiendung und dateinummer) erstellen
        string location = @"S:\Rick-Hartmann\SWD\Block 5\Projekt\Test\"                     //Testlocation		
        + Klasse + @"\" + Nachname + ", " + Vorname + @"\" + year;
        if (!Directory.Exists(location))
        {                                                                                   //sollte der Ordner, in welchem gespeichert wird nicht existieren
            Directory.CreateDirectory(location);                                            //wird dieser erstellt
        }
        string fileNumber = getNumber(location, fileName);                                  //Dateinummer = getNumber(Speicherverzeichnis, Dateiname)
        return location + @"\" + fileName + fileNumber + fileType;                          //rückgabe des speicherortes mit Dateinamen,Dateinummer und Dateityp
    }
    //location		ist der Verzeichnis, in welche das Dokument gespeichert werden soll
    //fileName		ist der Name, mit welchem das Dokument gespeichtert werden soll
    private static string getNumber(string location, string fileName)
    {
        throw new NotImplementedException();
    }
}

