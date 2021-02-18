using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Services;

namespace MyAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        public IBlogService _blogService;
        public BlogController(IBlogService bService)
        {
            _blogService = bService;
        }

        // Create Category
        [Authorize]
        [HttpPost("CreateCategory")]
        public async Task<ActionResult<string>> CreateCategory(CategoryModel obj)
        {

            var res = await _blogService.CreateCategory(obj);
            if (res) return "Category Created SUccessfully";
            else return "Failed to Create Category";
        }

        // Create Post
        [Authorize]
        [HttpPost("PostBlog")]
        public async Task<ActionResult<string>> PostBlog(BlogModel obj)
        {

            var res = await _blogService.PostBlog(obj);
            if (res.Equals("Success")) return Ok("Blog Posted Successfully");
            else return BadRequest(res);
        }

        // Edit Post
        [Authorize]
        [HttpPut("EditBlog")]
        public async Task<ActionResult<string>> EditBlog(BlogModel obj)
        {

            var res = await _blogService.EditBlog(obj);
            if (res.Equals("Success")) return Ok("Blog Updated Successfully");
            else return BadRequest(res);
        }

        // Delete Post
        [Authorize]
        [HttpDelete("DeleteBlog")]
        public async Task<ActionResult<string>> DeleteBlog(int blogId)
        {

            var res = await _blogService.DeleteBlog(blogId);
            if (res) return Ok("Blog Deleted Successfully");
            else return BadRequest("Problem in deleting blog");
        }

        // Create Post
        [Authorize]
        [HttpPost("PostComment")]
        public async Task<ActionResult<string>> PostComment(PostCommentModel obj)
        {

            var res = await _blogService.PostComment(obj);
            if (res.Equals("Success")) return Ok("Comment Posted Successfully");
            else return BadRequest(res);
        }

        // Get All Blogs
        [Authorize]
        [HttpGet("GetBlogs")]
        public async Task<List<BlogModel>> GetBlogs()
        {

            var res = await _blogService.GetAllBlogs();
            return res;
        }


    }
}
