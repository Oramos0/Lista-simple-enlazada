using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventarios
{
    class Inventario
    {
        //cabecera de la lista, = null en contructor porque no apunta a nada al iniciar
        private Producto cabecera;
        //registro final de la lista, == null en contructor porque no hay registro final al iniciar
        private Producto final;
        int cont = 0, productos = 0;
        /// <summary>
        /// Constructor, cabecera == null, porque no hay nada al iniciar.
        /// </summary>
        public Inventario()
        {
            this.cabecera = null;
            this.final = null;
        }

        //private Producto[] productos = new Producto[20];
        //private int referencia = 0;

        /// <summary>
        /// Agregar Producto al principio de la lista
        /// </summary>
        /// <param name="producto"></param>
        public void agregarPrimero(Producto producto)
        {
            Producto nuevoDato;
            nuevoDato = new Producto(producto);
            if (cabecera == null)
                final = nuevoDato;
            nuevoDato.siguienteDato = cabecera; //el siguente dato del nuevo dato apunta hacia la cabecera original
            cabecera = nuevoDato; // la cabecera apunta al nuevo nodo creado
            productos++;
        }

        /// <summary>
        /// Agregar producto al final de la lista
        /// </summary>
        /// <param name="producto"></param>
        public void agregar(Producto producto)
        {
            Producto nuevoDato;
            nuevoDato = new Producto(producto);
            if (cabecera == null) // si no hay datos en la lista, se agrega en la primera posicion.
                cabecera = nuevoDato;
            else
            {
                Producto datoActual = cabecera;
                while (datoActual.siguienteDato != null)
                    datoActual = datoActual.siguienteDato; //el dato actual salta al siguente en la lista (al que apunta)
                datoActual.siguienteDato = nuevoDato;//el ultimo dato que ya existia apunta al nuevo dato que se introdujo
                final = nuevoDato;//control, para saber cual es el dato final
            }
            productos++;
        }
        /// <summary>
        /// Inserta un producto en la posicion deseada del inventario
        /// </summary>
        /// <param name="lugar"></param>
        /// <param name="producto"></param>
        public void insertar(int lugar, Producto producto)
        {
            cont = 0;
            Producto nuevoDato;
            nuevoDato = new Producto(producto);
            Producto anterior = null, siguiente = null;
            if (cabecera == null)
                cabecera = nuevoDato; // si no hay nada, se agrega a la posicion primera.
            else
            {
                if (lugar == 1)// si la posicion a instertar, es la primera, solo se manda a agrgar al primero
                {
                    agregarPrimero(producto);
                }
                else if (lugar > productos)// si la posicion a insertar, es la ultima o mayor a la ultima, se agrega al final de la lista
                {
                    agregar(producto);
                }else//si es cualquier posicion entre la primera y la ultima.....
                { 
                    Producto datoActual = cabecera;
                    while (cont != lugar - 1)
                    {
                        anterior = datoActual; //anterior toma valor del dato actual antes de que pase al siguente
                        siguiente = datoActual.siguienteDato; //siguente toma valor del dato siguente del dato actual(control)
                        datoActual = datoActual.siguienteDato;// pasamos al siguente dato apuntado
                        cont++;
                    }
                    anterior.siguienteDato = nuevoDato;//el dato anterior, apunta al nuevo dato insertado
                    nuevoDato.siguienteDato = siguiente;//el nuevo dato insertado apunta al dato siguenta, apuntado antes por el dato anterior

                    Producto datoActual2 = cabecera; // control, para saber cual quedo como ultimo dato
                    while (datoActual2.siguienteDato != null)
                        datoActual2 = datoActual2.siguienteDato;
                    final = datoActual2;

                }
            }
            productos++;
        }
        /// <summary>
        /// Regresa todos los productos registrados en el inventario
        /// </summary>
        /// <returns></returns>
        public string reporte()
        {
            string infoLista = "";

            Producto datoActual = cabecera;
            while (datoActual != null) //recorre la lista
            {
                infoLista += datoActual.datos+Environment.NewLine; //agrega la info de cada dato a un report
                datoActual = datoActual.siguienteDato;
            }

            return infoLista;
        }

        /// <summary>
        /// Busca un producto existente del inventario
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Producto buscar(string nombre)
        {
            Producto datoActual = cabecera;
            
            while (datoActual != null)//recorre la lista
            {
                if (datoActual.datos.nombre == nombre)//si el tipo nombre del dato es igual al nombre que se busca, se regresa el dato encotrado.
                {
                    return datoActual.datos;
                }
                else
                    datoActual = datoActual.siguienteDato;//si no es igual, pasamos al siguente dato.
            }
            return null;
        }

        /// <summary>
        /// Elimina producto existente del inventario
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public void eliminar(string nombre)
        {
            Producto datoActual = cabecera;
            Producto anterior = null;

            while (datoActual != null)//recorremos lista
            {
                if (datoActual.datos.nombre == nombre)//si el tipo nombre del dato es igual al nombre que se busca, se toma el dato encotrado
                {
                    if (datoActual == cabecera)// en caso de que el dato a eliminar sea el primero
                    {
                        cabecera = cabecera.siguienteDato;//solo se pone el dato siguente del primero, como primero
                    }
                    else if (datoActual == final)// en caso de eliminar el del final
                    {
                        anterior.siguienteDato = null; // simplemente el anterior de final, lo deja de apuntar
                    }
                    else// en caso de estar entre el primero y el ultimo
                    {
                        anterior.siguienteDato = datoActual.siguienteDato;// el dato siguente del anterior deja de apuntar al actual, y pasa a apuntar
                    }                                                     // al dato siguente del actual
                }
                else 
                    anterior = datoActual; //guarda el dato actual, ates de pasar al siguente
                    datoActual = datoActual.siguienteDato;//el dato actual pasa al siguente dato apuntado
            }
            productos--;
        }



        //    public override string ToString()
        //    {
        //        return Convert.ToString(referencia);
        //    }
    }
}
