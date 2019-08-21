using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CrudProductos.Model
{
    [Table(nameof(Categoria))]
    public class Categoria
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }

    }
}
