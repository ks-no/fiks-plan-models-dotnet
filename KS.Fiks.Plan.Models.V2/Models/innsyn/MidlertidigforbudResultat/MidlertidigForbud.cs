namespace KS.Fiks.Plan.Models.V2.innsyn.MidlertidigforbudResultat {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class MidlertidigForbud
{
    /// <summary>
    /// PblMidlForbudMotTiltakOmraade
    /// </summary>
    [Newtonsoft.Json.JsonProperty("midlertidigForbud", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public MidlertidigForbud1 MidlertidigForbud1 { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}