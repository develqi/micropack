using System.Collections.Generic;

namespace Micropack.Localization;

public class LanguageInfo
{
    public LanguageItem CurrentLanguage { get; set; }

    public List<LanguageItem> SupportedLanguages { get; set; }
}
