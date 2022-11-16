using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SanclerAPI.DTO;
using SanclerAPI.HATEOAS.Conteiners;
using SanclerAPI.Models;
using SanclerAPI.Models.Enums;
using SanclerAPI.Repository.Interfaces;
using SanclerAPI.Services.Interfaces;

namespace SanclerAPI.Services
{
    public class AssessmentServices : IAssessmentServices
    {
        private readonly IUnitOfWork _uof;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly HATEOAS.HATEOAS _hateoas;

        public AssessmentServices(IUnitOfWork uof, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _uof = uof;
            _userManager = userManager;
            _mapper = mapper;

            _hateoas = new HATEOAS.HATEOAS("localhost:5001/api/v1/Assessment");
            _hateoas.AddAction("GET_INFO", "GET");
            _hateoas.AddAction("DELETE_COMMENTS", "DELETE");
        }

        public async Task Create(CreateAssessmentDTO assessmentDto, ClaimsPrincipal User)
        {
            var username = _userManager.GetUserName(User);
            var user = await _userManager.FindByNameAsync(username);
            
            Assessments assessment = _mapper.Map<Assessments>(assessmentDto);
            assessment.Product = await _uof.ProductRepository.GetById(p => p.Id == assessmentDto.ProductId);
            assessment.UserId = user.Id;
            assessment.Username = user.UserName;
            assessment.Email = user.Email;
            await _uof.AssessmentRepository.Add(assessment);
            await _uof.Commit();
        }

        public async Task Delete(int id, ClaimsPrincipal User)
        {
            var username = _userManager.GetUserName(User);
            var user = await _userManager.FindByNameAsync(username);
            var assessment = await _uof.AssessmentRepository.GetById(c => c.Id == id);
            var isAdmin = await this.IsAdmin(user);

            if (assessment.UserId == user.Id || isAdmin == true)
            {
                _uof.AssessmentRepository.Delete(assessment);
                await _uof.Commit();
            }
            else
            {
                throw new InvalidOperationException();
            }            
        }

        public async Task<AssessmentConteiner> GetById(int id)
        {
            var Assessment = await _uof.AssessmentRepository.GetByIdWithProduct(id);
            var assessmentDto = _mapper.Map<ReadAssessmentDTO>(Assessment);

            AssessmentConteiner conteiner = new AssessmentConteiner();
            conteiner.asssesments = assessmentDto;
            conteiner.links = _hateoas.GetActions(id.ToString());
            return conteiner;
        }

        public async Task<IEnumerable<AssessmentConteiner>> GetByProductId(int id, int skip, int take)
        {
            var Assessments = await _uof.AssessmentRepository.GetByProductId(id, skip: skip, take: take);
            List<AssessmentConteiner> conteiners = new List<AssessmentConteiner>();
            foreach (var asssesment in Assessments)
            {
                var assessmentDto = _mapper.Map<ReadAssessmentDTO>(asssesment);
                AssessmentConteiner conteiner = new AssessmentConteiner();
                conteiner.asssesments = assessmentDto;
                conteiner.links = _hateoas.GetActions(asssesment.Id.ToString());

                conteiners.Add(conteiner);
            }
            return conteiners;
        }

        public async Task<IEnumerable<AssessmentConteiner>> GetByUserId(int skip, int take, ClaimsPrincipal User)
        {
            var username = _userManager.GetUserName(User);
            var user = await _userManager.FindByNameAsync(username);
            var Assessments = await _uof.AssessmentRepository.GetByUserId(user.Id, skip: skip, take: take);
            List<AssessmentConteiner> conteiners = new List<AssessmentConteiner>();
            foreach (var asssesment in Assessments)
            {
                var assessmentDto = _mapper.Map<ReadAssessmentDTO>(asssesment);

                AssessmentConteiner conteiner = new AssessmentConteiner();
                conteiner.asssesments = assessmentDto;
                conteiner.links = _hateoas.GetActions(asssesment.Id.ToString());

                conteiners.Add(conteiner);
            }
            return conteiners;
        }

        public async Task Update(int id, UpdateAssessmentsDTO assessmentsDto, ClaimsPrincipal User)
        {
            var username = _userManager.GetUserName(User);
            var user = await _userManager.FindByNameAsync(username);
            var assessment = await _uof.AssessmentRepository.GetById(c => c.Id == id);
            var isAdmin = await this.IsAdmin(user);

            if (assessment.UserId == user.Id || isAdmin == true)
            {
                assessment.Evaluation = (Evaluations)assessmentsDto.Evaluation;
                _uof.AssessmentRepository.Update(assessment);
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
            foreach (var role in roles)
            {
                if (role == "admin")
                {
                    isAdmin = true;
                }
            }
            return isAdmin;
        }
    }
}