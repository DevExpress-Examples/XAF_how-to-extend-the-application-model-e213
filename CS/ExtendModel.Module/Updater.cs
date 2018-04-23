using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace ExtendModel.Module {
    public class Updater : ModuleUpdater {
        public Updater(ObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            Person person1 = ObjectSpace.FindObject<Person>(CriteriaOperator.Parse("LastName == 'Devon'"));
            if(person1 == null) {
                person1 = ObjectSpace.CreateObject<Person>();
                person1.FirstName = "Ann";
                person1.LastName = "Devon";
                person1.Birthday = new DateTime(1986, 7, 15);
                person1.Save();
            }
            Person person2 = ObjectSpace.FindObject<Person>(CriteriaOperator.Parse("LastName == 'Clarks'"));
            if(person2 == null) {
                person2 = ObjectSpace.CreateObject<Person>();
                person2.FirstName = "Ann";
                person2.LastName = "Clarks";
                person2.Birthday = new DateTime(1980, 6, 30);
                person2.Save();
            }
            Person person3 = ObjectSpace.FindObject<Person>(CriteriaOperator.Parse("LastName == 'Tellitson'"));
            if(person3 == null) {
                person3 = ObjectSpace.CreateObject<Person>();
                person3.FirstName = "Mary";
                person3.LastName = "Tellitson";
                person3.Birthday = new DateTime(1983, 9, 16);
                person3.Save();
            }
        }
    }
}
