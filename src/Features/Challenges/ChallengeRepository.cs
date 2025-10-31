using HabitumAPI.Features.Challenges.Interfaces;
using HabitumAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HabitumAPI.Features.Challenges;

public class ChallengeRepository(HabitumContext context) : IChallengeRepository
{
    private readonly HabitumContext _context = context;
    public async Task CreateAsync(Challenge challenge)
    {
        await _context.Challenges.AddAsync(challenge);

        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Challenge challenge)
    {
        _context.Challenges.Remove(challenge);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Challenge>> GetAllAsync()
    {
        return await _context.Challenges.ToListAsync();
    }
    public async Task<Challenge?> GetByIdAsync(int id)
    {
        return await _context.Challenges.FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task UpdateAsync(Challenge challenge)
    {
        _context.Challenges.Update(challenge);
        await _context.SaveChangesAsync();
    }
}
