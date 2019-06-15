using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;
/* https://docs.microsoft.com/pl-pl/dotnet/api/system.componentmodel.dataannotations?redirectedfrom=MSDN&view=netframework-4.8 */

namespace MvcMovie.Models
{
    public class Cinema
    {

        public int Id { get; set; }

        public int MovieID { get; set; }

        [Display(Name = "Cinema Name")]
        public string Name { get; set; }

        [Display(Name = "Street")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        public string Street { get; set; }

        [Display(Name = "City")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        public string City { get; set; }

        [Display(Name = "Soonest:")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        [CustomDate2]
        public DateTime Date { get; set; }

        



        public virtual Movie Movie { get; set; }
    }

    public class CustomDate2Attribute : RangeAttribute
    {
        public CustomDate2Attribute()
          : base(typeof(DateTime),
                  DateTime.Now.AddYears(-1).ToShortDateString(),
                  DateTime.Now.AddYears(2).ToShortDateString())

        { }

    }
}