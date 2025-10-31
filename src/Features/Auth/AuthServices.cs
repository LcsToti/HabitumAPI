using HabitumAPI.Exceptions;
using HabitumAPI.Features.Auth.Dtos;
using HabitumAPI.Features.Auth.Interfaces;
using HabitumAPI.Features.Auth.Utils;
using HabitumAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeZoneConverter;

namespace HabitumAPI.Features.Auth;

public class AuthServices(HabitumContext context, ITokenGenerator tokenService) : IAuthServices
{
    private readonly HabitumContext _context = context;
    private readonly ITokenGenerator _tokenServices = tokenService;

    public async Task<string> Register(RegisterRequestDTO dto)
    {
        if (!IsValidTimeZoneId(dto.TimeZone))
            throw new BadRequestException("Timezone Inválida. Use formato XXX/xxx");

        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            throw new ConflictException("Email já cadastrado.");

        var user = new User
        {
            Email = dto.Email,
            Name = dto.Name,
            Password = PasswordHasher.Hash(dto.Password),
            TimeZone = dto.TimeZone,
            CreatedAt = DateTime.UtcNow,
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        
        try
        {
            return _tokenServices.GenerateToken(user);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<string> Login([FromBody] LoginRequestDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email) 
            ?? throw new NotFoundException("Usuário não encontrado.");

        if (PasswordHasher.Verify(dto.Password, user.Password))
        {
            try
            {
                return _tokenServices.GenerateToken(user);
            }
            catch (Exception)
            {
                throw;
            }
        }
        else
        {
            throw new UnauthorizedException("Senha incorreta.");
        }
    }

    public static bool IsValidTimeZoneId(string timeZoneId)
    {
        try
        {
            TZConvert.GetTimeZoneInfo(timeZoneId);
            return true;
        }
        catch
        {
            return false;
        }
    }

}
