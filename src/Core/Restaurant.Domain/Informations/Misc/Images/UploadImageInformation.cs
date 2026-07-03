namespace Restaurant.Domain.Informations.Misc.Images
{
    public sealed record UploadImageInformation(
        string? AltText,
        string Url,
        string StoragePath,
        decimal FileSize,
        string ContentType,
        bool IsPrimary);
}
