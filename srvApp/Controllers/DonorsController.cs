using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace srvApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        public static List<Donor> donorsList = new List<Donor>() { new Donor() { Id = 3, Name = "רייכמן", Address = "קנדה" },
                                                                    new Donor() { Id = 2, Name = "וינרב חיים", Address = "לונדון" },
                                                                  new Donor() { Id = 3, Name = "יוסי כהנוב", Address = "מונטריאול" },
                                                                   new Donor() { Id = 3, Name = "הורוביץ", Address = "שוויץ" },
                                                                    new Donor() { Id = 3, Name = "חיימסון", Address = "בלגיה" },
                                                                      new Donor() { Id = 3, Name = "החפץ בעילום שמו", Address = "ישראל" }
                                                                                                                                 };
        // GET: api/<DonorsController>
        [HttpGet]
        public IEnumerable<Donor> Get()
        {
            
            return donorsList;
        }

        //// GET api/<DonorsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<DonorsController>
        [HttpPost]
        public int Post([FromBody] Donor d)
        {
            donorsList.Add(d);
            return d.Id;
        }

        // PUT api/<DonorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Donor donor)
        {
            donorsList.ForEach(d =>
            {
                if (d.Id == id)
                {
                    d.Name = donor.Name;
                    d.Address = donor.Address;
                   
                };
            });
        }

        // DELETE api/<DonorsController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var d = donorsList.FirstOrDefault(x => x.Id == id);
            
            GiftsController.giftsList.RemoveAll(x => x.Donor == d);
            donorsList.Remove(d);
            return true;
        }
    }
}
