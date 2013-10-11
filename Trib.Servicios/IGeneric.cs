using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Linq.Expressions;

namespace Trib.Servicios
{
    [ServiceContract]
    public interface IGeneric<T>
    {
        [OperationContract]
        void Agregar(T entidad);

        [OperationContract]
        void Actualizar(T entidad);

        [OperationContract]
        void Eliminar(T entidad);

        [OperationContract]
        int Guardar();

        [OperationContract]
        T TraerUno(object id, string nameKey);

        [OperationContract]
        List<T> ListarTodos();

        [OperationContract]
        List<T> ListarPaginado(int indice, int size, string campo);
    }
}
