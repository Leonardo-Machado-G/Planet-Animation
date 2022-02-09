//Importamos las librerias que vamos a utilizar
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


//Declaramos el namespace
namespace AnimationPlanet.Helpers
{

    //Indica que propiedad en el documento XML
    [ContentProperty (nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {

        //Declaramos una propiedad string
        public string Source { get; set; }

        //Declaramos un metodo tipo object
        //ServiceProvider proporciona un proveedor de servicios unificado para VSPackages administrados
        public object ProvideValue(IServiceProvider serviceProvider)
        {
    
            //Si Source es null devuelve null
            if(Source == null) { 
                return null;
            }

            //Declaramos un imageSource que devuelve un tipo de informacion que utilizaremos para recursos incrustados
            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            //Devuelvo imagesource
            return imageSource;

        }

    }

}
