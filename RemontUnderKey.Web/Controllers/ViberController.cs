using System.Web.Http.Results;
using System.Web.Http;
using Viber.Bot;
using RemontUnderKey.Web.Models;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Controllers
{
    public class ViberController : ApiController
    {
        // при обращении по этому маршруту будет обрабатываться инф-я, присланная вайбером
        [Route(@"remontunderkey.azurewebsites/api/viber/update")] // webhook uri part
        public async Task<OkResult> Update([FromBody] string update)
        {
            return Ok();
        }
    }
}
