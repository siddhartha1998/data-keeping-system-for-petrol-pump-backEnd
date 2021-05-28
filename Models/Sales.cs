using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace data_keeping_system_for_petrol_pump.Models
{
  public class Sales
  {
    [Key]
    public int id { get; set; }

    public DateTime date { get; set; }

        [Required(ErrorMessage ="Sales Item name is required")]
    public string itemName { get; set; }

        [Required(ErrorMessage ="Quantity must be needed")]
    public int quantity { get; set; }

        [Required(ErrorMessage ="Rate is Required")]
    public float rate { get; set; }

    public float total { get; set; }

    public string remarks { get; set; }

    public Boolean isActive { get; set; }

    [ForeignKey("Customer")]
    public int customerId { get; set; }

    public Sales()
    {
      isActive = true;
    }

  }
}
