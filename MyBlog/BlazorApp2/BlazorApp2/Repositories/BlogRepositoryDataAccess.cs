using BlazorApp2.Client.Interfaces;
using BlazorApp2.Client.Models;
using BlazorApp2.Database;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Repositories;

public class BlogRepositoryDataAccess(
    IDbContextFactory<BlogDbContext> factory) : IBlogRepository
{
    public async Task DeleteBlogPostAsync(string id)
    {
        using var context = factory.CreateDbContext();
        if (int.TryParse(id, out int intid))
        {
            var item = await context.BlogPosts.FindAsync(id);
            if(item != null)
            {
                context.BlogPosts.Remove(item);
                await context.SaveChangesAsync();
            }
        }

    }

    public async Task<BlogPost?> GetBlogPostAsync(string id)
    {
        using var context = factory.CreateDbContext();
        if(int.TryParse(id, out int intid))
        {
            var item = await context.BlogPosts.FirstOrDefaultAsync
                (p => p.Id == intid);
            if(item != null)
            {
                return ConvertBlogPostToDto(item);
            }
        }
        return null;
    }

    public async Task<int> GetBlogPostCountAsync()
    {
        using var context = factory.CreateDbContext();
        return await context.BlogPosts.CountAsync();
    }

    public async Task<List<BlogPost>> GetBlogPostsAsync(int numberOfPosts, int startIndex)
    {
        using var context = factory.CreateDbContext();
        return await context.BlogPosts.OrderByDescending(
            p => p.PublishDate).Skip(startIndex)
            .Take(numberOfPosts).Select(p =>
            ConvertBlogPostToDto(p)).ToListAsync();
    }

    public async Task<BlogPost?> SaveBlogPostAsync(BlogPost item)
    {
        using var context = factory.CreateDbContext();
        if(item.Id == null)
        {
            // 추가
            var newitem = new BlazorApp2.Database.Entities.BlogPost()
            {
                Title = item.Title,
                Text = item.Text,
                PublishDate = item.PublishDate
            };
            context.Add(newitem);
            await context.SaveChangesAsync();
            item.Id = newitem.Id.ToString();
            return item;
        }
        else
        {
            // 수정
            var existingitem = await context.
                BlogPosts.FirstOrDefaultAsync(p => p.Id ==
                    Convert.ToInt32(item.Id));
            if (existingitem != null)
            {
                existingitem.Title = item.Title;
                existingitem.Text = item.Text;  
                existingitem.PublishDate = item.PublishDate;

            }
            await context.SaveChangesAsync();
            return item;
        }
        // return item;
    }

    // 데이터베이스/엔티티스/블로그포스트에 있는 필드에 item으로 리스트변수를 생성해서 리스트를 생성
    private static BlogPost ConvertBlogPostToDto(
        BlazorApp2.Database.Entities.BlogPost item)
    {
        return new BlogPost()
        {
            Id = item.Id.ToString(),
            Title = item.Title,
            Text = item.Text,
            PublishDate = item.PublishDate
        };
    }
}
