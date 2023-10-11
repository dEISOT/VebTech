using Microsoft.EntityFrameworkCore;
using VebTech.Data.Contexts;
using VebTech.Data.Entities;
using VebTech.Data.Repositories.Interfaces;

namespace VebTech.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> AddUserAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            return await _db.Users.AnyAsync(u => u.Email == email);
        }
        public async Task<User> GetUserByIdAsync(Guid Id)
        {
            try
            {
                return await _db.Users.FirstOrDefaultAsync(u => u.Id == Id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Record does not exist in the database");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            try
            {
                return await _db.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Record does not exist in the database");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task DeleteUserAsync(Guid Id)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == Id);
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Record does not exist in the database");
            }
            catch (Exception ex)
            {
                throw;
            }
        } 
        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {   
                var existingUser = _db.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

                if (existingUser == null) { return false; }
                
                _db.Entry(existingUser).CurrentValues.SetValues(user);

                _db.SaveChanges();
                
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
