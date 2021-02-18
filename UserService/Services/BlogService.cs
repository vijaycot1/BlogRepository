using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.ContextModel;
using UserService.Models;

namespace UserService.Services
{
    public interface IBlogService
    {
        Task<string> PostBlog(BlogModel post);
        Task<string> EditBlog(BlogModel post);
        Task<string> PostComment(PostCommentModel comment);
        Task<bool> CreateCategory(CategoryModel obj);
        Task<bool> DeleteBlog(int blogId);
        Task<List<BlogModel>> GetAllBlogs();
    }
    public class BlogService : IBlogService
    {
        private readonly DBContext _context;

        public BlogService(DBContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateCategory(CategoryModel obj)
        {
            try
            {
                var cat = new Category
                {
                    Content = obj.Content,
                    MetaTitle = obj.MetaTitle,
                    Title = obj.Title,
                    Slug = obj.Slug,
                    ParentId = obj.ParentId,
                    Active=true
                };
                _context.Categories.Add(cat);
                var res = await _context.SaveChangesAsync();
                if (res > 0) return true;
                else return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> DeleteBlog(int blogId)
        {
            try
            {
              var postToBeDeleted = _context.Posts.Where(x => x.Id == blogId || x.ParentId == blogId);
                if (postToBeDeleted.Any())
                {
                    foreach (var x in postToBeDeleted)
                    {
                        x.Active = false;
                    }
                }

                var res = await _context.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }
                else return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public async Task<string> EditBlog(BlogModel post)
        {
            try
            {
                var updPost = _context.Posts.Where(x => x.Id == post.Id).FirstOrDefault();
                if(updPost!=null)
                {
                    updPost.Content = string.IsNullOrEmpty(post.Content)?updPost.Content: post.Content;
                    updPost.ParentId = post.ParentId?? updPost.ParentId;
                    updPost.MetaTitle = string.IsNullOrEmpty(post.MetaTitle)? updPost.MetaTitle: post.MetaTitle;
                    updPost.Title = string.IsNullOrEmpty(post.Title) ? updPost.Title : post.Title;
                    updPost.ModifiedDate = DateTime.Now;
                    updPost.Summary = string.IsNullOrEmpty(post.Summary) ? updPost.Summary : post.Summary;
                    updPost.Slug = string.IsNullOrEmpty(post.Slug) ? updPost.Slug : post.Slug;
                    updPost.Published = post.Published?? updPost.Published;
                    updPost.PublishedDate = post.PublishedDate?? updPost.PublishedDate;
                    var res = await _context.SaveChangesAsync();
                    if (res > 0) return "Success";
                    else return "Failed to Update Post";
                }
                else
                {
                    return "Post not found or has been modified";
                }
                
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<BlogModel>> GetAllBlogs()
        {
            return await _context.Posts.Where(x => x.Active)
                .Select(m=>new BlogModel { 
                    Id=m.Id,
                    AuthorId=m.AuthorId,
                    Content=m.Content,
                    MetaTitle=m.MetaTitle,
                    ParentId=m.ParentId,
                    Published=m.Published,
                    PublishedDate=m.PublishedDate,
                    Slug=m.Slug,
                    Summary=m.Summary,
                    Title=m.Title,
                    Author=string.Concat(m.Author.FirstName," ",m.Author.MiddleName," ",m.Author.LastName)
                    
                }).ToListAsync();
        }

        public async Task<string> PostBlog(BlogModel post)
        {
            try
            {
                var newPost = new Post
                {
                    AuthorId=post.AuthorId,
                    Content=post.Content,
                    ParentId=post.ParentId,
                    MetaTitle=post.MetaTitle,
                    Title=post.Title,
                    CreatedDate=DateTime.Now,
                    Summary=post.Summary,
                    Slug=post.Slug,
                    Published=post.Published,
                    PublishedDate= (post.Published == null || post.Published == false) ? null : (DateTime?)DateTime.Now,
                    Active=true
                };
                _context.Posts.Add(newPost);
                var res = await _context.SaveChangesAsync();
                if (res > 0) return "Success";
                else return "Failed to Save Post";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<string> PostComment(PostCommentModel comment)
        {
            try
            {
                var comm = new PostComment
                {
                    Active = true,
                    Content = comment.Content,
                    CreatedAt = DateTime.Now,
                    ParentId = comment.ParentId,
                    Published = comment.Published,
                    Title = comment.Title,
                    PostId = comment.PostId,
                    PublishedAt = (comment.Published == null || comment.Published == false) ? null : (DateTime?)DateTime.Now
                };

                _context.PostComments.Add(comm);
                var res = await _context.SaveChangesAsync();
                if (res > 0) return "Success";
                else return "Failed to Save Post";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
