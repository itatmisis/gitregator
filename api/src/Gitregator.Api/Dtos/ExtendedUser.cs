using System;
using System.Collections.Generic;

namespace Gitregator.Api.Dtos;

public sealed class ExtendedUser : User
{
    public IEnumerable<CollaboratedRepos> CollaboratedRepos { get; init; } = Array.Empty<CollaboratedRepos>();
}
