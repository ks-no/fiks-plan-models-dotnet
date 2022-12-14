namespace KS.Fiks.Plan.Models.V2.innsyn.MidlertidigforbudResultat {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class MidlertidigForbud1
{
    [Newtonsoft.Json.JsonProperty("omraade", Required = Newtonsoft.Json.Required.Always)]
    public Omraade Omraade { get; set; }

    [Newtonsoft.Json.JsonProperty("saksnummer", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Saksnummer Saksnummer { get; set; }

    [Newtonsoft.Json.JsonProperty("avgjoerelsedato", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset Avgjoerelsedato { get; set; }

    [Newtonsoft.Json.JsonProperty("pblTiltakForbudtype", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public PblTiltakForbudtype PblTiltakForbudtype { get; set; } = new PblTiltakForbudtype();

    [Newtonsoft.Json.JsonProperty("gyldigTilDato", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset GyldigTilDato { get; set; }

    [Newtonsoft.Json.JsonProperty("omraadenavn", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Omraadenavn { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}