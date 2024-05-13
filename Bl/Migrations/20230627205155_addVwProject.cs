using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class addVwProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view VwProjects
                                    as
                                    SELECT dbo.TbProject.ProjectId, dbo.TbProject.ProjectName, dbo.TbProject.Description, dbo.TbProject.ImageName, dbo.TbProject.Link, dbo.TbProject.CreatedBy, dbo.TbProject.CreatedDate, dbo.TbProject.CurrentState, 
                                    dbo.TbProject.UpdatedBy, dbo.TbProject.UpdatedDate, dbo.TbProject.CategoryId, dbo.TbCategory.CategoryName
                                    FROM     dbo.TbProject INNER JOIN
                                    dbo.TbCategory ON dbo.TbProject.CategoryId = dbo.TbCategory.CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
