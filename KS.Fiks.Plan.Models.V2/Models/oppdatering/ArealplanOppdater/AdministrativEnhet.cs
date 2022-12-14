namespace KS.Fiks.Plan.Models.V2.oppdatering.ArealplanOppdater {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class AdministrativEnhet
{
    /// <summary>
    /// Kommunenummer
    /// </summary>
    [Newtonsoft.Json.JsonProperty("kommunenummer", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Kommunenummer { get; set; }

    /// <summary>
    /// Fylkesnummer
    /// </summary>
    [Newtonsoft.Json.JsonProperty("fylkesnummer", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Fylkesnummer { get; set; }

    /// <summary>
    /// Landskode
    /// </summary>
    [Newtonsoft.Json.JsonProperty("landskode", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Landskode { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}