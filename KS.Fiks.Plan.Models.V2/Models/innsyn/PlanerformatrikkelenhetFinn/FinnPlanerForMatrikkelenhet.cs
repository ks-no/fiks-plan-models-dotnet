namespace KS.Fiks.Plan.Models.V2.innsyn.PlanerformatrikkelenhetFinn {
#pragma warning disable // Disable all warnings

/// <summary>
/// Finner alle planer som beroerer en eiendom. 
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class FinnPlanerForMatrikkelenhet
{
    [Newtonsoft.Json.JsonProperty("matrikkelnummer", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Matrikkelnummer Matrikkelnummer { get; set; } = new Matrikkelnummer();



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}