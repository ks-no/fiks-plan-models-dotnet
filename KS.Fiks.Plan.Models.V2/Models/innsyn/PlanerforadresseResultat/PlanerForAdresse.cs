using KS.Fiks.Plan.Models.V2.felles;

namespace KS.Fiks.Plan.Models.V2.innsyn.PlanerforadresseResultat {
#pragma warning disable // Disable all warnings

/// <summary>
/// Resultat for alle planer som beroerer en adresse. 
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class PlanerForAdresse
{
    [Newtonsoft.Json.JsonProperty("adresse", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Adresse Adresse { get; set; } = new Adresse();

    [Newtonsoft.Json.JsonProperty("plan", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<Arealplan> Plan { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}