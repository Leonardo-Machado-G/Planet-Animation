//Declaramos las librerias que vamos a utilizar
using System;
using Xamarin.Forms;
using System.Threading;

//Declaramos el namespace
namespace AnimationPlanet

{
    //Declaramos la clase y heredamos de contentpage
    public partial class MainPage : ContentPage
    {

        //Declaramos un hilo que vamos a utilizar para desplazar las imagenes
        private Thread thread;

        //Indica el estado en el que se encuentra el programa al pulsar en la pantalla
        //0 = Estado en el que los planetas se hacen grandes
        //1 = Estado en el que los planetas estan translucidos
        //2 = Estado en el que los planetas comienzan girar
        //3 = Estado en el que todo vuelve a la normalidad
        private int currentState = 0;

        //Declaros una variable que aumenta conforme transcurre el tiempo
        private double counter = 0f;
        
        //Variable que permite a los planetas girar
        private bool enableRotation = false;

        //Declaramos el constructor
        public MainPage() {
           
            //Inicializamos los elementos del XML
            InitializeComponent();

            //Indicamos que metodo sera el nuevo hilo y lo iniciamos
            this.thread = new Thread(new ThreadStart(ThreadMovement));
            this.thread.Start();
            
            //Declaramos un TabGesture para detectar cuando pulsamos la pantalla
            var objTapGestureRecognizer = new TapGestureRecognizer();

            //Definimos su comportamiento al pulsar la pantalla
            objTapGestureRecognizer.Tapped += ((o2, e2) => {

                //Dependiendo del estado en el que estemos los planetas haran una cosa u otra
                if (this.currentState == 0) {

                    //Establece el estado en 1 para que la proxima vez que se pulse ejecute estas intrucciones
                    this.currentState = 1;

                    //Escalamos los planetas a 2
                    ScalePlanets(2f);

                }
                else if (this.currentState == 1) {

                    this.currentState = 2;

                    //Cambiamos los tamaños de los planetas a normal
                    ScalePlanets(1f);

                    //Hacemos que los planetas sean translucidos
                    OpacityPlanets(0.5f);

                }
                else if (this.currentState == 2) {

                    this.currentState = 3;

                    //Indicamos a los planetas que comiencen a girar
                    this.enableRotation = true;

                    //Devolvemos los planetas a la normalidad
                    OpacityPlanets(1f);

                }
                else if (this.currentState == 3) {

                    //Hacemos que todos los planetas vuelven a sus estados originales
                    this.currentState = 0;
                    ScalePlanets(1f);
                    OpacityPlanets(1f);
                    RecoverRotation(0f);
                    this.enableRotation = false;
                }

            });

            //Añadimos el elemento al contenido de esta pagina
            this.Content.GestureRecognizers.Add(objTapGestureRecognizer);

        }

        //Metodo para restablecer las rotaciones de todos los planetas
        private void RecoverRotation(float value)
        {
            this.mercury_planet.Rotation = value;
            this.venus_planet.Rotation = value;
            this.earth_planet.Rotation = value;
            this.mars_planet.Rotation = value;
            this.jupiter_planet.Rotation = value;
            this.saturn_planet.Rotation = value;
            this.neptune_planet.Rotation = value;
            this.uranus_planet.Rotation = value;
        }

        //Metodo para hacer rotar los planetas
        private void RotatePlanets(float value)
        {
            this.mercury_planet.Rotation += value;
            this.venus_planet.Rotation += value;
            this.earth_planet.Rotation += value;
            this.mars_planet.Rotation += value;
            this.jupiter_planet.Rotation += value;
            this.saturn_planet.Rotation += value;
            this.neptune_planet.Rotation += value;
            this.uranus_planet.Rotation += value;
        }

        //Metodo para cambiar el tamaño de los planetas
        private void ScalePlanets(float value)
        {
            this.earth_planet.Scale = value;
            this.jupiter_planet.Scale = value;
            this.mars_planet.Scale = value;
            this.mercury_planet.Scale = value;
            this.saturn_planet.Scale = value;
            this.venus_planet.Scale = value;
            this.neptune_planet.Scale = value;
            this.uranus_planet.Scale = value;
        }

        //Metodo para cambiar la opacidad de los planetas
        private void OpacityPlanets(float value)
        {
            this.earth_planet.Opacity = value;
            this.jupiter_planet.Opacity = value;
            this.mars_planet.Opacity = value;
            this.mercury_planet.Opacity = value;
            this.saturn_planet.Opacity = value;
            this.venus_planet.Opacity = value;
            this.neptune_planet.Opacity = value;
            this.uranus_planet.Opacity = value;
        }

        //Metodo que sera el hilo que iniciemos que se encarga de acceder a las propiedades de los planetas
        private void ThreadMovement() {

            //Hacemos que este hilo nunca se detenga a no ser que se pare la aplicacion
            while (true)
            {

                //Definimos la velocidad en la que se actualizan las imagenes
                Thread.Sleep(40);

                //Establecemos las orbitas de los planetas metiante funciones SEN y COS 
                this.mercury_planet.TranslationX += Math.Sin(counter) * 1.055;
                this.mercury_planet.TranslationY += Math.Cos(counter) * 1.055;
                this.venus_planet.TranslationX += Math.Sin(1.1 + counter) * 1.45;
                this.venus_planet.TranslationY += Math.Cos(1.1 + counter) * 1.45;
                this.earth_planet.TranslationX += Math.Sin(1.58 + counter) * 1.775;
                this.earth_planet.TranslationY += Math.Cos(1.58 + counter) * 1.775;
                this.mars_planet.TranslationX += Math.Sin(3.15 + counter) * 2.15;
                this.mars_planet.TranslationY += Math.Cos(3.15 + counter) * 2.15;
                this.jupiter_planet.TranslationX += Math.Sin(4.85 + counter) * 2.48;
                this.jupiter_planet.TranslationY += Math.Cos(4.85 + counter) * 2.48;
                this.saturn_planet.TranslationX += Math.Sin(counter) * 2.85;
                this.saturn_planet.TranslationY += Math.Cos(counter) * 2.85;
                this.neptune_planet.TranslationX += Math.Sin(5.80 + counter) * 3.2;
                this.neptune_planet.TranslationY += Math.Cos(5.80 + counter) * 3.2;
                this.uranus_planet.TranslationX += Math.Sin(1.5 + counter) * 3.6;
                this.uranus_planet.TranslationY += Math.Cos(1.5 + counter) * 3.6;
                this.sun.Rotation -= 0.5;

               //Cuando este permitido que los planetas roten, se rotaran
                if (this.enableRotation)
                {
                   
                    //Hacemos rotar los planetas
                    RotatePlanets(-3f);

                }

                //Hacemos rotar las flechas de loading
                this.loading.Rotation += 4f;

                //Incrementamos el valor de counter para ir variando la posicion de los elementos por pantalla
                this.counter += 0.015;

            }

        }

        //Metodo que se ejecuta al detectar un cambio en la orientacion del dispositivo
        protected override void OnSizeAllocated(double width, double height) {
            base.OnSizeAllocated(width, height);

            //Si la altura de la pantalla es mayor que la anchura cambiamos el fondo de pantalla
            if(width < height) {

                this.BackgroundImageSource = "space_background";

            }
            else {

                this.BackgroundImageSource = "space_background_land";

            }

        }

    }

}
