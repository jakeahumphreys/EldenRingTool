using EldenRingTool.EldenRingFanApi.Types;

namespace EldenRingTool.Tests.EldenRingFanApi.Helpers;

public class TestBossBuilder
{
    private string id;
    private string name;
    private string image;
    private string description;
    private string location;
    private string[] drops;
    private string healthPoints;

    public TestBossBuilder WithId(string id)
    {
        this.id = id;
        return this;
    }

    public TestBossBuilder WithName(string name)
    {
        this.name = name;
        return this;
    }

    public TestBossBuilder WithImage(string image)
    {
        this.image = image;
        return this;
    }

    public TestBossBuilder WithDescription(string description)
    {
        this.description = description;
        return this;
    }

    public TestBossBuilder WithLocation(string location)
    {
        this.location = location;
        return this;
    }

    public TestBossBuilder WithDrops(string[] drops)
    {
        this.drops = drops;
        return this;
    }

    public TestBossBuilder WithHealthPoints(string healthPoints)
    {
        this.healthPoints = healthPoints;
        return this;
    }

    public Boss Build()
    {
        return new Boss
        {
            Id = id,
            Name = name,
            Image = image,
            Description = description,
            Location = location,
            Drops = drops,
            HealthPoints = healthPoints
        };
    }
}