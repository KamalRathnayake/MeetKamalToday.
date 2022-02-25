using Azure;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;

namespace MKTCoursesAPI.Controllers
{
    public class Course
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class Article
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        [HttpGet(Name = "Get Courses")]
        public IActionResult Get()
        {
            var courses = 
            return Ok(courses);
        }
    }


    public class CourseContentService
    {
        private string conString = "DefaultEndpointsProtocol=https;AccountName=mktcourses;AccountKey=xfm60K4xfGjPSnX7Fft69gwi7EtbMDCkCVApFiOJvsMABAFqEhAGgwjk/SS+TkecrtD/q3GyJQVBY1zNkiVX0Q==;EndpointSuffix=core.windows.net";

        public List<Course> GetCourses()
        {
            var courses = new List<Course>();
            var tableName = "Courses";

            var tableClient = new TableClient(conString, tableName);
            Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>();
            foreach (TableEntity qEntity in queryResultsFilter)
            {
                var course = new Course()
                {
                    Id = qEntity.GetString("RowKey"),
                    Name = qEntity.GetString("Name"),
                    Description = qEntity.GetString("Description"),
                };
                courses.Add(course);
            }
            return courses;
        }
        public List<Course> GetArticles(string courseId)
        {
            var courses = new List<Course>();
            var tableName = "Articles";

            var tableClient = new TableClient(conString, tableName);
            Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: $"CourseId eq {courseId}");
            foreach (TableEntity qEntity in queryResultsFilter)
            {
                var course = new Course()
                {
                    Id = ,
                    Name = qEntity.GetString("Name"),
                    Description = qEntity.GetString("Description"),
                };
                courses.Add(course);
            }
            return courses;
        }
    }
}