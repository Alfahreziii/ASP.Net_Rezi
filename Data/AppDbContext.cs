// File: AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using MahasiswaApi.Models;
using FakultasApi.Models;

namespace MahasiswaApi.Data // INI PENTING! Pastikan namespace ini sesuai
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Mahasiswa> Mahasiswas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Fakultas> Fakultas { get; set; }
    }
}
