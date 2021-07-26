using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpeningHours.Models;
using OpeningHours.Models.RequestModels;
using OpeningHours.Models.ResponseModels;
using OpeningHours.Constants;
using OpeningHours.Helper;
namespace OpeningHours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningHoursController : ControllerBase
    {
        private readonly ILogger<OpeningHoursController> _logger;

        public OpeningHoursController(ILogger<OpeningHoursController> logger)
        {
            _logger = logger;
        }

       

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OpeningHoursResModel))]
        public IActionResult GetOpeningHours(OpeningHoursReqModel openingHoursReqModel)
        {
            #region Modify Req Model
            if (openingHoursReqModel.monday != null && openingHoursReqModel.monday.Count > 0 && openingHoursReqModel.monday[0].type == Constants.RestaurantStatus.Close)
            {
                if (openingHoursReqModel.sunday == null)
                {
                    openingHoursReqModel.sunday = new List<Models.RequestModels.Sunday>();
                }
                openingHoursReqModel.sunday.Add(new Models.RequestModels.Sunday() { type = openingHoursReqModel.monday[0].type, value = openingHoursReqModel.monday[0].value });
                openingHoursReqModel.monday.RemoveAt(0);
            }
            if (openingHoursReqModel.tuesday != null && openingHoursReqModel.tuesday.Count > 0 && openingHoursReqModel.tuesday[0].type == Constants.RestaurantStatus.Close)
            {
                if (openingHoursReqModel.monday == null)
                {
                    openingHoursReqModel.monday = new List<Models.RequestModels.Monday>();
                }
                openingHoursReqModel.monday.Add(new Models.RequestModels.Monday() { type = openingHoursReqModel.tuesday[0].type, value = openingHoursReqModel.tuesday[0].value });
                openingHoursReqModel.tuesday.RemoveAt(0);
            }
            if (openingHoursReqModel.wednesday != null && openingHoursReqModel.wednesday.Count > 0 && openingHoursReqModel.wednesday[0].type == Constants.RestaurantStatus.Close)
            {
                if (openingHoursReqModel.tuesday == null)
                {
                    openingHoursReqModel.tuesday = new List<Models.RequestModels.Tuesday>();
                }
                openingHoursReqModel.tuesday.Add(new Models.RequestModels.Tuesday() { type = openingHoursReqModel.wednesday[0].type, value = openingHoursReqModel.wednesday[0].value });
                openingHoursReqModel.wednesday.RemoveAt(0);
            }
            if (openingHoursReqModel.thursday != null && openingHoursReqModel.thursday.Count > 0 && openingHoursReqModel.thursday[0].type == Constants.RestaurantStatus.Close)
            {
                if (openingHoursReqModel.wednesday == null)
                {
                    openingHoursReqModel.wednesday = new List<Models.RequestModels.Wednesday>();
                }
                openingHoursReqModel.wednesday.Add(new Models.RequestModels.Wednesday() { type = openingHoursReqModel.thursday[0].type, value = openingHoursReqModel.thursday[0].value });
                openingHoursReqModel.thursday.RemoveAt(0);
            }
            if (openingHoursReqModel.friday != null && openingHoursReqModel.friday.Count > 0 && openingHoursReqModel.friday[0].type == Constants.RestaurantStatus.Close)
            {
                if (openingHoursReqModel.thursday == null)
                {
                    openingHoursReqModel.thursday = new List<Models.RequestModels.Thursday>();
                }
                openingHoursReqModel.thursday.Add(new Models.RequestModels.Thursday() { type = openingHoursReqModel.friday[0].type, value = openingHoursReqModel.friday[0].value });
                openingHoursReqModel.friday.RemoveAt(0);
            }
            if (openingHoursReqModel.saturday != null && openingHoursReqModel.saturday.Count > 0 && openingHoursReqModel.saturday[0].type == Constants.RestaurantStatus.Close)
            {
                if (openingHoursReqModel.friday == null)
                {
                    openingHoursReqModel.friday = new List<Models.RequestModels.Friday>();
                }
                openingHoursReqModel.friday.Add(new Models.RequestModels.Friday() { type = openingHoursReqModel.saturday[0].type, value = openingHoursReqModel.saturday[0].value });
                openingHoursReqModel.saturday.RemoveAt(0);
            }
            if (openingHoursReqModel.sunday != null && openingHoursReqModel.sunday.Count > 0 && openingHoursReqModel.sunday[0].type == Constants.RestaurantStatus.Close)
            {
                if (openingHoursReqModel.saturday == null)
                {
                    openingHoursReqModel.saturday = new List<Models.RequestModels.Saturday>();
                }
                openingHoursReqModel.saturday.Add(new Models.RequestModels.Saturday() { type = openingHoursReqModel.sunday[0].type, value = openingHoursReqModel.sunday[0].value });
                openingHoursReqModel.sunday.RemoveAt(0);
            }
            #endregion
            OpeningHoursResModel openingHoursResModel = new OpeningHoursResModel();


            if (openingHoursReqModel.monday != null && openingHoursReqModel.monday.Count > 0)
            {
                for (int i = 0; i < openingHoursReqModel.monday.Count; i+=2)
                {
                    openingHoursResModel.monday.openingHours.Add(openingHoursReqModel.monday[i].value.To12HoursTime() + " - " + openingHoursReqModel.monday[i + 1].value.To12HoursTime());
                }
            }
            else
            {
                openingHoursResModel.monday.openingHours.Add(Constants.RestaurantStatusDisplayLabels.Closed);
            }
            
            if (openingHoursReqModel.tuesday != null && openingHoursReqModel.tuesday.Count > 0)
            {
                for (int i = 0; i < openingHoursReqModel.tuesday.Count; i += 2)
                {
                    openingHoursResModel.tuesday.openingHours.Add(openingHoursReqModel.tuesday[i].value.To12HoursTime() + " - " + openingHoursReqModel.tuesday[i + 1].value.To12HoursTime());
                }
            }
            else
            {
                openingHoursResModel.tuesday.openingHours.Add(Constants.RestaurantStatusDisplayLabels.Closed);
            }

            if (openingHoursReqModel.wednesday != null && openingHoursReqModel.wednesday.Count > 0)
            {
                for (int i = 0; i < openingHoursReqModel.wednesday.Count; i += 2)
                {
                    openingHoursResModel.wednesday.openingHours.Add(openingHoursReqModel.wednesday[i].value.To12HoursTime() + " - " + openingHoursReqModel.wednesday[i + 1].value.To12HoursTime());
                }
            }
            else
            {
                openingHoursResModel.wednesday.openingHours.Add(Constants.RestaurantStatusDisplayLabels.Closed);
            }

            if (openingHoursReqModel.thursday != null && openingHoursReqModel.thursday.Count > 0)
            {
                for (int i = 0; i < openingHoursReqModel.thursday.Count; i += 2)
                {
                    openingHoursResModel.thursday.openingHours.Add(openingHoursReqModel.thursday[i].value.To12HoursTime() + " - " + openingHoursReqModel.thursday[i + 1].value.To12HoursTime());
                }
            }
            else
            {
                openingHoursResModel.thursday.openingHours.Add(Constants.RestaurantStatusDisplayLabels.Closed);
            }

            if (openingHoursReqModel.friday != null && openingHoursReqModel.friday.Count > 0)
            {
                for (int i = 0; i < openingHoursReqModel.friday.Count; i += 2)
                {
                    openingHoursResModel.friday.openingHours.Add(openingHoursReqModel.friday[i].value.To12HoursTime() + " - " + openingHoursReqModel.friday[i + 1].value.To12HoursTime());
                }
            }
            else
            {
                openingHoursResModel.friday.openingHours.Add(Constants.RestaurantStatusDisplayLabels.Closed);
            }

            if (openingHoursReqModel.saturday != null && openingHoursReqModel.saturday.Count > 0)
            {
                for (int i = 0; i < openingHoursReqModel.saturday.Count; i += 2)
                {
                    openingHoursResModel.saturday.openingHours.Add(openingHoursReqModel.saturday[i].value.To12HoursTime() + " - " + openingHoursReqModel.saturday[i + 1].value.To12HoursTime());
                }
            }
            else
            {
                openingHoursResModel.saturday.openingHours.Add(Constants.RestaurantStatusDisplayLabels.Closed);
            }

            if (openingHoursReqModel.sunday != null && openingHoursReqModel.sunday.Count > 0)
            {
                for (int i = 0; i < openingHoursReqModel.sunday.Count; i += 2)
                {
                    openingHoursResModel.sunday.openingHours.Add(openingHoursReqModel.sunday[i].value.To12HoursTime() + " - " + openingHoursReqModel.sunday[i + 1].value.To12HoursTime());
                }
            }
            else
            {
                openingHoursResModel.sunday.openingHours.Add(Constants.RestaurantStatusDisplayLabels.Closed);
            }


            return Ok(openingHoursResModel);
        }
    }
}
