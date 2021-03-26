using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3B.Core.ViewModels;

namespace Task3B.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        protected ResponseViewModel GetResponse(string Message = "Done", object Data = null)
        {
            var Response = new ResponseViewModel();
            Response.Status = true;
            Response.Message = Message;
            Response.Data = Data;
            return Response;
        }
    }
}
