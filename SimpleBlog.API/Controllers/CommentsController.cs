using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleBlog.API.Infrastructure;
using SimpleBlog.API.Models;

namespace SimpleBlog.API.Controllers 
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase 
    {
        public readonly ICommentsRepository _repo;
        public CommentsController(ICommentsRepository repo) {
            _repo = repo;
        }

        // api/comments/1
        [HttpGet]
        public async Task<ActionResult<string>> Get(int postId) {
            return JsonConvert.SerializeObject(await _repo.GetAll<Comment>(postId));
        }

    }
}