﻿using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace BlazorApp1.Services;

public class SubForum
{
    [Key]
    public string Id { get; set; }
    public User OwnedBy { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Post> Posts { get; set; }

    public SubForum()
    {
        Id = RandomIDGenerator.Generate(20);
        OwnedBy = new User();
        Title = String.Empty;
        Description = Description;
        Posts = new List<Post>();
    }
}