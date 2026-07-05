using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class KnowledgeBasis
{
    public Guid Id { get; set; }

    public string Type { get; set; } = null!;

    public string QuestionOrTitle { get; set; } = null!;

    public string AnswerOrContent { get; set; } = null!;

    public string? LanguageCode { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }
}
