﻿namespace ConAppDu.Persistence;


public abstract record TraceabilityProvider
{
	public Enums.Provider Type { get; init; }
	public TraceabilityProvider(Enums.Provider Type) { this.Type = Type; }
}

public record BioTrackConfig : TraceabilityProvider  
{
	public BioTrackConfig() : base(Enums.Provider.BioTrack)
	{

	}
}

public record MetrcConfig : TraceabilityProvider
{
	public MetrcConfig() : base(Enums.Provider.Metrc) 
	{

	}
}

public class Enums 
{
	public enum Provider 
	{
		BioTrack,
		Metrc
	}
}