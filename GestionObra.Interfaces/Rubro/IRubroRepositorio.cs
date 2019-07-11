﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Rubro.DTOs;

namespace GestionObra.Interfaces.Rubro
{
    public interface IRubroRepositorio
    {
        Task Insertar(RubroDto dto);
        Task<IEnumerable<RubroDto>> Obtener(string cadena);
        Task<RubroDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(RubroDto dto);
    }
}
