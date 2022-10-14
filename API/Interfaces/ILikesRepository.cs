using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUerId, int likedUserId);
        Task<AppUser> GetUserWithLikes(int sourceUserId);
        Task<PagedList<LikeDTO>> GetUserLikes(LikesParams likesParams);
    }
}