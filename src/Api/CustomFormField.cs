namespace Forms.Headless.Api;

public class CustomFormField
{
    public string Alias { get; set; }
        
    public string Title { get; set; }
        
    public string Caption { get; set; }
        
    public object Value { get; set; }
    public List<CustomPreValue> PreValues { get; set; }
    public string FieldAlias { get; set; }
}