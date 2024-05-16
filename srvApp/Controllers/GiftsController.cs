using Microsoft.AspNetCore.Mvc;
using srvApp.Models;
using System.Drawing;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace srvApp.Controllers;

[Route("api/[controller]")]
[ApiController]

public class GiftsController : ControllerBase
{
    public static List<Donor> donorsList = DonorsController.donorsList;

    public static List<Gift> giftsList = new List<Gift>() { new Gift() { Id = 3, Name = "סידור כלה", Donor = donorsList[0], Price = 15,img="11" }, 
                                                            new Gift() { Id = 2, Name = "סט כלים של פוד אפיל", Donor = donorsList[1], Price = 30,img="14" }, 
                                                            new Gift() { Id = 1, Name = "טיסה לצרפת", Donor = donorsList[1], Price = 25 ,img="15"},
                                                            new Gift() { Id = 5, Name = "צלומי חוץ לילדים", Donor = donorsList[0], Price = 10 ,img="5"},
                                                            new Gift() { Id = 4, Name = "ריהוט חדר ילדים", Donor = donorsList[3], Price = 15 ,img="1"},
     new Gift() { Id = 7, Name = "מחשב נייד", Donor = donorsList[4], Price = 15 ,img="4"},
     new Gift() { Id = 6, Name = "ריהוט חדר ילדים", Donor = donorsList[2], Price = 15 ,img="1"}};


    // GET: api/<PresentsController>
    [HttpGet]
    public IEnumerable<Gift> Get()
    {
        return giftsList;
    }

    //// GET api/<DonorsController>/5
    [HttpGet("{id}")]
    public List<User> Get(int id)
    {
        var x=giftsList.FirstOrDefault(x => x.Id == id).Customers;
        return x;
    }
    // POST api/<PresentsController>
    [HttpPost]
    public int Post([FromBody] Gift g)
    {
        giftsList.Add(g);
        return g.Id;
    }

    // PUT api/<PresentsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Gift gift)//[FromBody] User user) )
    {
        
        giftsList.ForEach(g =>
        {
            if (g.Id == id)
            {
                g.Name = gift.Name;
                g.Donor = gift.Donor;
                g.Price = gift.Price;
                g.img = gift.img;
            };
        });

    }
    // PUT api/<PresentsController>/5
    [Route("addCustomers/{id}")]
    [HttpPut]
    public void Put(int id, [FromBody] User user)
    {
        var gift = giftsList.FirstOrDefault(x => x.Id == id);
        gift.Customers.Add(user);

    }

    // DELETE api/<PresentsController>/5
    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        var p = giftsList.FirstOrDefault(x => x.Id == id);
        giftsList.Remove(p);
        return true;
    }

   
}

