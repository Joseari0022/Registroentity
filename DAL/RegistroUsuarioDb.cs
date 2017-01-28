using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public class RegistroUsuarioDb : DbContext
    {
        public RegistroUsuarioDb() : base("name = ConStr")
        {

        }

        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
