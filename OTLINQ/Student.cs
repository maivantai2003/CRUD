using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OTLINQ
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId {  get; set; }
        [ForeignKey("ClassId")]
        public Class Class { get; set; }
    }
}
