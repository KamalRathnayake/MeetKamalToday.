using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApp.Data.Model
{
    public class Course
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public string Description {  get; set; }
        public string Title {  get; set; }
        public string Url {  get; set; }
        public DateTime Created {  get; set; }
        public DateTime Updated {  get; set; }
    }
}
