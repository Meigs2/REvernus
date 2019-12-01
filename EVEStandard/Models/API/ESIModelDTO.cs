using System;

namespace EVEStandard.Models.API
{
    public class ESIModelDTO<T>
    {
        public T Model { get; set; }
        public bool NotModified { get; set; }
        public string ETag { get; set; }
        public string Language { get; set; }
        public DateTimeOffset? Expires { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public int MaxPages { get; set; }
        public int RemainingErrors { get; set; }
    }
}
