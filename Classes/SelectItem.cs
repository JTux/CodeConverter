namespace CodeConverter.Classes;

public class SelectItem
{
    public SelectItem(string label, string value)
    {
        Label = label;
        Value = value;
    }

    public string Label { get; }
    public string Value { get; }
}
