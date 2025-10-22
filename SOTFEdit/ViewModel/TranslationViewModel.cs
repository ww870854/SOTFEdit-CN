using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using SOTFEdit.Infrastructure;

namespace SOTFEdit.ViewModel;

public partial class TranslationViewModel : ObservableObject
{
    private readonly ICloseable _owner;
    private readonly ObservableCollection<TranslationEntry> _translationEntries;

    [ObservableProperty]
    private string _filterText = "";

    [ObservableProperty]
    private bool _onlyMissing;

    public TranslationViewModel(ICloseable owner)
    {
        _owner = owner;
        var deEntries = TranslationManager.GetAll("de");
        var plEntries = TranslationManager.GetAll("pl");
        var enEntries = TranslationManager.GetAll("en");

        var naturalStringComparer = new NaturalStringComparer();

        var cnEntries = TranslationManager.GetAll("cn").Select(
                kvp =>
                {
                    deEntries.TryGetValue(kvp.Key, out var deValue);
                    plEntries.TryGetValue(kvp.Key, out var plValue);
                    enEntries.TryGetValue(kvp.Key, out var enValue);

                    return new TranslationEntry(kvp.Key, kvp.Value, deValue, plValue, enValue);
                })
            .OrderBy(entry => entry.Key, naturalStringComparer)
            .ToList();
        _translationEntries = new ObservableCollection<TranslationEntry>(cnEntries);
        TranslationEntries = CollectionViewSource.GetDefaultView(_translationEntries);
        TranslationEntries.Filter = OnFilterTranslationEntries;
    }

    public ICollectionView TranslationEntries { get; }

    [RelayCommand]
    private void DoFilter()
    {
        TranslationEntries.Refresh();
    }

    [RelayCommand]
    private void Save()
    {
        var enRoot = new Dictionary<string, object>();
        var deRoot = new Dictionary<string, object>();
        var plRoot = new Dictionary<string, object>();
        var cnRoot = new Dictionary<string, object>();

        foreach (var translationEntry in _translationEntries)
        {
            var keys = translationEntry.Key.Split('.');
            if (!string.IsNullOrWhiteSpace(translationEntry.En))
            {
                AddToDictionary(enRoot, keys, translationEntry.En);
            }

            if (!string.IsNullOrWhiteSpace(translationEntry.De))
            {
                AddToDictionary(deRoot, keys, translationEntry.De);
            }

            if (!string.IsNullOrWhiteSpace(translationEntry.Pl))
            {
                AddToDictionary(plRoot, keys, translationEntry.Pl);
            }

            if (!string.IsNullOrWhiteSpace(translationEntry.Cn))
            {
                AddToDictionary(cnRoot, keys, translationEntry.Cn);
            }
        }

        var enJson = JsonConvert.SerializeObject(enRoot, Formatting.Indented);
        var deJson = JsonConvert.SerializeObject(deRoot, Formatting.Indented);
        var plJson = JsonConvert.SerializeObject(plRoot, Formatting.Indented);
        var cnJson = JsonConvert.SerializeObject(cnRoot, Formatting.Indented);

        File.WriteAllText(Path.Combine(LanguageManager.LangPath, "en.json"), enJson, Encoding.UTF8);
        File.WriteAllText(Path.Combine(LanguageManager.LangPath, "de.json"), deJson, Encoding.UTF8);
        File.WriteAllText(Path.Combine(LanguageManager.LangPath, "pl.json"), plJson, Encoding.UTF8);
        File.WriteAllText(Path.Combine(LanguageManager.LangPath, "cn.json"), cnJson, Encoding.UTF8);

        _owner.Close();
    }

    private static void AddToDictionary(Dictionary<string, object> dict, IReadOnlyList<string> keys, string value)
    {
        for (var i = 0; i < keys.Count; i++)
        {
            if (i == keys.Count - 1) // Last key, add the value
            {
                dict[keys[i]] = value;
            }
            else
            {
                if (!dict.ContainsKey(keys[i]))
                {
                    dict[keys[i]] = new Dictionary<string, object>();
                }

                dict = dict[keys[i]] as Dictionary<string, object>;
            }
        }
    }

    private bool OnFilterTranslationEntries(object obj)
    {
        var filterText = FilterText;
        if (!OnlyMissing && string.IsNullOrWhiteSpace(filterText))
        {
            return true;
        }

        if (obj is not TranslationEntry entry)
        {
            return false;
        }

        if (OnlyMissing && !string.IsNullOrWhiteSpace(entry.De) && !string.IsNullOrWhiteSpace(entry.Pl) && !string.IsNullOrWhiteSpace(entry.En))
        {
            return false;
        }

        var comparisonResult = string.IsNullOrWhiteSpace(filterText)
                               || entry.Key.Contains(filterText, StringComparison.OrdinalIgnoreCase)
                               || entry.Cn.Contains(filterText, StringComparison.OrdinalIgnoreCase)
                               || (entry.De?.Contains(filterText, StringComparison.OrdinalIgnoreCase) ?? false)
                               || (entry.Pl?.Contains(filterText, StringComparison.OrdinalIgnoreCase) ?? false)
                               || (entry.En?.Contains(filterText, StringComparison.OrdinalIgnoreCase) ?? false);

        return comparisonResult;
    }
}

public partial class TranslationEntry : ObservableObject
{
    [ObservableProperty]
    private string? _de;

    [ObservableProperty]
    private string _cn;

    [ObservableProperty]
    private string _key;

    [ObservableProperty]
    private string? _pl;

    [ObservableProperty]
    private string? _en;

    public TranslationEntry(string key, string cn, string? de = null, string? pl = null, string? en = null)
    {
        _key = key;
        _cn = cn;
        _de = de;
        _pl = pl;
        _en = en;
    }
}