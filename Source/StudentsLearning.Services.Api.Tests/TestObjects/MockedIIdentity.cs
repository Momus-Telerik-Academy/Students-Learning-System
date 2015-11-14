using System.Security.Principal;

namespace StudentsLearning.Services.Api.Tests.TestObjects
{
    public class MockedIIdentity : IIdentity
    {
        public string AuthenticationType
        {
            get
            {
                return string.Empty;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return "Test User";
            }
        }
    }
}
