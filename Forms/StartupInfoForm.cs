using System;
using System.Windows.Forms;

namespace EasyAbsenceManager.Forms
{
    public partial class StartupInfoForm : Form
    {
        public StartupInfoForm()
        {
            InitializeComponent();
        }

        private void StartupInfoForm_Load(object sender, EventArgs e)
        {
            var InfoText =
                    "Der EasyAbsenceManager ist ein Werkzeug, das den Prozess rund um die Krankmeldungen vereinfachen und automatisieren soll.\n" +
                    "Bei jedem Start von Outlook durchsucht der EasyAbsenceManager das Postfach nach neuen Krankmeldungen.\n" +
                    "Damit diese gefunden werden können, müssen die Betreffszeilen der E-Mails in einem bestimmten Format vorliegen und von der Siemens-E-mail-Adresse gesendet werden.\n\n" +
                    "Krankmeldung_Nachname_Vorname_Klassenbezeichnung_Kalenderwoche\n" +
                    "Bspw.: Krankmeldung_Mustermann_Max_FS123_KW23 (Groß- und Kleinschreibung ist relevant!)\n\n" +
                    "Nachdem die Suche abgeschlossen ist, wird Ihnen eine Liste mit allen gefundenen Krankmeldungen angezeigt.\n" +
                    "Daraufhin können sie das Tool ausführen.\n" +
                    "Es werden automatisch:\n" +
                    @"        - Die Anhänge aus der E-Mail runtergeladen und unter `\\intranet\\SchILD-NRW\\Dokumentenverwaltung\\Klasse\Schüler\Jahr` gespeichert." + "\n" +
                    "        - Die Datei nach folgender Nomenklatur umbenannt: `Nachname_Vorname_KWXX_YY` (Wobei YY für die Nummer des Doumentes Steht. Bspw. 01)\n" +
                    "        - Die E-Mail in einen automatisch erzeugten Unterordner verschoben `Postfach > EasyAbsenceManager - Krankmeldungen`";

            InfoLabel.Text = InfoText;
            Font = new System.Drawing.Font("Arial", 11);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            return;
        }

        private void InfoLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
