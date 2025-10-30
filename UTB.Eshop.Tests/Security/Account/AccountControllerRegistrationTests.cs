using Microsoft.AspNetCore.Mvc;
using Moq;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Infrastructure.Identity.Enums;
using UTB.Eshop.Web.Areas.Security.Controllers;
using UTB.Eshop.Web.Controllers;
using Xunit;

namespace UTB.Eshop.Tests.Security.Account
{
    public class AccountControllerRegistrationTests
    {
        [Fact]
        public void AddUserToDatabase()
        {
            // Arrange
            var mock = new Mock<ISecurityService>();
            mock.Setup(x => x.FindUserByUsername("test")).ReturnsAsync(new UTB.Eshop.Infrastructure.Identity.User());
            var controller = new AccountController(mock.Object);

            // Act
            var result = controller.Register(new RegisterViewModel
            {
                Username = "test",
                Password = "test",
                Email = "test@email.com"
            });
        }
    }
}
