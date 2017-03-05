using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vs2015WinFormsEfcSqliteCodeFirst20170304Example.Model
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [InverseProperty("City")]
        public virtual ICollection<Person> People { get; set; }
    }
}
