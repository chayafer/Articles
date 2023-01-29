using System;
using System.Collections.Generic;

namespace StoriesManagement.Models;

public partial class ArticleBase
{
    public string? Title { get; set; }

    public string? Image { get; set; }

    public int? CategoryId { get; set; }

    public string? Description { get; set; }

    public int Id { get; set; }
}
