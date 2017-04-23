using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventarios
{
    class Producto
    {
        private int _codigo { get; }
        public int codigo { get { return _codigo; } }
        private string _nombre { get; }
        public string nombre { get { return _nombre; } }
        private int _cantidad { get; }
        public int cantidad { get { return _cantidad; } }
        private float _costo { get; }
        public float costo { get { return _costo; } }
        //variable para guardar los datos del producto.
        private Producto _datos { get; }
        public Producto datos { get { return _datos; } }
        //Variable tipo dato para apuntar a los datos del siguente producto
        public Producto siguienteDato;
        
        public Producto (int codigo, string nombre, int cantidad, float costo)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._cantidad = cantidad;
            this._costo = costo;
        }
        /// <summary>
        ///  Constructor, para agregar los datos del ultimo producto, y apuntador a null
        /// </summary>
        /// <param name="dato"></param>
        public Producto (Producto dato)
        {
            this._datos = dato;
            siguienteDato = null; //Apunta a null, porque sera el ultimo en agregarse, y nadie sigue de el
        }

        public override string ToString()
        {
            string objetoProducto;

            objetoProducto = "Codigo: " + codigo + Environment.NewLine+ "Nombre: " + nombre + Environment.NewLine + "Cantidad: " + 
                cantidad + Environment.NewLine + "Costo: " + costo + Environment.NewLine + "//////////" + Environment.NewLine;
            return objetoProducto;
        }
    }
}
