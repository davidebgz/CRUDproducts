using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CrudProductos.Model;
using System.Collections;
using System.Collections.ObjectModel;


namespace CrudProductos.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insertar : ContentPage
    {
        public Insertar()
        {
            InitializeComponent();
        }
        ObservableCollection<Producto> producto_ = new ObservableCollection<Producto>();
        private void Add_Clicked(object sender, EventArgs e)
        {
            Producto Agregar = new Producto();
            Agregar.NombreProducto = EntProducto.Text;
            EntProducto.Text = "";
            producto_.Add(Agregar);
            Productos.ItemsSource = producto_;

        }

        private void BtnVer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Ver());
        }

        private void EntGuardar_Clicked(object sender, EventArgs e)
        {
            Conexion Base = new Conexion();

            Categoria NuevaCategoria = new Categoria();
            NuevaCategoria.NombreCategoria = EntCategory.Text;
            NuevaCategoria.Descripcion = EntDescripcion.Text;

            int IdCategoria = Base.InsertarCategoria(NuevaCategoria);
            if (IdCategoria != -1)
            {
                foreach (Producto productoInsertar in producto_)
                {
                    productoInsertar.IdCategoria = NuevaCategoria.IdCategoria;
                    Base.InsertarProducto(productoInsertar);

                }
                App.Current.MainPage = new NavigationPage(new Ver());
            }
            else
            {
                DisplayAlert("Alerta   U+26D4", "NO ingreso", "ok");
            }
                
        }
    }
}