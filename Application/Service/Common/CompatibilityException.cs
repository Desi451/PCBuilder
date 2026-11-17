using Application.Service.Compatibility;

namespace Application.Service.Common;

public class CompatibilityException : Exception
{
    public CompatibilityException(IReadOnlyList<CompatibilityViolation> violations)
        : base("The computer configuration is not compatible.")
    {
        Violations = violations;
    }

    public IReadOnlyList<CompatibilityViolation> Violations { get; }
}
