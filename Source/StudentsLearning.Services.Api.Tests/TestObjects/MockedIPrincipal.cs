namespace StudentsLearning.Services.Api.Tests.TestObjects
{
    using System.Security.Principal;

    class MockedIPrincipal : IPrincipal
    {
        public IIdentity Identity
        {
            get
            {
                return new MockedIIdentity();
            }
        }

        public bool IsInRole(string role)
        {
            return false;
        }
    }
}
