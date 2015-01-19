namespace ModuleManager.DomainDAL.Utility
{
    public class DomainConstants
    {
        public const string DbErrorStandard = "Kan actie niet voltooien: Probeer het later nog eens.";
        public const string DbErrorPkInvalid = "Kan actie niet voltooien: De opgegeven primaire sleutels zijn niet correct.";
        public const string DbErrorFkConstraint = "Kan actie niet voltooien: De entiteit is een vreemde sleutel in een andere entiteit.";
        public const string DbErrorPkDuplicate = "Kan actie niet voltooien: Deze primaire sleutel bestaat al in de tabel.";
        public const string DbErrorNoSelection = "Kan actie niet voltooien: Er is niks geselecteerd om in te voeren.";
        public const string DbErrorPkChanged = "Kan actie niet voltooien: Kan de primaire sleutel niet aanpassen van een entiteit.";

        public const string ExportErrorStandard = "Kan actie niet voltooien.";
        public const string ExportErrorAccessDenied = "Kan actie niet voltooien: Bestandssysteem weigerd toegang tot bestand of bestandslocatie.";
    }
}