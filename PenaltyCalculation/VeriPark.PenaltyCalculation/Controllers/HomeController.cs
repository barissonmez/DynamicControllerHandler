using System.Linq;
using System.Web.Mvc;
using VeriPark.PenaltyCalculation.DBContext;
using VeriPark.PenaltyCalculation.Models;


namespace VeriPark.PenaltyCalculation.Controllers
{
    public class HomeController : Controller
    {
        private VeriParkDBContext ctx = new VeriParkDBContext();
        
        public ActionResult Index()
        {
            var model = new PenaltyCalculationOutModel();
            
            ctx.Countries.ToList().ForEach(c=> model.Countries.Add(new PenaltyCalculationOutModel.CountryModel()
            {
                CountryId = c.Id,
                Name = c.Name
            }));

            return View(model);
        }

        [HttpPost]
        public JsonResult GetResult(PenaltyCalculationInModel data)
        {
            var model = new PenaltyCalculationInModel();

            var country = ctx.Countries.FirstOrDefault(a => a.Id.Equals(data.CountryId));

            if (country != null)
            {
                model.CultureCode = country.CultureCode;
                model.CheckOutDate = data.CheckOutDate;
                model.ReturnDate = data.ReturnDate;
                model.Holidays = country.Holidays.Select(a => a.HolidayDate).ToList();
                model.Amount = country.PenaltyAmount;
                model.WeekendDays = country.WeekendDays.Select(a => a.DayOfWeek).ToList();
            }

            var result = Facilities.Facilities.Calculate(model);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}