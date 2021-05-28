using data_keeping_system_for_petrol_pump.DataAccess;
using data_keeping_system_for_petrol_pump.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
  public class SalesController : ControllerBase
  {

    PetrolPumpDbContext ppDbContext = new PetrolPumpDbContext();
    // GET: api/<SalesController>
    [HttpGet]
    public IActionResult Get()
    {
      List<Sales> salesCollections = (from sal in ppDbContext.sales
                                      where sal.isActive == true
                                      select sal).ToList<Sales>();

            return Ok(salesCollections);
    }

    // GET api/<SalesController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      var sale = (from s in ppDbContext.sales
                  where s.id == id &&
                        s.isActive == true
                  select s).FirstOrDefault();
    
      return Ok(sale);
    }

    // POST api/<SalesController>
    [HttpPost]
    public IActionResult Post([FromBody] Sales salesObj)
    {
      ppDbContext.sales.Add(salesObj);
      ppDbContext.SaveChanges();
      var sal = (from s in ppDbContext.sales
                 where s.isActive == true
                 select s).FirstOrDefault();

      return Ok(sal);
    }

    // PUT api/<SalesController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Sales salObj)
    {
      var sal = (from s in ppDbContext.sales
                 where s.id == id &&
                       s.isActive == true
                 select s).FirstOrDefault();
      if (sal != null)
      {
        
        sal.itemName = salObj.itemName;
        sal.quantity = salObj.quantity;
        sal.rate = salObj.rate;
        sal.total = salObj.total;
        sal.remarks = salObj.remarks;

        ppDbContext.SaveChanges();

                var data = (from s in ppDbContext.sales
                           where 
                                 s.isActive == true
                           select s);

                return Ok(data);
      }
      else
      {
        return StatusCode(StatusCodes.Status404NotFound, "Id " + id + " not found");
      }

    }

    // DELETE api/<SalesController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var salDel = (from sal in ppDbContext.sales
                    where sal.id == id &&
                          sal.isActive == true
                    select sal).FirstOrDefault();
      if (salDel != null)
      {
        salDel.isActive = false;
        ppDbContext.SaveChanges();

        var sa = (from sal in ppDbContext.sales
                      where sal.isActive == true
                      select sal).FirstOrDefault();
        return Ok(sa);
      }
      else
      {
        return StatusCode(StatusCodes.Status404NotFound, "Id " + id + " not found");
      }
    }
  }
}
