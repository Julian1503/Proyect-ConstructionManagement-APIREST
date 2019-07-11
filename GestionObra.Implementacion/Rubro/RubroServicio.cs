﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Rubro;
using GestionObra.Interfaces.Rubro.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Rubro
{
    public class RubroServicio :IRubroRepositorio
    {
        private IRepositorio<Dominio.Rubro> _rubroRepositorio;
        private IMapper _mapper;

        public RubroServicio(IRepositorio<Dominio.Rubro> rubroRepositorio)
        {
            _rubroRepositorio = rubroRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(RubroDto dto)
        {
            using (var context = new DataContext())
            {
                var rubro = _mapper.Map<Dominio.Rubro>(dto);
                await _rubroRepositorio.Create(rubro);
            }
        }

        public async Task<IEnumerable<RubroDto>> Obtener(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Rubro, bool>> exp = x => true;
                exp = exp.And(x => x.Descripcion.Contains(cadena));
                var rubro = await _rubroRepositorio.GetByFilter(exp, x=>x.OrderByDescending(y=>y.Descripcion),null, true);
                return _mapper.Map<IEnumerable<RubroDto>>(rubro);
            }
        }

        public async Task<RubroDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var rubro = await _rubroRepositorio.GetById(id, null, true);
                if (rubro == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<RubroDto>(rubro);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var rubro = context.Rubros.FirstOrDefault(x => x.Id == id);
                await _rubroRepositorio.Delete(rubro);
            }
        }

        public async Task Modificar(RubroDto dto)
        {
            using (var context = new DataContext())
            {
                var rubro = context.Rubros.FirstOrDefault(x => x.Id == dto.Id);
                rubro = _mapper.Map<Dominio.Rubro>(dto);
                await _rubroRepositorio.Update(rubro);
            }
        }
    }
}
