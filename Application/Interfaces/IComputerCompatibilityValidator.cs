using Application.Service.Compatibility;

namespace Application.Interfaces;

public interface IComputerCompatibilityValidator
{
    Task<List<CompatibilityViolation>> Validate(ComputerBuild build, ComputerBuild? current);
    Task EnsureCompatible(ComputerBuild build, ComputerBuild? current);
}
