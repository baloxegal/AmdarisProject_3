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
    public class MessageService
    {
        private readonly IRepository<Message, long> _repository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public MessageService(IRepository<Message, long> repository, UserManager<User> userManager, IMapper mapper)
        {
            _repository = repository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<MessageDto>>> GetEntities()
        {
            var result = await _repository.GetEntities();
            var listResult = result.Value.ToList();

            var dtoResult = listResult.Select(res => _mapper.Map(res, new MessageDto())).ToList();

            for (int i = 0; i < listResult.Count; i++)
            {
                for (int j = 0; j < dtoResult.Count; j++)
                {
                    if (listResult[i].Sender != null && listResult[i].Receiver != null)
                    {
                        dtoResult[j].Sender = listResult[i].Sender.UserName;
                        dtoResult[j].Receiver = listResult[i].Receiver.UserName;
                    }
                }
            }

            return dtoResult;
        }

        public async Task<ActionResult<MessageDto>> GetEntity(long identityKey)
        {
            var result = await _repository.GetEntity(identityKey);

            var dtoResult = _mapper.Map(result.Value, new MessageDto());

            if (result.Value.Sender != null)
                dtoResult.Sender = result.Value.Sender.UserName;
            if (result.Value.Receiver != null)
                dtoResult.Receiver = result.Value.Receiver.UserName;

            return dtoResult;
        }

        public async Task<IActionResult> UpdateEntity(MessageDto entity, long identityKey)
        {
            var baseEntity = await _repository.GetEntity(identityKey);
            if (baseEntity.Value == null)
            {
                return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't exist" });
            }

            _mapper.Map(entity, baseEntity.Value);

            if (baseEntity.Value.Sender != null)
                baseEntity.Value.Sender.UserName = entity.Sender;
            if (baseEntity.Value.Receiver != null)
                baseEntity.Value.Receiver.UserName = entity.Receiver;

            return await _repository.Save();
        }

        public async Task<IActionResult> CreateEntity(MessageDto entity)
        {
            var baseEntity = _mapper.Map(entity, new Message());

            var sender = _userManager.FindByNameAsync(entity.Sender);

            baseEntity.Sender = sender.Result;

            var receiver = _userManager.FindByNameAsync(entity.Receiver);

            baseEntity.Receiver = receiver.Result;

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
