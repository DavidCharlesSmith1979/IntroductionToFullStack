using System;
using FluentMigrator;

namespace Demo.Migrations.Migrations
{
    [Migration(20210709180100)]
    public class AddAddress : Migration
    {
        public override void Up()
        {
            Create.Table("Address")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Line1").AsString()
                .WithColumn("Line2").AsString()
                .WithColumn("Line3").AsString()
                .WithColumn("County").AsString()
                .WithColumn("Postcode").AsString();
        }

        public override void Down()
        {
            Delete.Table("Address");
        }
    }
}
