using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CrudProductos.Model;
using System.Collections.ObjectModel;

namespace CrudProductos.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ver : ContentPage
    {
        Conexion Base_datos = new Conexion();
        public Ver()
        {
            InitializeComponent();
            List<Categoria> Categorias = new List<Categoria>();
            Categorias = Base_datos.LeerCategorias();
            Categoria__.ItemsSource = Categorias;

            
        }

        private void BtnCategoria_Clicked(object sender, EventArgs e)
        {
            Categoria__.IsVisible = true;
            Productos_ListView.IsVisible = false;
        }

        private void BtnNuevo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
        }

        private void Categoria___ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Categoria CategoriaSelected = new Categoria();
            CategoriaSelected = (Categoria)e.SelectedItem;
            int idcategoria = CategoriaSelected.IdCategoria;
            List<Producto> productoShow = new List<Producto>();
            productoShow = Base_datos.LeerProductosPorCategoria(idcategoria);

            Productos_ListView.ItemsSource = productoShow;
            Categoria__.IsVisible = false;
            Productos_ListView.IsVisible = true;
        }
    }

}