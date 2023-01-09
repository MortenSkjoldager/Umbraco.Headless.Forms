namespace Forms.Headless.Api;

public class CustomForm
{
    public string Name { get; set; }
        
    public IList<CustomFormField> FormFields { get; set; }
}