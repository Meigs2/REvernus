namespace EVEStandard.Models.SSO
{
    public class Authorization
    {
        public string SignInURI { get; set; }
        public string ExpectedState { get; set; }
        public string ReturnedState { get; set; }
        public string AuthorizationCode { get; set; }
        public string CodeVerifier { get; set; }
    }
}
