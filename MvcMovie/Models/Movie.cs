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
    public class Movie
    {
        public int ID { get; set; }


        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        [CustomDate]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Genere of Movie")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        public string Genre { get; set; }

        [Display(Name = "Price of Ticket")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ConvertEmptyStringToNull = true, ApplyFormatInEditMode = true)]
        [Range(1.0, 1000.0,ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Price { get; set; }

        [Display(Name = "Movie Rating")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        public string Rating { get; set; }


        public virtual ICollection<Cinema> Cinemas { get; set; }
        /*
         * virtual – dzięki temu atrybutowi, do tego pola zostanie zastosowane tzw. lazy loading. 
         * Oznacza to, że dane dla tego pola zostaną wczytane, dopiero wtedy, gdy się do nich odwołamy.
         */

    /*
     * ICollection<Service> Services – interfejs ICollection pozwala na określenie relacji jeden do wielu, 
     * dzięki niemu samochód, będzie mógł odwoływać się do wielu krotek z tabeli Services. 
     * Gdybyśmy definiowali relację jeden do jeden, należałoby oczywiście opuścić interfejs ICollection, 
     * pozostawiający tym samym klasę Service, identycznie jak w modelu Service.
     */

    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }

    }

    public class CustomDateAttribute : RangeAttribute
    {
    public CustomDateAttribute()
      : base(typeof(DateTime),
              DateTime.Now.AddYears(-119).ToShortDateString(),
              DateTime.Now.ToShortDateString())
    { }

    }




}
 