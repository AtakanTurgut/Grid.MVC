using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grid_MVC.Models
{
    public class Person
    {
        [GridMvc.DataAnnotations.GridHiddenColumn]
        public int Id { get; set; }

        [GridMvc.DataAnnotations.GridColumn(Title = "Ad Soyad", FilterEnabled = true, SortEnabled = true)]
        public string FullName { get; set; }

        [GridMvc.DataAnnotations.GridColumn(Title = "Yaş", SortEnabled = true)]
        public int Age { get; set; }

        [GridMvc.DataAnnotations.GridColumn
            (Title = "Doğum Tarihi", FilterEnabled = true, SortEnabled = true, Format = "{0:dd.MM.yyyy}")]
        public DateTime BirthDate { get; set; }

        [GridMvc.DataAnnotations.NotMappedColumn]
        public bool IsActive { get; set; }

        public static List<Person> GetAllPersons(int count)
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                var birthDate = FakeData.DateTimeData.GetDatetime
                    (DateTime.Now.AddYears(-50), DateTime.Now.AddYears(-5));

                persons.Add(new Person()
                {
                    Id = i,
                    FullName = FakeData.NameData.GetFullName(),
                    Age = (int)(DateTime.Now.Year) - (birthDate.Year),
                    BirthDate = birthDate,
                    IsActive = (i % 2 == 0) ? true : false,
                });
            }

            return persons;
        }
    }
}