﻿
namespace ConAppRedis.ApiOperations.Data;

public class Character
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Occupation { get; set; }
    public string? Gender { get; set; }
    public string? PictureUrl { get; set; }
    public int Votes { get; set; }
}
