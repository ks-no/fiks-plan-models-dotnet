namespace KS.Fiks.Plan.Models.V2.oppdatering.ArealplanOppdater {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class OppdaterArealplan
{
    [Newtonsoft.Json.JsonProperty("arealplanId", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ArealplanId ArealplanId { get; set; } = new ArealplanId();

    [Newtonsoft.Json.JsonProperty("plannavn", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Plannavn { get; set; }

    [Newtonsoft.Json.JsonProperty("plantype", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Plantype Plantype { get; set; }

    [Newtonsoft.Json.JsonProperty("planstatus", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Planstatus Planstatus { get; set; }

    [Newtonsoft.Json.JsonProperty("lovreferanse", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Lovreferanse Lovreferanse { get; set; }

    [Newtonsoft.Json.JsonProperty("saksnummer", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Saksnummer Saksnummer { get; set; }

    [Newtonsoft.Json.JsonProperty("forslagstillerType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public OppdaterArealplanForslagstillerType ForslagstillerType { get; set; }

    [Newtonsoft.Json.JsonProperty("vedlegg", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<Plandokument> Vedlegg { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}