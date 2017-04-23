using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventarios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        Producto objP;
        Inventario inventario = new Inventario();
        /// <summary>
        /// Crea el producto y lo manda a ser guardado al final de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
                int codigo = Convert.ToInt32(txtCodigo.Text);
                string nombre = txtNombre.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                int costo = Convert.ToInt32(txtCosto.Text);
                objP= new Producto(codigo, nombre, cantidad, costo);
                inventario.agregar(objP);


               // lblTotalProductos.Text = inventario.ToString();

        }
        /// <summary>
        /// crea nuevo producto y manda a Agregar producto al principio de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarPrimero_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            string nombre = txtNombre.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            int costo = Convert.ToInt32(txtCosto.Text);
            objP = new Producto(codigo, nombre, cantidad, costo);
            inventario.agregarPrimero(objP);


            //lblTotalProductos.Text = inventario.ToString();
        }

        /// <summary>
        /// Busca un producto del inventario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Producto buscado = inventario.buscar(txtNombre.Text);
            if (buscado == null)
            {

            }
            else
                txtReporte.Text = buscado.ToString();
        }
        /// <summary>
        /// Muestra todos los productos del inventario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReporte_Click(object sender, EventArgs e)
        {

            txtReporte.Text = inventario.reporte();
        }

        /// <summary>
        /// Elimina un producto del inventrio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            inventario.eliminar(txtNombre.Text);             
        }

        /// <summary>
        /// Inserta producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            string nombre = txtNombre.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            int costo = Convert.ToInt32(txtCosto.Text);
            objP = new Producto(codigo, nombre, cantidad, costo);
            inventario.insertar(int.Parse(txtInsertar.Text),objP);

            lblTotalProductos.Text = inventario.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTotalProductos.Text = inventario.ToString();
        }

    }
}
