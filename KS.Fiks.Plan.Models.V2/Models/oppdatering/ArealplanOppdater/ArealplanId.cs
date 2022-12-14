namespace KS.Fiks.Plan.Models.V2.oppdatering.ArealplanOppdater {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class ArealplanId
{
    [Newtonsoft.Json.JsonProperty("administrativEnhet", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public AdministrativEnhet AdministrativEnhet { get; set; } = new AdministrativEnhet();

    [Newtonsoft.Json.JsonProperty("planidentifikasjon", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Planidentifikasjon { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}