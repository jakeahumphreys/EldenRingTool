namespace EldenRingTool.EldenRingFanApi.Types;

public sealed class Boss
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string[] Drops { get; set; }
    public string HealthPoints { get; set; }
}