using AmdarisProject_3.Domain.Models;
using AmdarisProject_3.Domain.Models.Dtos;
using AmdarisProject_3.Infrastucture.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisProject_3.API.Services
{
    public class UserService
    {
        private readonly IRepository<User, string> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User, string> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<UserDto>>> GetEntities()
        {
            var result = await _repository.GetEntities();

            return result.Value.Select(res => _mapper.Map(res, new UserDto())).ToList();             
        }

        public async Task<ActionResult<UserDto>> GetEntity(string identityKey)
        {
            var result = await _repository.GetEntity(identityKey);

            return _mapper.Map(result.Value, new UserDto());
        }

        public async Task<ActionResult<UserDto>> GetEntityByUserName(string userNameKey)
        {
            var result = await _repository.GetEntities();
            if(result.Value == null && result.Value.Any())
                return new BadRequestObjectResult(new { message = $"Entity with userName key {userNameKey} doesn't exist" });

            var resultList = result.Value.ToList();

            if (resultList.Exists(e => e.UserName == userNameKey)) {
                var resultUser = resultList.Find(e => e.UserName == userNameKey);
                return new OkObjectResult(new { entity = resultUser, message = $"Entity with userName key {userNameKey} found" });
            }
            else
                return new BadRequestObjectResult(new { message = $"Entity with userName key {userNameKey} doesn't exist" });
        }

        public async Task<IActionResult> UpdateEntity(UserDto entity, string identityKey)
        {
            var baseEntity = await _repository.GetEntity(identityKey);
            if (baseEntity.Value == null)
            {
                return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't exist" });
            }

            _mapper.Map(entity, baseEntity.Value);

            return await _repository.Save(); ;
        }

        public async Task<IActionResult> UpdateEntityByUserName(UserDto entity, string userNameKey)
        {
            var result = await _repository.GetEntities();
            if (result.Value == null && result.Value.Any())
                return new BadRequestObjectResult(new { message = $"Entity with userName key {userNameKey} doesn't exist" });

            var resultList = result.Value.ToList();

            if (resultList.Exists(e => e.UserName == userNameKey))
            {
                var resultUser = resultList.Find(e => e.UserName == userNameKey);

                _mapper.Map(entity, resultUser);                

                return await _repository.Save();
            }
            else
                return new BadRequestObjectResult(new { message = $"Entity with userName key {userNameKey} doesn't exist" });
        }

        public async Task<IActionResult> CreateEntity(UserDto entity)
        {
            var baseEntity = _mapper.Map(entity, new User());
            try
            {
                return await _repository.CreateEntity(baseEntity);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"Entity wasn't created. " + ex.Message });
            }
        }

        public async Task<IActionResult> DeleteEntity(string identityKey)
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

        public async Task<IActionResult> DeleteEntityByUserName(string userNameKey)
        {
            var result = await _repository.GetEntities();
            if (result.Value == null && result.Value.Any())
                return new BadRequestObjectResult(new { message = $"Entity with userName key {userNameKey} doesn't exist" });

            var resultList = result.Value.ToList();

            if (resultList.Exists(e => e.UserName == userNameKey))
            {
                var resultUser = resultList.Find(e => e.UserName == userNameKey);
                try
                {
                    return await _repository.Remove(resultUser);
                }
                catch (Exception ex)
                {
                    return new BadRequestObjectResult(new { message = $"Entity with identity key {userNameKey} doesn't deleted. Error in database. " + ex.Message });
                }
            }
            else
                return new BadRequestObjectResult(new { message = $"Entity with userName key {userNameKey} doesn't exist" }); 
        }
    }
}
