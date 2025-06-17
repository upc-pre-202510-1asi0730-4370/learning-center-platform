using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

public class ReadableContentAsset : Asset
{
    public ReadableContentAsset() : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = string.Empty;
    }

    public ReadableContentAsset(string content) : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = content;
    }    
    public string ReadableContent { get; set; }
    public override bool Readable => true;
    public override bool Viewable => false;
}