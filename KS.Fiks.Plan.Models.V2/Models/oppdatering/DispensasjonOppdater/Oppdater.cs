using KS.Fiks.Plan.Models.V2.felles;

namespace KS.Fiks.Plan.Models.V2.oppdatering.DispensasjonOppdater {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class Oppdater
{
    [Newtonsoft.Json.JsonProperty("identifikasjon", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Identifikasjon { get; set; }

    [Newtonsoft.Json.JsonProperty("dispensasjon", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Dispensasjon Dispensasjon { get; set; } = new Dispensasjon();

    [Newtonsoft.Json.JsonProperty("nasjonalArealplanId", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public NasjonalArealplanId NasjonalArealplanId { get; set; } = new NasjonalArealplanId();

    [Newtonsoft.Json.JsonProperty("begrunnelse", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Begrunnelse { get; set; }

    [Newtonsoft.Json.JsonProperty("vedtaksdato", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset Vedtaksdato { get; set; }

    /// <summary>
    /// Punkt
    /// </summary>
    [Newtonsoft.Json.JsonProperty("posisjon", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Posisjon Posisjon { get; set; }

    [Newtonsoft.Json.JsonProperty("vertikalnivaa", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Vertikalnivaa Vertikalnivaa { get; set; }

    [Newtonsoft.Json.JsonProperty("beskrivelse", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Beskrivelse { get; set; }

    [Newtonsoft.Json.JsonProperty("innvilgetDispensasjon", Required = Newtonsoft.Json.Required.Always)]
    public bool InnvilgetDispensasjon { get; set; }

    [Newtonsoft.Json.JsonProperty("saksnummer", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Saksnummer Saksnummer { get; set; }

    [Newtonsoft.Json.JsonProperty("varigDispensasjon", Required = Newtonsoft.Json.Required.Always)]
    public bool VarigDispensasjon { get; set; }

    [Newtonsoft.Json.JsonProperty("varighetFra", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset VarighetFra { get; set; }

    [Newtonsoft.Json.JsonProperty("varighetTil", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset VarighetTil { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}