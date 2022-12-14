using KS.Fiks.Plan.Models.V2.felles;

namespace KS.Fiks.Plan.Models.V2.innsyn.PlanerformatrikkelenhetResultat {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class Arealplan
{
    [Newtonsoft.Json.JsonProperty("nasjonalArealplanId", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public NasjonalArealplanId NasjonalArealplanId { get; set; } = new NasjonalArealplanId();

    [Newtonsoft.Json.JsonProperty("plantype", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Plantype Plantype { get; set; } = new Plantype();

    [Newtonsoft.Json.JsonProperty("plannavn", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Plannavn { get; set; }

    [Newtonsoft.Json.JsonProperty("planstatus", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Planstatus Planstatus { get; set; } = new Planstatus();

    [Newtonsoft.Json.JsonProperty("plandokumentasjonOppdatert", Required = Newtonsoft.Json.Required.Always)]
    public bool PlandokumentasjonOppdatert { get; set; }

    [Newtonsoft.Json.JsonProperty("ubehandletKlage", Required = Newtonsoft.Json.Required.Always)]
    public bool UbehandletKlage { get; set; }

    [Newtonsoft.Json.JsonProperty("ubehandletInnsigelse", Required = Newtonsoft.Json.Required.Always)]
    public bool UbehandletInnsigelse { get; set; }

    [Newtonsoft.Json.JsonProperty("vedtaksdato", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset Vedtaksdato { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}