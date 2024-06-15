using System.Text.Json.Serialization;

namespace Micropack.Multilingual;

public class MultilingualModel
{
    [JsonIgnore]
    public Multilingual? Title { get; set; }

    public string Caption => Title.GetCaption().Title;
}