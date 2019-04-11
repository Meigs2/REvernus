using System;

namespace EVEStandard.Models.API
{
    public class APIResponse
    {
        public int MaxPages { get; set; }
        public string JSONString { get; set; }
        public bool LegacyWarning { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }
        public DateTimeOffset? Expires { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public string ETag { get; set; }
        public bool NotModified { get; set; }
        public int ErrorsTimeRemaining { get; set; }
    }
}
