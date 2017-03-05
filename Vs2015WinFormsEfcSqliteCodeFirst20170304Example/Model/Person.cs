using System.ComponentModel.DataAnnotations.Schema;

namespace Vs2015WinFormsEfcSqliteCodeFirst20170304Example.Model
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int? CityId { get; set; }

        [InverseProperty("People")]
        public virtual City City { get; set; }
    }
}
