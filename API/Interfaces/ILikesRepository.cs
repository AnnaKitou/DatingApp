using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUerId, int likedUserId);
        Task<AppUser> GetUserWithLikes(int sourceUerId);
        Task<IEnumerable<LikeDTO>> GetUserLikes(string predicate, int userId);
    }
}