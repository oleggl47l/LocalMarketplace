namespace LocMp.Identity.Application.DTOs.Common;

public sealed record LookupItemDto(
    int Id,
    string Name,
    bool? IsActive = null)
{
    public LookupItemDto(int Id, string Name) : this(Id, Name, null)
    {
    }
}