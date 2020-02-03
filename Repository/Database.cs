using System.Collections.Generic;
using Repository.Abstractions;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Repository
{
    

    public class Database : IDatabase
    {
        public void CreateTablesAndTestData(IDbConnectionFactory dbFactory)
        {
            using (var db = dbFactory.Open())
            {
                db.ExecuteNonQuery("CREATE TABLE Enterprise(Id INTEGER PRIMARY KEY, Name TEXT NOT NULL);");
                db.ExecuteNonQuery("CREATE TABLE People (Id INTEGER PRIMARY KEY, Name TEXT NOT NULL, EnterpriseId INTEGER);");
                
                db.ExecuteNonQuery("CREATE TABLE ContactList (PeopleId INTEGER , ContactId INTEGER);");
                //db.ExecuteNonQuery("ALTER TABLE People ADD CONSTRAINT FK_PeopleEnterprise add FOREIGN KEY (EnterpriseId) REFERENCES Enterprise (Id); ");
                //db.ExecuteNonQuery("ALTER TABLE ContactList Foreign Key (PersonId) REFERENCES People (Id); ");
                //db.ExecuteNonQuery("ALTER TABLE ContactList add Foreign Key (ContactId) REFERENCES People (Id); ");
                //db.ExecuteNonQuery("ALTER TABLE ContactList add PRIMARY KEY(PersonId, ContactId); ");

                db.ExecuteNonQuery("INSERT INTO Enterprise (id, name) VALUES (1,'ACME Inc');");
                db.ExecuteNonQuery("INSERT INTO Enterprise (id,name) VALUES (2,'Generic Enterprises');");
                db.ExecuteNonQuery("INSERT INTO Enterprise (id,name) VALUES (3,'BnL');");

                db.ExecuteNonQuery("INSERT INTO People (id,name, EnterpriseId) VALUES (1,'Willifred Manford',1);");
                db.ExecuteNonQuery("INSERT INTO People (id,name, EnterpriseId) VALUES (2,'John Doe',1);");
                db.ExecuteNonQuery("INSERT INTO People (id,name, EnterpriseId) VALUES (3,'Manfred Man',1);");

                db.ExecuteNonQuery("INSERT INTO People (id,name, EnterpriseId) VALUES (4,'Willy Nelson',2);");
                db.ExecuteNonQuery("INSERT INTO People (id,name, EnterpriseId) VALUES (5,'Bruce Springsteen',2);");
                db.ExecuteNonQuery("INSERT INTO People (id,name, EnterpriseId) VALUES (6,'Billy Idol',2);");
                db.ExecuteNonQuery("INSERT INTO People (id,name, EnterpriseId) VALUES (7,'James Blunt',3);");
                db.ExecuteNonQuery("INSERT INTO People (id,name, EnterpriseId) VALUES (8,'Odd Nordståga',3);");
                db.ExecuteNonQuery("INSERT INTO People (id,name, EnterpriseId) VALUES (9,'Little Steven',3);");

                db.ExecuteNonQuery("INSERT INTO ContactList (PeopleId, ContactId) VALUES (1, 4);");
                db.ExecuteNonQuery("INSERT INTO ContactList (PeopleId, ContactId) VALUES (1, 8);");
                db.ExecuteNonQuery("INSERT INTO ContactList (PeopleId, ContactId) VALUES (4, 1);");
                db.ExecuteNonQuery("INSERT INTO ContactList (PeopleId, ContactId) VALUES (4, 2);");
                db.ExecuteNonQuery("INSERT INTO ContactList (PeopleId, ContactId) VALUES (4, 8);");
                db.ExecuteNonQuery("INSERT INTO ContactList (PeopleId, ContactId) VALUES (4, 9);");

            }
        }

        public List<string> ExampleData(IDbConnectionFactory dbFactory)
        {
            using (var db = dbFactory.Open())
            {
                return db.Select<string>("SELECT name FROM people");
            }
        }
    }
}
