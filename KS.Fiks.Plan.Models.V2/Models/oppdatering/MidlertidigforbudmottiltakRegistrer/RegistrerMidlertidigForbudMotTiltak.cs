namespace KS.Fiks.Plan.Models.V2.oppdatering.MidlertidigforbudmottiltakRegistrer {
#pragma warning disable // Disable all warnings

/// <summary>
/// Forvaltning av «midlertidig forbud mot tiltak» i planregister ”Midlertidig forbud mot tiltak” er ikke en plantype, og dermed heller ikke arealplandata, men gyldighetsområdet skal likevel inngå i kommunalt planregister, og forvaltes som et eget datalag. Dette fordi slike midlertidige forbud mot tiltak utgjør en kraftig restriksjon i videre bruk av arealer inntil det er gjennomført ny planprosess. 
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class RegistrerMidlertidigForbudMotTiltak
{
    /// <summary>
    /// PblMidlForbudMotTiltakOmraade
    /// </summary>
    [Newtonsoft.Json.JsonProperty("forbudOmraade", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ForbudOmraade ForbudOmraade { get; set; } = new ForbudOmraade();



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}