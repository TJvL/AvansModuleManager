using System.Collections.Generic;

namespace ModuleManager.Web.ViewModels.PartialViewModel {

    /// <summary>
    /// Het accepteren van de, door de gebruikers geselecteerde, exporteeropties aan de back-end
    /// </summary>
    public class ExportViewModel {

        public ICollection<string> ExportConfig { get; set; }
    }
}