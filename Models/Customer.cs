using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace data_keeping_system_for_petrol_pump.Models
{
  public class Customer
  {
    [Key]
    public int id { get; set; }
        [Required(ErrorMessage ="Customer Name is Required")]
       /* [RegularExpression("^[A-Za-Z]{1,40}")]*/
    public string name { get; set; }

        [Required(ErrorMessage ="Customer Address is required")]
    public string address { get; set; }

    public Boolean isActive { get; set; }

    public List<Sales> sale { get; set; }
    public Customer()
    {
      sale = new List<Sales>();
      isActive = true;
    }

  }
}
