using MyShop.Data.Repositories;
using MyShop.Model.Models;
using System.Collections.Generic;
using MyShop.Data.Infrastructure;
using System.Linq;

namespace MyShop.Service
{
    public interface IPostService
    {
        void Add(Post post);

        void Update(Post post);

        void Delete(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GettAllPaging(int page, int pageSize, out int totalRow);

        Post GetById(int id);

        IEnumerable<Post> GettAllByTagPaging(string tag,int page, int pageSize, out int totalRow);

        void SaveChagnes();
    }

    public class PostService : IPostService
    {
        //cần gọi repository nào thì ta gọi ở trên đây
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWord;
        public PostService(IPostRepository postRepository,IUnitOfWork unitOfWord)
        {
            _postRepository = postRepository;
            _unitOfWord = unitOfWord;

        }
        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            //getall() không cũng được nhưng ta truyền vào 1 chuỗi do IRepository quy định, nó có thể khi lấy ra DS bài viết thì nó cũng lấy ra được danh mục bài viết
            return _postRepository.GetAll(new string[] { "CategoryID" });
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public IEnumerable<Post> GettAllByTagPaging(string tag,int page, int pageSize, out int totalRow)
        {
            //TODO: Sellect all post by tag
            return _postRepository.GetMultiPaging(x => x.Status,out totalRow,page,pageSize);
        }

        public IEnumerable<Post> GettAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public void SaveChagnes()
        {
            _unitOfWord.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}