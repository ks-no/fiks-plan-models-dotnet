using KS.Fiks.Plan.Models.V2.felles;

namespace KS.Fiks.Plan.Models.V2.innsyn.AktoererHent {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class HentAktoerer
{
    [Newtonsoft.Json.JsonProperty("saksnummer", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Saksnummer Saksnummer { get; set; }

    [Newtonsoft.Json.JsonProperty("nasjonalArealplanId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public NasjonalArealplanId NasjonalArealplanId { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}