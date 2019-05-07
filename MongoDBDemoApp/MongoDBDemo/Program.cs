using System;

namespace MongoDBDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MongoHelper db = new MongoHelper("AddressBook");

            //PersonModel person = new PersonModel
            //{
            //    FirstName = "Joe",
            //    LastName = "Smith",
            //    PrimaryAddress = new AddressModel
            //    {
            //        SteerAddress = "101 Oak Street",
            //        City = "Scranton",
            //        State = "PA",
            //        ZipCode = "18512"
            //    }
            //};

            //db.InsertRecord("Users", person);



            var records = db.LoadRecords<NameModel>("Users");

            foreach (var record in records)
            {
                Console.WriteLine($"{record.FirstName} {record.LastName}");

                //if (record.PrimaryAddress != null)
                //{
                //    Console.WriteLine(record.PrimaryAddress.City);
                //}
                Console.WriteLine();
            }


            //var oneRecord = db.LoadRecordById<PersonModel>("Users", new Guid("a7d88cda-0c73-41e6-b015-a13a433076cd"));

            //oneRecord.DateOfBirth = new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            //db.UpsertRecord("Users", oneRecord.Id, oneRecord);

            //db.DeleteRecord<PersonModel>("Users", oneRecord.Id);

            Console.ReadLine();
        }
    }
}
