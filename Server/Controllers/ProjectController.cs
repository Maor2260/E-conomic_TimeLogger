using Facade.Project;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    public class ProjectController : Controller, IProjectFacade
    {
    }
}
