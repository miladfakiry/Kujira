using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Kujira.Shared;

internal class DictionaryMudLocalizer : MudLocalizer
{
    private readonly Dictionary<string, string> _localization;

    public DictionaryMudLocalizer()
    {
        _localization = new Dictionary<string, string>
        {
            {"MudDataGrid.AddFilter", "Filter hinzufügen"},
            {"MudDataGrid.Apply", "Anwenden"},
            {"MudDataGrid.Cancel", "Abbrechen"},
            {"MudDataGrid.Clear", "Löschen"},
            {"MudDataGrid.CollapseAllGroups", "Alle Gruppen einklappen"},
            {"MudDataGrid.Column", "Spalte"},
            {"MudDataGrid.Columns", "Spalten"},
            {"MudDataGrid.contains", "enthält"},
            {"MudDataGrid.ends with", "endet mit"},
            {"MudDataGrid.equals", "gleich"},
            {"MudDataGrid.ExpandAllGroups", "Alle Gruppen ausklappen"},
            {"MudDataGrid.Filter", "Filter"},
            {"MudDataGrid.False", "Falsch"},
            {"MudDataGrid.FilterValue", "Filterwert"},
            {"MudDataGrid.Group", "Gruppe"},
            {"MudDataGrid.Hide", "Verbergen"},
            {"MudDataGrid.HideAll", "Alles verbergen"},
            {"MudDataGrid.is", "ist"},
            {"MudDataGrid.is after", "ist nach"},
            {"MudDataGrid.is before", "ist vor"},
            {"MudDataGrid.is empty", "ist leer"},
            {"MudDataGrid.is not", "ist nicht"},
            {"MudDataGrid.is not empty", "ist nicht leer"},
            {"MudDataGrid.is on or after", "ist am oder nach"},
            {"MudDataGrid.is on or before", "ist am oder vor"},
            {"MudDataGrid.not contains", "enthält nicht"},
            {"MudDataGrid.not equals", "ungleich"},
            {"MudDataGrid.Operator", "Operator"},
            {"MudDataGrid.RefreshData", "Daten aktualisieren"},
            {"MudDataGrid.Save", "Speichern"},
            {"MudDataGrid.ShowAll", "Alles anzeigen"},
            {"MudDataGrid.starts with", "beginnt mit"},
            {"MudDataGrid.True", "Wahr"},
            {"MudDataGrid.Ungroup", "Gruppierung aufheben"},
            {"MudDataGrid.Unsort", "Sortierung aufheben"},
            {"MudDataGrid.Value", "Wert"},
            {"MudDataGrid.Rows per page", "Zeilen pro Seite"}
        };
    }

    public override LocalizedString this[string key]
    {
        get
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Parent.TwoLetterISOLanguageName;
            if (currentCulture.Equals("de", StringComparison.InvariantCultureIgnoreCase) && _localization.TryGetValue(key, out var res))
            {
                return new LocalizedString(key, res);
            }

            return new LocalizedString(key, key, true);
        }
    }
}