using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAspireApplicationAufait.ApiService.Application.Interfaces;
using MyAspireApplicationAufait.ApiService.Controller;
using MyAspireApplicationAufait.AppHost.Domain;

namespace MyProject.Tests
{
    public class RoleControllerTests
    {
        private RoleController _controller;
        private IRoleAppService _mockRoleService;
        public ApplicationDbContext _context;

        public RoleControllerTests(ApplicationDbContext Appcontext, IRoleAppService roleService)
        {
            _mockRoleService = roleService;
            Appcontext = _context;
        }

        [SetUp]
        public void SetUp()
        {
            // Set up an in-memory database for ApplicationDbContext
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: "TestDb")
                            .Options;

            _context = new ApplicationDbContext(options);



            // Set up the controller with ApplicationDbContext (or mock services if needed)

            _controller = new RoleController(_context, _mockRoleService);
        }
        [Test]
        public async Task CreateRole_ReturnsCreatedId_WithNewRole()
        {
            // Arrange
            var newRoleName = "Manager";
            RoleDto roleDto = new RoleDto
            {
                RoleName = newRoleName
            };

            // Act
            var result = await _controller.CreateRole(roleDto);

            // Assert
            // Ensure the result is of type long (assuming it returns the created role's ID)
            Assert.Equals(result,result>0);  // Ensure the result is of type long

            long createdRoleId = (long)result;  // Cast to long

            Assert.Equals(createdRoleId, createdRoleId>0);  // Ensure the ID is positive (created role ID)

            // Verify the new role was created in the in-memory database
            var roleInDb = await _context.ApplicationUser.FirstOrDefaultAsync(r => r.Id == createdRoleId);
            Assert.Equals(roleInDb, roleInDb!=null);  // Ensure the role was actually created
            Assert.Equals(newRoleName, roleInDb.Username);  // Ensure the role name matches
        }


        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
            _context.Dispose();
        }
    }
}
