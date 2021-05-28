using data_keeping_system_for_petrol_pump.DataAccess;
using data_keeping_system_for_petrol_pump.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace data_keeping_system_for_petrol_pump.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("PetrolPumpPolicy")]
  public class CustomerController : ControllerBase
  {

    PetrolPumpDbContext ppDbContext = new PetrolPumpDbContext();
    // GET: api/<CustomerController>
    [HttpGet]
    public IActionResult Get()
    {

      List<Customer> customerCollection = (from cus in ppDbContext.customers
                                where cus.isActive == true
                                select cus).Include(a=>a.sale).ToList<Customer>();
      if (customerCollection != null)
      {
        return Ok(customerCollection);
      }
      else
      {
        return StatusCode(StatusCodes.Status404NotFound, "no data found");
      }
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var custs = (from c in ppDbContext.customers
                     where c.id == id && c.isActive == true
                     select c).Include(c=>c.sale);
      if (custs!=null)
      {
        return Ok(custs);

      }
      else
      {
        return StatusCode(StatusCodes.Status404NotFound, "no data found");
      }

    }

    // POST api/<CustomerController>
    [HttpPost]
    public IActionResult Post([FromBody] Customer customerObj)
    {
      
      ppDbContext.customers.Add(customerObj);
      ppDbContext.SaveChanges();

      var customerCollection = (from c in ppDbContext.customers
                                where c.isActive == true
                                select c);

      return Ok(customerCollection);
    }

    // PUT api/<CustomerController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Customer cusObj)
    {
      var cus = (from c in ppDbContext.customers
                 where c.id == id && c.isActive == true
                 select c).FirstOrDefault();
      if (cus != null)
      {
        cus.name = cusObj.name;
        cus.address = cusObj.address;
        ppDbContext.SaveChanges();

        return Ok(cus);
      }
      else
      {
        return StatusCode(StatusCodes.Status404NotFound, "Id not found");
      }


    }

    // DELETE api/<CustomerController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var cust = (from cus in ppDbContext.customers
                  where cus.id == id && cus.isActive == true
                  select cus)
                  .FirstOrDefault();
      if (cust != null)
      {

        cust.isActive = false;
        ppDbContext.SaveChanges();

        var cs = (from a in ppDbContext.customers
                  where a.isActive == true
                  select a);

        return Ok(cs);
        
      }
      else
      {
        return StatusCode(StatusCodes.Status404NotFound, "Data not found");
      }
    }
  }
}
