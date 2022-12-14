namespace KS.Fiks.Plan.Models.V2.innsyn.DispensasjonerFinn {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class FinnDispensasjoner
{
    [Newtonsoft.Json.JsonProperty("soekskriterie", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<soekskriterie> Soekskriterie { get; set; } = new System.Collections.ObjectModel.Collection<soekskriterie>();



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}