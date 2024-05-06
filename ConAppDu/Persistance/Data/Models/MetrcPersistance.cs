namespace ConAppDu.Persistence.Data.Models;

public record MetrcPersistance
{
    public string? StateCode { get; set; }
    public string? TraceabilityProvider { get; set; }
    public List<MetrcLocation>? Locations { get; set; }
}

public record MetrcLocation 
{
    public int LocationId  { get; set; }
    public LocationSettings? LockSettings { get; set; }
}

public record LocationSettings 
{
}