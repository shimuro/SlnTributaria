using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Trib.Datos.Entidad;

namespace Trib.Servicios
{
    [ServiceContract]
    public interface ITributario
    {
        [OperationContract]
        List<deuda> deudaListarPaginadoBuscar(string buscarPor);
    }
}
