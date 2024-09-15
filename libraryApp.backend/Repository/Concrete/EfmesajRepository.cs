using libraryApp.backend.Entity;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Repository.Concrete
{
    public class EfmesajRepository
    {
        public IQueryable<mesaj> mesajlar => _context.mesajlar;
        private libraryDBContext _context;
        public EfmesajRepository()
        {
            _context = context;
        }
        public async Task AddmesajAsync(mesaj mesaj1)
        {
            _context.mesajlar.Add(mesaj1);
            await _context.SaveChangesAsync();
        }

        public async Task DeletemesajAsync(mesaj mesaj1)
        {
            _context.mesajlar.Remove(mesaj1);
            await _context.SaveChangesAsync();
        }

        public async Task<mesaj?> GetmesajByIdAsync(int id)
        {
            return await mesajlar.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdatemesajAsync(mesaj mesaj1)
        {
            _context.mesajlar.Update(mesaj1);
            await _context.SaveChangesAsync();
        }
    }
}
