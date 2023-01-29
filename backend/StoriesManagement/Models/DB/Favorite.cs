using System;
using System.Collections.Generic;

namespace StoriesManagement.Models;

public partial class Favorite
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int ArticleId { get; set; }
}
