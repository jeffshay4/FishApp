using System.ComponentModel.DataAnnotations;
namespace FishAppAPI.Entities
{
    public class Locations
    {
        //Chat GPT: I am converting SQL server stored procedures to apis in ASP.NET Core 8. I need to convert this table to a class. Give me the code
        
        public int LocationID { get; set; } // IDENTITY(1,1) NOT NULL
        public string Name { get; set; }     // nvarchar(255) NOT NULL
        public string State { get; set; }    // nvarchar(255) NOT NULL
        public bool? Boat { get; set; }      // bit NULL
        public decimal? Depth { get; set; }  // decimal(6, 2) NULL
    }
}
