using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CrudProductos.Model
{
    [Table(nameof(Producto))]
    public class Producto
    {

        [PrimaryKey, Unique,AutoIncrement]
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        [Indexed]
        public int IdCategoria { get; set; }
    }
}
