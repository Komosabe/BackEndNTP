﻿namespace BackEndTutorialNTP.Entities;

using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public int FamilyMemberId { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }
}