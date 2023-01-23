using aspnetcore_n_tier.BLL.CustomExceptions;
using aspnetcore_n_tier.BLL.Services.IServices;
using aspnetcore_n_tier.DAL.Repositories.IRepositories;
using aspnetcore_n_tier.DTO.DTOs;
using aspnetcore_n_tier.Entity.Entities;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace aspnetcore_n_tier.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<UserDTO> AddUser(UserToAddDTO userToAddDTO)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<UsertDetailsDTO>> GetAllUser()
        {
            var users = await _userRepository.GetList(x => x.role);
            var AllUSers = _mapper.Map<List<UsertDetailsDTO>>(users);
            return AllUSers;
        }

        public Task<UserDTO> GetUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        
        public async Task<UserDTO> LogIn(UserDTO input)
        {
            var user = await _userRepository.Get(x => x.Username == input.Username && x.Password == input.Password);
            var authUser = _mapper.Map<UserDTO>(user);
            if (user == null)
            {
                return null;
            }
            else 
            {
                return authUser;
            }

        }

        public async Task<bool> UpdateUser(UsertDetailsUpdateDTO userToUpdateDTO)
        {
        var userToReturn = await _userRepository.Get(x => x.Email == userToUpdateDTO.Email, y=>y.role);
            userToReturn.FullName = userToUpdateDTO.FullName;
            userToReturn.Email = userToUpdateDTO.Email;
            userToReturn.IsActive = userToUpdateDTO.IsActive;
            userToReturn.RoleId = userToUpdateDTO.RoleID;
           var res= await _userRepository.Update(userToReturn);
            return true;

        }

        //public async Task<UserDTO> GetUser(int userId)
        //{
        //    var userToReturn = await _userRepository.Get(x => x.UserId == userId);

        //    if (userToReturn is null)
        //    {
        //        throw new UserNotFoundException();
        //    }

        //    return _mapper.Map<UserDTO>(userToReturn);
        //}

        //public async Task<UserDTO> AddUser(UserToAddDTO userToAddDTO)
        //{
        //    var addedUser = await _userRepository.Add(_mapper.Map<User>(userToAddDTO));

        //    return _mapper.Map<UserDTO>(addedUser);
        //}









        //public async Task<UserDTO> UpdateUser(UserDTO userToUpdateDTO)
        //{
        //    var user = await _userRepository.Get(x => x.UserId == userToUpdateDTO.UserId);

        //    if (user is null)
        //    {
        //        throw new UserNotFoundException();
        //    }

        //    var userToUpdate = _mapper.Map<User>(userToUpdateDTO);

        //    return _mapper.Map<UserDTO>(await _userRepository.Update(userToUpdate));
        //}

        //public async Task DeleteUser(int userId)
        //{
        //    var userToDelete = await _userRepository.Get(x => x.UserId == userId);

        //    if (userToDelete is null)
        //    {
        //        throw new UserNotFoundException();
        //    }

        //    await _userRepository.Delete(userToDelete);
        //}
    }
}
