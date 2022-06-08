using Microsoft.EntityFrameworkCore;
using NTTDATA.Application;
using NTTDATA.Application.Interfaces.Repositories;
using NTTDATA.Core.Entities;
using NTTDATA.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Infrastructure.Data.Repositories
{
    public class PersonRepository : IPersonsRepository
    {
        private readonly ContextNTTDATA _context;

        public PersonRepository(ContextNTTDATA context)
        {
            _context = context;

        }

        public async Task<ResponseBase> CreatePerson(Cliente cliente)
        {
            if (_context.Clientes.Where(x => x.Identificacion == cliente.Identificacion).Count() > 0)
            {
                return new ResponseBase()
                {
                    cliente = null,
                    code = "0018"
                };
            }
            else
            {
                _context.ChangeTracker.Clear();
               _context.Add(cliente);
                var dat = await _context.SaveChangesAsync();
                if (dat > 0)
                {
                    var request = _context.Clientes.OrderByDescending(u => u.Id).FirstOrDefault();
                    return new ResponseBase()
                    {
                        cliente = _context.Clientes.OrderByDescending(u => u.Id).FirstOrDefault(),
                        code = "0010"
                    };
                }
                return new ResponseBase()
                {
                    cliente = null,
                    code = "0011"
                };
            }

        }

        public async Task<bool> DeletePerson(long id)
        {
            var id_ = Convert.ToDecimal(id);
            if (_context.Clientes.Where(x => x.Id == id && x.Estado == true).Count() > 0)
            {
                var person = await _context.Clientes.Where(x => x.Id == id).ToListAsync();

                // actualizar registro
                Cliente obPersonsa = null;
                person.ForEach(x =>
                {
                    obPersonsa = new Cliente()
                    {
                        Id = x.Id,
                        Estado = false,
                        Direccion = x.Direccion,
                        Contrasena = x.Contrasena,
                        Genero = x.Genero,
                        FechaNacimiento = x.FechaNacimiento,
                        Identificacion = x.Identificacion,
                        Nombres = x.Nombres,
                        Telefono = x.Telefono,
                    };
                });
                _context.ChangeTracker.Clear();
                _context.Update(obPersonsa);
                var response = await _context.SaveChangesAsync();
                if (response > 0)
                    return true;
                else
                    return false;

            }
            return false;
        }

        public async Task<ResponseBaseList> GetPerson(int? id)
        {
            ResponseBaseList _baseList = new ResponseBaseList();
            if (id == null)
            {
                var data = await (from m in _context.Clientes
                                  where m.Estado == true
                                  select m
                    ).ToListAsync();
                if (data.Count > 0)
                {
                    _baseList.code = "0000";
                    _baseList.cliente = data;
                    return _baseList;
                }
            }
            else
            {
                var data = await (_context.Clientes.Where(s => s.Id == id && s.Estado == true)
                    ).ToListAsync();
                if (data.Count > 0)
                {
                    _baseList.code = "0000";
                    _baseList.cliente = data;
                    return _baseList;
                }
            }

            return _baseList;
        }

        public async Task<ResponseBase> UpdatePerson(Cliente cliente)
        {
            if (_context.Clientes.Where(x => x.Identificacion == cliente.Identificacion).Count() > 0)
            {
                _context.Update(cliente);
                var dat = await _context.SaveChangesAsync();
                if (dat > 0)
                {
                    var request = _context.Clientes.OrderByDescending(u => u.Id).FirstOrDefault();
                    var person = await _context.Clientes.Where(x => x.Id == cliente.Id).ToListAsync();
                    
                    Cliente ob = null;
                    person.ForEach(x =>
                    {
                        ob = new Cliente()
                        {
                            Id = x.Id,
                            Estado = false,
                            Direccion= x.Direccion,
                            FechaNacimiento=x.FechaNacimiento,
                            Genero=x.Genero,
                            Identificacion=x.Identificacion,
                            Nombres=x.Nombres,
                            Telefono=x.Telefono,
                            Contrasena=x.Contrasena,

                        };
                    });
                    return new ResponseBase()
                    {
                        cliente = _context.Clientes.OrderByDescending(u => u.Id).FirstOrDefault(),
                        code = (request != null) ? "0010" : "0011"
                    };
                }
            }
            return new ResponseBase()
            {
                cliente = null,
                code = "0019"
            };
        }
    }
}
