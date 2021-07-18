using System;
using FluentMigrator;

namespace Demo.Migrations.Migrations
{
    [Migration(20210709180101)]
    public class AddUser : Migration
    {
        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString()
                .WithColumn("LastName").AsString()
                .WithColumn("AddressId").AsInt64().Nullable();
        }

        public override void Down()
        {
            Delete.Table("User");
        }
    }
}
