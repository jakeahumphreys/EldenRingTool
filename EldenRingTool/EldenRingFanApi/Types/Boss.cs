﻿using System.Text.Json.Serialization;

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

public sealed class BossesRoot
{
    public bool Success { get; set; }
    public int Count { get; set; }
    public int Total { get; set; }
    [JsonPropertyName("data")]
    public List<Boss> Bosses { get; set; }
}