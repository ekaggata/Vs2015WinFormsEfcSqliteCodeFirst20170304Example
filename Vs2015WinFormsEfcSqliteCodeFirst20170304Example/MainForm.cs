using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Vs2015WinFormsEfcSqliteCodeFirst20170304Example.Model;

namespace Vs2015WinFormsEfcSqliteCodeFirst20170304Example
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mainButton_Click(object sender, EventArgs e)
        {
            // Delete all the records from both of the tables
            using (var context = new Vs2015WinFormsEfcSqliteCodeFirst20170304ExampleContext())
            {
                foreach (var person in context.People)
                    context.Remove(person);

                foreach (var city in context.Cities)
                    context.Remove(city);

                context.SaveChanges();
            }

            // Insert some cities records and some people records referencing them
            using (var context = new Vs2015WinFormsEfcSqliteCodeFirst20170304ExampleContext())
            {
                var praha = new City { Name = "Praha" };

                var london = new City { Name = "London" };

                var madrid = new City { Name = "Madrid" };

                var jan = new Person { Name = "Jan", City = praha };

                var john = new Person { Name = "John", City = london };

                var juan = new Person { Name = "Juan", City = madrid };

                context.Cities.AddRange(praha, london, madrid);

                context.People.AddRange(jan, john, juan);

                context.SaveChanges();
            }

            // Select a previously inserted city record,
            // insert a new person record referencing it,
            // update a previously inserted person (specify the surname) 
            using (var context = new Vs2015WinFormsEfcSqliteCodeFirst20170304ExampleContext())
            {
                // Pay attention to the Include(city => city.People) part
                // simple context.Cities.Single(city => city.Name == "London"); used instead
                // would return the city but its .People list would be null.
                // Also make sure to handle cases when there are more or less than one records
                // meeting to the request conditions in the production code
                var london = context.Cities.Include(city => city.People).Single(city => city.Name == "London");

                var peter = new Person { Name = "Peter", City = london };

                var john = london.People.Single(person => person.Name == "John");

                john.Surname = "Smith";

                context.Add(peter);

                context.Update(john);

                context.SaveChanges();
            }
        }
    }
}
