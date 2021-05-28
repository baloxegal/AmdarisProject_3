using AmdarisProject_3.Domain.Models;
using AmdarisProject_3.Domain.Models.Dtos;
using AmdarisProject_3.Infrastucture.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisProject_3.API.Services
{
    public class RelationshipService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Relationship, long> _repository;
        private readonly IMapper _mapper;

        public RelationshipService(IRepository<Relationship, long> repository, UserManager<User> userManager, IMapper mapper)
        {
            _repository = repository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<RelationshipDto>>> GetEntities()
        {
            var result = await _repository.GetEntities();
            var listResult = result.Value.ToList();

            var dtoResult = listResult.Select(res => _mapper.Map(res, new RelationshipDto())).ToList();
            
            for(int i = 0; i < listResult.Count; i++)
            {
                for (int j = 0; j < dtoResult.Count; j++)
                {
                    if (listResult[i].Initiator != null && listResult[i].Respondent != null)
                    {
                        dtoResult[j].Initiator = listResult[i].Initiator.UserName;
                        dtoResult[j].Respondent = listResult[i].Respondent.UserName;
                    }
                }
            }

            return dtoResult;             
        }

        public async Task<ActionResult<RelationshipDto>> GetEntity(long identityKey)
        {
            var result = await _repository.GetEntity(identityKey);

            var dtoResult = _mapper.Map(result.Value, new RelationshipDto());

            if (result.Value.Initiator != null)
                dtoResult.Initiator = result.Value.Initiator.UserName;
            if (result.Value.Respondent != null)
                dtoResult.Respondent = result.Value.Respondent.UserName;

            return dtoResult;
        }

        public async Task<IActionResult> UpdateEntity(RelationshipDto entity, long identityKey)
        {
            var baseEntity = await _repository.GetEntity(identityKey);
            if (baseEntity.Value == null)
            {
                return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't exist" });
            }

            _mapper.Map(entity, baseEntity.Value);

            if (baseEntity.Value.Initiator != null)
                baseEntity.Value.Initiator.UserName = entity.Initiator;
            if (baseEntity.Value.Respondent != null)
                baseEntity.Value.Respondent.UserName = entity.Respondent;

            return await _repository.Save();
        }

        public async Task<IActionResult> CreateEntity(RelationshipDto entity)
        {
            var baseEntity = _mapper.Map(entity, new Relationship());

            var initiator = _userManager.FindByNameAsync(entity.Initiator);

            baseEntity.Initiator = initiator.Result;

            var respondent = _userManager.FindByNameAsync(entity.Respondent);

            baseEntity.Respondent = respondent.Result;

            try
            {
                return await _repository.CreateEntity(baseEntity);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"Entity wasn't created. " + ex.Message });
            }
        }

        public async Task<IActionResult> DeleteEntity(long identityKey)
        {
            var baseEntity = await _repository.GetEntity(identityKey);
            if (baseEntity.Value == null)
            {
                return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't exist" });
            }

            try
            {
                return await _repository.Remove(baseEntity.Value);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't deleted. Error in database. " + ex.Message });
            }
        }
    }
}
