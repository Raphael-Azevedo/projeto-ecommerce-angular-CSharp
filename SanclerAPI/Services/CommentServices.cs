using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SanclerAPI.DTO;
using SanclerAPI.HATEOAS.Conteiners;
using SanclerAPI.Models;
using SanclerAPI.Repository.Interfaces;
using SanclerAPI.Services.Interfaces;

namespace SanclerAPI.Services
{
    public class CommentServices : ICommentServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly HATEOAS.HATEOAS _hateoas;

        public CommentServices(IMapper mapper, IUnitOfWork uof, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _uof = uof;
            _userManager = userManager;

            _hateoas = new HATEOAS.HATEOAS("localhost:5001/api/v1/Comments");
            _hateoas.AddAction("GET_INFO", "GET");
            _hateoas.AddAction("DELETE_COMMENTS", "DELETE");
        }

        public async Task Create(CreateCommentDTO commentDto, ClaimsPrincipal User)
        {
            var username = _userManager.GetUserName(User);
            var user = await _userManager.FindByNameAsync(username);

            var comment = _mapper.Map<Comments>(commentDto);
            comment.Product = await _uof.ProductRepository.GetById(p => p.Id == commentDto.ProductId);
            comment.UserId = user.Id;
            comment.Username = user.UserName;
            comment.Email = user.Email;

            await _uof.CommentRepository.Add(comment);
            await _uof.Commit();
        }

        public async Task Delete(int id, ClaimsPrincipal User)
        {
            var username = _userManager.GetUserName(User);
            var user = await _userManager.FindByNameAsync(username);

            var comment = await _uof.CommentRepository.GetById(c => c.Id == id);
            var isAdmin = await this.IsAdmin(user);

            if (comment.UserId == user.Id || isAdmin == true)
            {
                _uof.CommentRepository.Delete(comment);
                await _uof.Commit();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public async Task<CommentConteiner> GetById(int id)
        {
            var Comment = await _uof.CommentRepository.GetByIdWithProduct(id);
            var commentDto = _mapper.Map<ReadCommentDTO>(Comment);
            commentDto.Product = Comment.Product;

            CommentConteiner conteiner = new CommentConteiner();
            conteiner.comments = commentDto;
            conteiner.links = _hateoas.GetActions(id.ToString());
            return conteiner;
        }

        public async Task<IEnumerable<CommentConteiner>> GetByProductId(int id, int skip, int take)
        {
            var Comments = await _uof.CommentRepository.GetByProductId(id, skip: skip, take: take);
            List<CommentConteiner> conteiners = new List<CommentConteiner>();

            foreach (var comment in Comments)
            {
                var commentDto = _mapper.Map<ReadCommentDTO>(comment);
                commentDto.Product = comment.Product;

                CommentConteiner conteiner = new CommentConteiner();
                conteiner.comments = commentDto;
                conteiner.links = _hateoas.GetActions(comment.Id.ToString());

                conteiners.Add(conteiner);
            }
            return conteiners;
        }

        public async Task<IEnumerable<CommentConteiner>> GetByUserId(int skip, int take, ClaimsPrincipal User)
        {
            var username = _userManager.GetUserName(User);
            var user = await _userManager.FindByNameAsync(username);
            var Comments = await _uof.CommentRepository.GetByUserId(user.Id, skip: skip, take: take);
            List<CommentConteiner> conteiners = new List<CommentConteiner>();

            foreach (var comment in Comments)
            {
                var commentDto = _mapper.Map<ReadCommentDTO>(comment);
                commentDto.Product = comment.Product;


                CommentConteiner conteiner = new CommentConteiner();
                conteiner.comments = commentDto;
                conteiner.links = _hateoas.GetActions(comment.Id.ToString());

                conteiners.Add(conteiner);
            }
            return conteiners;
        }

        public async Task Update(int id, UpdateCommentDTO commentDto, ClaimsPrincipal User)
        {
            var username = _userManager.GetUserName(User);
            var user = await _userManager.FindByNameAsync(username);
            var comment = await _uof.CommentRepository.GetById(c => c.Id == id);
            var isAdmin = await this.IsAdmin(user);
            
            if(isAdmin == true || comment.UserId == user.Id)
            {
                comment.Comment = commentDto.Comment;
                _uof.CommentRepository.Update(comment);
                await _uof.Commit();
            }
            else 
            {
                throw new InvalidOperationException();
            }
            
        }

        private async Task<bool> IsAdmin(IdentityUser User)
        {
            var roles = await _userManager.GetRolesAsync(User);
            bool isAdmin = false;
            foreach(var role in roles)
            {
                if(role == "admin")
                {
                    isAdmin = true;
                }
            }
            return isAdmin;
        }
    }
}