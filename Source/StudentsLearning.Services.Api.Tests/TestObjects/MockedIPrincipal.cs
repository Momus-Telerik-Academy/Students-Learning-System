namespace StudentsLearning.Services.Api.Tests.TestObjects
{
    #region

    using System.Security.Principal;

    #endregion

    internal class MockedIPrincipal : IPrincipal
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