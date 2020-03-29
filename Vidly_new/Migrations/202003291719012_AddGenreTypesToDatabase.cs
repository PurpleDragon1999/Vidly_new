namespace Vidly_new.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreTypesToDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (2, 'Thriller')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (5, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
