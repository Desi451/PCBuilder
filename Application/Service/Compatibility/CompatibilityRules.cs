using Domain.Entities.Components.Case;

namespace Application.Service.Compatibility;

public static class CompatibilityRules
{
    public const int GpuClearanceMm = 20;
    public const string PsuStandardPattern = "(?i)^(EATX|ATX|ITXMicroATX|ITX|SFX|SFX-L)$";

    private const int PsuHeadroomWatts = 50;
    private const double PsuSafetyFactor = 1.25;
    private static readonly char[] SlotNameSeparators = [' ', '-', '_', '/'];

    public static int RequiredPsuPower(int cpuTdp, int? gpuTdp)
    {
        var watts = (cpuTdp + (gpuTdp ?? 0) + PsuHeadroomWatts) * PsuSafetyFactor;
        return (int)Math.Round(watts, MidpointRounding.AwayFromZero);
    }

    public static int RequiredCaseDepth(int? gpuLengthMm)
    {
        return gpuLengthMm is null ? 0 : gpuLengthMm.Value + GpuClearanceMm;
    }

    // CaseSize values grow as the form factor shrinks (EATX = 0 ... ITX = 3),
    // so a case holds a component when the case value is lower than or equal to the component value.
    public static bool CaseFits(CaseSize caseSize, CaseSize componentSize)
    {
        return (int)caseSize <= (int)componentSize;
    }

    public static CaseSize LargestFormFactor(CaseSize first, CaseSize second)
    {
        return (CaseSize)Math.Min((int)first, (int)second);
    }

    public static CaseSize? ParsePsuFormFactor(string? standard)
    {
        if (string.IsNullOrWhiteSpace(standard))
        {
            return null;
        }

        var trimmed = standard.Trim();
        if (trimmed.Equals("SFX", StringComparison.OrdinalIgnoreCase) || trimmed.Equals("SFX-L", StringComparison.OrdinalIgnoreCase))
        {
            return CaseSize.ITX;
        }

        var name = Enum.GetNames<CaseSize>().FirstOrDefault(n => n.Equals(trimmed, StringComparison.OrdinalIgnoreCase));
        if (name is null)
        {
            return null;
        }

        return Enum.Parse<CaseSize>(name);
    }

    public static DriveSlotType ClassifyDriveSlot(string? slotName)
    {
        if (string.IsNullOrWhiteSpace(slotName))
        {
            return DriveSlotType.Unknown;
        }

        var tokens = slotName
            .Replace(".", string.Empty)
            .ToUpperInvariant()
            .Split(SlotNameSeparators, StringSplitOptions.RemoveEmptyEntries);

        if (tokens.Contains("M2"))
        {
            return DriveSlotType.M2;
        }

        if (tokens.Any(token => token.StartsWith("SATA", StringComparison.Ordinal)))
        {
            return DriveSlotType.Sata;
        }

        return DriveSlotType.Unknown;
    }
}
