using KS.Fiks.Plan.Models.V2.felles;

namespace KS.Fiks.Plan.Models.V2.oppdatering.DispensasjonOppdater {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class Saksnummer
{
    [Newtonsoft.Json.JsonProperty("saksaar", Required = Newtonsoft.Json.Required.Always)]
    public int Saksaar { get; set; }

    [Newtonsoft.Json.JsonProperty("sakssekvensnummer", Required = Newtonsoft.Json.Required.Always)]
    public int Sakssekvensnummer { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}