using Microsoft.EntityFrameworkCore;
using MahasiswaApi.Models;

namespace MahasiswaApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Mahasiswa> Mahasiswas => Set<Mahasiswa>();
    public DbSet<User> Users => Set<User>();
}
