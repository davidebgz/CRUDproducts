using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;

namespace CrudProductos.Model
{
    public class Conexion
    {
        public SQLiteConnection DataBase;
        public Conexion()
        {
            string Conec = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "inventario.db3");
            DataBase = new SQLiteConnection(Conec);
            DataBase.CreateTable<Categoria>();
            DataBase.CreateTable<Producto>();

        }
        //Insertar Datos de Categoria Y Producto
        public int InsertarCategoria(Categoria _cate)
        {
            return DataBase.Insert(_cate);
             
            
        }
        public int InsertarProducto(Producto _produ)
        {
             return DataBase.Insert(_produ);
        }
        //Leer  de Categoria 
        public Categoria LeerCategoria(int IdCategoria)
        {
            return DataBase.Table<Categoria>().Where(n => n.IdCategoria == IdCategoria).FirstOrDefault();
        }
        public List<Categoria> LeerCategorias()
        {
            return DataBase.Table<Categoria>().ToList();
        }
        public Producto LeerProducto(int IdProducto)
        {
            return DataBase.Table<Producto>().Where(n => n.IdProducto == IdProducto).FirstOrDefault();
        }
        public List<Producto> LeerProductos()
        {
            return DataBase.Table<Producto>().ToList();
        }
        public List<Producto> LeerProductosPorCategoria(int idCategoria)
        {
            return DataBase.Table<Producto>().Where(n => n.IdCategoria == idCategoria).ToList();
        }
    }
}
            
    

