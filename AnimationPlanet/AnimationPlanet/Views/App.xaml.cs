//Definimos las librerias que vamos a utilizar
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//Declaramos el namespace
namespace AnimationPlanet
{

    //Declaramos la clase y heredamos de application
    public partial class App : Application
    {
        
        //Definimos su constructor
        public App()
        {

            //Desactivo la barra de navegacion
            NavigationPage.SetHasNavigationBar(this, false);

            //Llama a loadfromxaml de global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml, o sea a su XML
            InitializeComponent();

            //Iniciamos una nueva pagina
            MainPage = new MainPage();

        }

    }

}
