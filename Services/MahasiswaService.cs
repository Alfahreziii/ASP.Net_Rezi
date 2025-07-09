using MahasiswaApi.Models;
using MahasiswaApi.DTOs;
using MahasiswaApi.Data;
using System.Collections.Generic;
using System.Linq;

namespace MahasiswaApi.Services
{
    public class MahasiswaService
    {
        private readonly AppDbContext _context;

        public MahasiswaService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Mahasiswa> GetAll()
        {
            return _context.Mahasiswas.ToList();
        }

        public Mahasiswa? GetById(int id)
        {
            return _context.Mahasiswas.Find(id);
        }

        public Mahasiswa Create(CreateMahasiswaDto dto)
        {
            var mahasiswa = new Mahasiswa
            {
                Nama = dto.Nama,
                NIM = dto.NIM
            };
            _context.Mahasiswas.Add(mahasiswa);
            _context.SaveChanges();
            return mahasiswa;
        }

        public bool Delete(int id)
        {
            var mahasiswa = _context.Mahasiswas.Find(id);
            if (mahasiswa == null) return false;
            _context.Mahasiswas.Remove(mahasiswa);
            _context.SaveChanges();
            return true;
        }

        public Mahasiswa? Update(int id, UpdateMahasiswaDto dto)
        {
            var mahasiswa = _context.Mahasiswas.Find(id);
            if (mahasiswa == null) return null;

            mahasiswa.Nama = dto.Nama;
            mahasiswa.NIM = dto.NIM;
            _context.SaveChanges();
            return mahasiswa;
        }
    }
}