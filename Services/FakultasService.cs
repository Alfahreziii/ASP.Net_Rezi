using FakultasApi.Models;
using MahasiswaApi.Data;
using FakultasApi.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace FakultasApi.Services
{
    public class FakultasService
    {
        private readonly AppDbContext _context;

        public FakultasService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Fakultas> GetAll()
        {
            return _context.Fakultas.ToList();
        }

        public Fakultas? GetById(int id)
        {
            return _context.Fakultas.Find(id);
        }

        public Fakultas Create(CreateFakultasDto dto)
        {
            var Fakultas = new Fakultas
            {
                NamaFakultas = dto.NamaFakultas,
                Description = dto.Description
            };
            _context.Fakultas.Add(Fakultas);
            _context.SaveChanges();
            return Fakultas;
        }

        public bool Delete(int id)
        {
            var Fakultas = _context.Fakultas.Find(id);
            if (Fakultas == null) return false;
            _context.Fakultas.Remove(Fakultas);
            _context.SaveChanges();
            return true;
        }

        public Fakultas? Update(int id, UpdateFakultasDto dto)
        {
            var Fakultas = _context.Fakultas.Find(id);
            if (Fakultas == null) return null;

            Fakultas.NamaFakultas = dto.NamaFakultas;
            Fakultas.Description = dto.Description;
            _context.SaveChanges();
            return Fakultas;
        }
    }
}