using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PostService
    {
        public static List<PostDTO> Get() {
            var posts = DataAccess.PostData().Get();
            var mapper = MapperService<Post, PostDTO>.GetMapper();
            var data = mapper.Map<List<PostDTO>>(posts);
            return data;
        }
        public static PostDTO Get(int id)
        {
            var post = DataAccess.PostData().Get(id);
            var mapper = MapperService<Post, PostDTO>.GetMapper();
            var data = mapper.Map<PostDTO>(post);
            return data;
        }
        public static bool Add(PostDTO obj) {
            var mapper = MapperService<PostDTO, Post>.GetMapper();
            var data = mapper.Map<Post>(obj);
            return DataAccess.PostData().Add(data);
        }
    }
}
