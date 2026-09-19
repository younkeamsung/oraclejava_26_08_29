using BlazorApp2.Client.Models;

namespace BlazorApp2.Client.Interfaces;

public interface IBlogRepository
{
    // 게시글 개수
    Task<int> GetBlogPostCountAsync();
    // 게시글 순번
    Task<List<BlogPost>> GetBlogPostsAsync(
        int numberOfPosts, int startIndex);
    // 상세보기
    Task<BlogPost?> GetBlogPostAsync(string id);
    // 수정
    Task<BlogPost?> SaveBlogPostAsync(BlogPost item);
    // 삭제
    Task DeleteBlogPostAsync(string id);
}
