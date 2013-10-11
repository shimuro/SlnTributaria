using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trib.Aplicacion;
using System.ServiceModel.Activation;

namespace Trib.Servicios
{
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Generic<T>:IGeneric<T>
        where T: class
    {
        BLGeneric<T> oGeneric = null;

        public Generic()
        {
            oGeneric=new BLGeneric<T>();
        }

        public void Agregar(T entidad)
        {
            oGeneric.Agregar(entidad);
        }

        public void Actualizar(T entidad)
        {
            oGeneric.Actualizar(entidad);
        }

        public void Eliminar(T entidad)
        {
            oGeneric.Eliminar(entidad);
        }

        public int Guardar()
        {
            return oGeneric.Guardar();
        }

        public T TraerUno(object id, string nameKey)
        {
           return oGeneric.TraerUno(id, nameKey);
        }

        public List<T> ListarTodos()
        {
            return oGeneric.ListarTodos();
        }

        public List<T> ListarPaginado(int indice, int size,string campo)
        {
            return oGeneric.ListarPaginado(indice, size,campo).ToList();
        }
    }
}
