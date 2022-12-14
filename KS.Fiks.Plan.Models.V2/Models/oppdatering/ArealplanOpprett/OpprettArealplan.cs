namespace KS.Fiks.Plan.Models.V2.oppdatering.ArealplanOpprett {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class OpprettArealplan
{
    [Newtonsoft.Json.JsonProperty("plannavn", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Plannavn { get; set; }

    [Newtonsoft.Json.JsonProperty("plantype", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Plantype Plantype { get; set; } = new Plantype();

    [Newtonsoft.Json.JsonProperty("planstatus", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Planstatus Planstatus { get; set; } = new Planstatus();

    [Newtonsoft.Json.JsonProperty("lovreferanse", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Lovreferanse Lovreferanse { get; set; } = new Lovreferanse();

    [Newtonsoft.Json.JsonProperty("saksnummer", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Saksnummer Saksnummer { get; set; } = new Saksnummer();

    [Newtonsoft.Json.JsonProperty("forslagsstillerType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public OpprettArealplanForslagsstillerType ForslagsstillerType { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}