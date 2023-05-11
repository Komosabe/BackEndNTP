﻿using BackEndTutorialNTP.Data;
using BackEndTutorialNTP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BackEndTutorialNTP.Interfaces;
using BackEndTutorialNTP.Models.FamilyMember;
using BackEndTutorialNTP.Entities;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace BackEndTutorialNTP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyMemberController : Controller
    {

        private readonly IFamilyMemberService _familyMemberService;
        private readonly IConfiguration _configuration;

        public static FamilyMember familyMember = new FamilyMember();


        public FamilyMemberController(
            IFamilyMemberService familyMemberService,
            IConfiguration configuration)
        {
            _familyMemberService = familyMemberService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAllFamilyMembers()
        {
            var familyMembers = _familyMemberService.GetAll();
            return Ok(familyMembers);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdFamilyMember(int id)
        {
            var familyMember = _familyMemberService.GetById(id);
            return Ok(familyMember);
        }

        [HttpPost]
        public IActionResult CreateFamilyMember(CreateRequestFamilyMember model)
        {
            _familyMemberService.Create(model);
            return Ok(new { message = "Family member created" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFamilyMember(int id, UpdateRequestFamilyMember model)
        {
            _familyMemberService.Update(id, model);
            return Ok(new { message = "Family member updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFamilyMember(int id)
        {
            _familyMemberService.Delete(id);
            return Ok(new { message = "Family member deleted" });
        }

        [HttpPost("register")]
        public async Task<ActionResult<FamilyMember>> Register(CreateRequestFamilyMember request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            familyMember.Username = request.Username;
            familyMember.PasswordHash = passwordHash;
            familyMember.PasswordSalt = passwordSalt;

            return Ok(familyMember);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(CreateRequestFamilyMember request)
        {
            if (familyMember.Username != request.Username)
            {
                return BadRequest("User not found.");
            }

            if (!VerifyPasswordHash(request.Password, familyMember.PasswordHash, familyMember.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(familyMember);

            return Ok(token);
        }

        private string CreateToken(FamilyMember user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature); 

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}