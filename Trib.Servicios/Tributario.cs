using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trib.Aplicacion;
using Trib.Datos.Entidad;
using System.ServiceModel.Activation;

namespace Trib.Servicios
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Tributario : ITributario
    {

        public List<deuda> deudaListarPaginadoBuscar(string buscarPor)
        {
            return new BLDeuda().deudaListarPaginadoBuscar(buscarPor);
        }

        #region deuda

            public deuda deudaLeer(int idsolicitud)
            {
                return new BLDeuda().TraerUno(idsolicitud, "iddeuda");
            }

            public List<deuda> deudaListar()
            {
                return new BLDeuda().ListarTodos();
            }

            public void deudaInsertar(deuda entidad)
            {
                new BLDeuda().Agregar(entidad);
            }

            public void deudaModificar(deuda entidad)
            {
                new BLDeuda().Actualizar(entidad);
            }

            public void deudaEliminar(deuda entidad)
            {
                new BLDeuda().Eliminar(entidad);
            }

        #endregion
    }
}
