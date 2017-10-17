// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = BrandbankData.FromJson(jsonString);
//
namespace Middleware.Products.Data.Models
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class Brandbank
    {
        [JsonProperty("ExtendedData")]
        public object ExtendedData { get; set; }

        [JsonProperty("Availability")]
        public object Availability { get; set; }

        [JsonProperty("Assets")]
        public Assets Assets { get; set; }

        [JsonProperty("Data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("StatusSpecified")]
        public bool StatusSpecified { get; set; }

        [JsonProperty("UpdateTypeSpecified")]
        public bool UpdateTypeSpecified { get; set; }

        [JsonProperty("Identity")]
        public Identity Identity { get; set; }

        [JsonProperty("UpdateType")]
        public long UpdateType { get; set; }

        [JsonProperty("VersionDateTime")]
        public string VersionDateTime { get; set; }

        [JsonProperty("VersionDateTimeSpecified")]
        public bool VersionDateTimeSpecified { get; set; }
    }

    public partial class Assets
    {
        [JsonProperty("AssociatedImage")]
        public object AssociatedImage { get; set; }

        [JsonProperty("AssociatedDocument")]
        public object AssociatedDocument { get; set; }

        [JsonProperty("Document")]
        public object Document { get; set; }

        [JsonProperty("Image")]
        public List<Image> Image { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("ShotType")]
        public string ShotType { get; set; }

        [JsonProperty("Language")]
        public object Language { get; set; }

        [JsonProperty("Id")]
        public object Id { get; set; }

        [JsonProperty("MimeType")]
        public string MimeType { get; set; }

        [JsonProperty("Specification")]
        public Specification Specification { get; set; }

        [JsonProperty("ShotTypeId")]
        public long ShotTypeId { get; set; }

        [JsonProperty("Thumbprint")]
        public string Thumbprint { get; set; }

        [JsonProperty("Url")]
        public Url Url { get; set; }
    }

    public partial class Specification
    {
        [JsonProperty("IsProhibitUpscaleSpecified")]
        public bool IsProhibitUpscaleSpecified { get; set; }

        [JsonProperty("Filename")]
        public object Filename { get; set; }

        [JsonProperty("CropPadding")]
        public long CropPadding { get; set; }

        [JsonProperty("BackgroundColour")]
        public object BackgroundColour { get; set; }

        [JsonProperty("CropPaddingSpecified")]
        public bool CropPaddingSpecified { get; set; }

        [JsonProperty("IsCropped")]
        public bool IsCropped { get; set; }

        [JsonProperty("IsBestAvailableSpecified")]
        public bool IsBestAvailableSpecified { get; set; }

        [JsonProperty("IsCroppedSpecified")]
        public bool IsCroppedSpecified { get; set; }

        [JsonProperty("Overlays")]
        public object Overlays { get; set; }

        [JsonProperty("MaxSizeInBytes")]
        public long MaxSizeInBytes { get; set; }

        [JsonProperty("IsTransparentSpecified")]
        public bool IsTransparentSpecified { get; set; }

        [JsonProperty("MaxSizeInBytesSpecified")]
        public bool MaxSizeInBytesSpecified { get; set; }

        [JsonProperty("QualitySpecified")]
        public bool QualitySpecified { get; set; }

        [JsonProperty("Quality")]
        public long Quality { get; set; }

        [JsonProperty("RequestedDimensions")]
        public RequestedDimensions RequestedDimensions { get; set; }

        [JsonProperty("Resolution")]
        public string Resolution { get; set; }
    }

    public partial class RequestedDimensions
    {
        [JsonProperty("Units")]
        public long Units { get; set; }

        [JsonProperty("Height")]
        public long Height { get; set; }

        [JsonProperty("Width")]
        public long Width { get; set; }
    }

    public partial class Url
    {
        [JsonProperty("ExpiryDateTimeSpecified")]
        public bool ExpiryDateTimeSpecified { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("GroupingSetId")]
        public long GroupingSetId { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Categorisations")]
        public List<Categorisation> Categorisations { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("ItemTypeGroup")]
        public List<ItemTypeGroup> ItemTypeGroup { get; set; }

        [JsonProperty("GroupingSetName")]
        public string GroupingSetName { get; set; }

        [JsonProperty("Part")]
        public object Part { get; set; }

        [JsonProperty("Source")]
        public long Source { get; set; }
    }

    public partial class Categorisation
    {
        [JsonProperty("Level")]
        public List<DiagnosticDescription> Level { get; set; }

        [JsonProperty("Scheme")]
        public string Scheme { get; set; }
    }

    public partial class DiagnosticDescription
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }

    public partial class ItemTypeGroup
    {
        [JsonProperty("NameTextItems")]
        public List<NameLookup> NameTextItems { get; set; }

        [JsonProperty("LongTextItems")]
        public List<LongTextItem> LongTextItems { get; set; }

        [JsonProperty("FrontOfPackGDA")]
        public object FrontOfPackGDA { get; set; }

        [JsonProperty("DisplayOrder")]
        public object DisplayOrder { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Memo")]
        public List<Memo> Memo { get; set; }

        [JsonProperty("NameLookups")]
        public List<NameLookup> NameLookups { get; set; }

        [JsonProperty("StructuredNutrition")]
        public object StructuredNutrition { get; set; }

        [JsonProperty("NumericNutrition")]
        public List<NumericNutrition> NumericNutrition { get; set; }

        [JsonProperty("NameTextLookups")]
        public List<NameLookup> NameTextLookups { get; set; }

        [JsonProperty("Statements")]
        public List<NameLookup> Statements { get; set; }

        [JsonProperty("TaggedMemo")]
        public object TaggedMemo { get; set; }

        [JsonProperty("TaggedLongTextItems")]
        public List<TaggedLongTextItem> TaggedLongTextItems { get; set; }

        [JsonProperty("TextualNutrition")]
        public List<TextualNutrition> TextualNutrition { get; set; }
    }

    public partial class NameLookup
    {
        [JsonProperty("NameText")]
        public List<NameText> NameText { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("DisplayOrder")]
        public object DisplayOrder { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("NameValueText")]
        public List<NameValueText> NameValueText { get; set; }

        [JsonProperty("NameValue")]
        public List<NameValue> NameValue { get; set; }

        [JsonProperty("Statement")]
        public List<Name> Statement { get; set; }
    }

    public partial class NameText
    {
        [JsonProperty("Name")]
        public Name Name { get; set; }

        [JsonProperty("Text")]
        public Text Text { get; set; }
    }

    public partial class Text
    {
        [JsonProperty("base")]
        public object Base { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("lang")]
        public object Lang { get; set; }

        [JsonProperty("space")]
        public string Space { get; set; }
    }

    public partial class NameValueText
    {
        [JsonProperty("Text")]
        public Text Text { get; set; }

        [JsonProperty("Name")]
        public OtherName Name { get; set; }

        [JsonProperty("Value")]
        public Name Value { get; set; }
    }

    public partial class OtherName
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }

    public partial class NameValue
    {
        [JsonProperty("Name")]
        public OtherName Name { get; set; }

        [JsonProperty("Value")]
        public Name Value { get; set; }
    }

    public partial class Name
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Code")]
        public object Code { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }

    public partial class LongTextItem
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DisplayOrder")]
        public object DisplayOrder { get; set; }

        [JsonProperty("MimeType")]
        public string MimeType { get; set; }

        [JsonProperty("Text")]
        public List<Text> Text { get; set; }
    }

    public partial class Memo
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("DisplayOrder")]
        public object DisplayOrder { get; set; }

        [JsonProperty("MimeType")]
        public string MimeType { get; set; }

        [JsonProperty("base")]
        public object Base { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("lang")]
        public object Lang { get; set; }

        [JsonProperty("space")]
        public string Space { get; set; }
    }

    public partial class NumericNutrition
    {
        [JsonProperty("NutrientValues")]
        public List<NutrientValue> NutrientValues { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("DisplayOrder")]
        public object DisplayOrder { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Per100Unit")]
        public long Per100Unit { get; set; }

        [JsonProperty("Per100UsedHeading")]
        public object Per100UsedHeading { get; set; }

        [JsonProperty("Per100Heading")]
        public string Per100Heading { get; set; }

        [JsonProperty("Per100UnitSpecified")]
        public bool Per100UnitSpecified { get; set; }

        [JsonProperty("PerServingHeading")]
        public object PerServingHeading { get; set; }
    }

    public partial class NutrientValue
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Per100Used")]
        public object Per100Used { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Per100")]
        public Per100 Per100 { get; set; }

        [JsonProperty("PerServing")]
        public object PerServing { get; set; }
    }

    public partial class Per100
    {
        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("Qualifier")]
        public object Qualifier { get; set; }

        [JsonProperty("ValueSpecified")]
        public bool ValueSpecified { get; set; }
    }

    public partial class TaggedLongTextItem
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DisplayOrder")]
        public object DisplayOrder { get; set; }

        [JsonProperty("MimeType")]
        public object MimeType { get; set; }

        [JsonProperty("Tags")]
        public object Tags { get; set; }

        [JsonProperty("Text")]
        public List<Text> Text { get; set; }
    }

    public partial class TextualNutrition
    {
        [JsonProperty("Headings")]
        public List<string> Headings { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DisplayOrder")]
        public object DisplayOrder { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Nutrient")]
        public List<Nutrient> Nutrient { get; set; }
    }

    public partial class Nutrient
    {
        [JsonProperty("Name")]
        public List<string> Name { get; set; }

        [JsonProperty("Values")]
        public List<string> Values { get; set; }
    }

    public partial class Identity
    {
        [JsonProperty("DefaultLanguage")]
        public string DefaultLanguage { get; set; }

        [JsonProperty("ProductCodes")]
        public List<ProductCode> ProductCodes { get; set; }

        [JsonProperty("Compliance")]
        public Compliance Compliance { get; set; }

        [JsonProperty("DiagnosticDescription")]
        public DiagnosticDescription DiagnosticDescription { get; set; }

        [JsonProperty("Subscription")]
        public Subscription Subscription { get; set; }

        [JsonProperty("TargetMarkets")]
        public List<TargetMarket> TargetMarkets { get; set; }
    }

    public partial class ProductCode
    {
        [JsonProperty("Scheme")]
        public string Scheme { get; set; }

        [JsonProperty("Qualifier")]
        public object Qualifier { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }

    public partial class Compliance
    {
        [JsonProperty("EU1169_2011")]
        public long EU11692011 { get; set; }

        [JsonProperty("EU1169_2011Specified")]
        public bool EU11692011Specified { get; set; }
    }

    public partial class Subscription
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }

    public partial class TargetMarket
    {
        [JsonProperty("Code")]
        public string Code { get; set; }
    }

    public partial class Brandbank
    {
        public static Brandbank FromJson(string json) => JsonConvert.DeserializeObject<Brandbank>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Brandbank self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
