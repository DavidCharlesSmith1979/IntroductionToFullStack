using System;
using FluentMigrator;

namespace Demo.Migrations.Migrations
{
    [Migration(20210709180102)]
    public class AddForeignKey_User_Address : Migration
    {
        public override void Up()
        {
            Create.ForeignKey("FK_User_Address")
                .FromTable("User").ForeignColumn("AddressId")
                .ToTable("Address").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_User_Address");
        }
    }
}
