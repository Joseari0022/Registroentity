using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;

namespace BLL
{
    public class UsuarioBll
    {
        Usuarios usuario = new Usuarios();
        public static bool Guardar(Usuarios u)
        {
            try
            {
                RegistroUsuarioDb db = new RegistroUsuarioDb();
                {
                    db.Usuarios.Add(u);
                    db.SaveChanges();
                    db.Dispose();
                    return false;
                }
            }
            catch (Exception)
            {
                return true;
                throw;
            }
        }

        public static bool Eliminar(Usuarios u)
        {
            try
            {
                RegistroUsuarioDb db = new RegistroUsuarioDb();
                Usuarios us = db.Usuarios.Find(u);
                {
                    db.Usuarios.Remove(us);
                    db.SaveChanges();
                    return false;
                }
            }
            catch (Exception)
            {
                return true;
                throw;
            }
        }

        public static bool Eliminar(int v)
        {
            RegistroUsuarioDb db = new RegistroUsuarioDb();
            Usuarios us = db.Usuarios.Find(v);
            try
            {
                db.Usuarios.Remove(us);
                db.SaveChanges();
                return false;
            }
            catch (Exception e)
            {
                return true;
                throw e;
            }
        }

        public static Usuarios Buscar(int Id)
        {
            try
            {
                RegistroUsuarioDb db = new RegistroUsuarioDb();
                {
                    return db.Usuarios.Find(Id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Usuarios> GetLista()
        {
            List<Usuarios> lista = new List<Usuarios>();
            RegistroUsuarioDb db = new RegistroUsuarioDb();
            lista = db.Usuarios.ToList();
            return lista;
        }

        public static List<Usuarios> GetListaId(int usuarioId)
        {
            List<Usuarios> lista = new List<Usuarios>();
            RegistroUsuarioDb db = new RegistroUsuarioDb();
            lista = db.Usuarios.Where(p => p.Id == usuarioId).ToList();
            return lista;
        }

        public static List<Usuarios> GetListaNombreUsuario(string aux)
        {
            List<Usuarios> lista = new List<Usuarios>();
            RegistroUsuarioDb db = new RegistroUsuarioDb();
            lista = db.Usuarios.Where(p => p.Nombres == aux).ToList();
            return lista;
        }

        public static List<Usuarios> GetContrasena(string aux)
        {
            List<Usuarios> lista = new List<Usuarios>();
            RegistroUsuarioDb db = new RegistroUsuarioDb();
            lista = db.Usuarios.Where(p => p.Contrasena == aux).ToList();
            return lista;
        }
    }
}
