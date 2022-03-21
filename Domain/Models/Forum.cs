﻿using BlazorApp1.Services;

namespace Domain.Models;

public class Forum
{
    public ICollection<SubForum> SubForums { get; set; }
    public ICollection<User> Users { get; set; }
}