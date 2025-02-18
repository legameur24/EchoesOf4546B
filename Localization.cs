using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Handlers;
using BepInEx;
using System.Collections.Generic;

[BepInPlugin("com.snmodding.nautilus.localization", "Nautilus Localization Example Mod", Nautilus.PluginInfo.PLUGIN_VERSION)]
[BepInDependency("com.snmodding.nautilus")]
public class LocalizationExample : BaseUnityPlugin
{
    /*
     * Here we have a dictionary that contains language keys and values for certain stuff.
     * The language key for the display name of TechTypes is "{enumName}".
     * Since our Titanium Clone's tech type is "TitaniumClone", this is what we will use for the display name.
     *
     * Similarly, for tooltips, the language key is "Tooltip_{enumName}", so for our Titanium Clone, it would be "Tooltip_TitaniumClone".
     */
    private Dictionary<string, string> _languageEntriesEng = new()
    {
        { "diamondsblade", "Hardened Blade" }, { "Tooltip_diamondsblade", "Diamond-hardened blade delivers higher damage." },
        { "PrecursorAlloy", "Precursor Alloy" }, { "Tooltip_PrecursorAlloy", "?2Li2C3. An alien alloy is very resistant and considered to hyper-alloy." }
    };

    /*
     * Here we have a dictionary that translates the language entries above to Spanish.
     * Keep in mind that the language keys are the same for every language.
     */
    private Dictionary<string, string> _languageEntriesFra = new()
    {
        { "diamondsblade", "Lame Durcie" }, { "Tooltip_diamondsblade", "Lame renforcée avec diamant pour faire plus de degât." },
        { "PrecursorAlloy", "Alliage des Precurseurs" }, { "Tooltip_PrecursorAlloy", "?2Li2C3. Alliage extraterrestre très resistant et considérer comme Hyper-Alliage." }
    };

    private void Awake()
    {
#if LOCALIZATION_FOLDER
       
        LanguageHandler.RegisterLocalizationFolder();
#else
        // Register our English language entries to the English language
        LanguageHandler.RegisterLocalization("English", _languageEntriesEng);

        // Register our Spanish language entries to the Spanish language
        LanguageHandler.RegisterLocalization("French", _languageEntriesFra);
#endif

    }
}

