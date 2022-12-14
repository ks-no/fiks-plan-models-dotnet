namespace KS.Fiks.Plan.Models.V2.innsyn.PlanerforomraadeFinn {
#pragma warning disable // Disable all warnings

/// <summary>
/// An array of four positions where the first equals the last
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class linearRing : System.Collections.ObjectModel.Collection<System.Tuple<double, double>>
{


    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}