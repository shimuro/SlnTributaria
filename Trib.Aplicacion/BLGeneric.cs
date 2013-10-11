using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Trib.Datos.Entidad;
using System.Data.Objects;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using Trib.Datos;
using System.Data;
using System.Data.Metadata.Edm;
using System.Reflection;

namespace Trib.Aplicacion
{
    public class BLGeneric<E>
        where E : class
    {
        public bd_tributarioEntities contexto;

        public BLGeneric()
        {
            contexto = new bd_tributarioEntities();
        }

        #region mi Members

        public void Agregar(E entity)
        {
            contexto.AddObject(this.ObtenerNombreEntidad(typeof(E).Name), entity);
            contexto.SaveChanges();
        }

        public void Actualizar(E entity)
        {
            contexto.AttachTo(this.ObtenerNombreEntidad(typeof(E).Name), entity);
            contexto.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            contexto.SaveChanges();
        }

        public void Eliminar(E entity)
        {
            contexto.AttachTo(this.ObtenerNombreEntidad(typeof(E).Name), entity);
            //contexto.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
            contexto.DeleteObject(entity);
            contexto.SaveChanges();
        }

        public void AgregarAttach(E entity)
        {
            contexto.AddObject(this.ObtenerNombreEntidad(typeof(E).Name), entity);
            contexto.ObjectStateManager.ChangeObjectState(entity, EntityState.Added);
            contexto.SaveChanges();
            //contexto.AddObject(this.ObtenerNombreEntidad(typeof(E).Name), entity);            
        }

        public int Guardar()
        {
            return contexto.SaveChanges();
        }

        public E TraerUno(object id, string nameKey)
        {
            Assembly a = typeof(E).Assembly;
            contexto.MetadataWorkspace.LoadFromAssembly(a);

            object obj = null;
            EntityKey key = new EntityKey(contexto.DefaultContainerName + "." + this.ObtenerNombreEntidad(typeof(E).Name), nameKey, id);



            contexto.TryGetObjectByKey(key, out obj);
            E entidad = (E)obj;

            return entidad;
        }

        public List<E> ListarTodos()
        {
            return contexto.CreateQuery<E>("[" + this.ObtenerNombreEntidad(typeof(E).Name) + "]").ToList<E>();
        }

        public List<E> ListarPaginado(int indice, int size, string campo)
        {
            return (contexto.CreateQuery<E>
        ("[" + this.ObtenerNombreEntidad(typeof(E).Name) + "]").OrderBy("it." + campo).Skip<E>((indice - 1) * size).Take(size)).ToList();
        }

        public int GetCount()
        {
            return contexto.CreateQuery<E>("[" + this.ObtenerNombreEntidad(typeof(E).Name) + "]").Count();
        }

        private string ObtenerNombreEntidad(string entityTypeName)
        {
            var container = this.contexto.MetadataWorkspace.GetEntityContainer
                    (this.contexto.DefaultContainerName, DataSpace.CSpace);

            var entidad = (from meta in container.BaseEntitySets

                           where meta.ElementType.Name == entityTypeName

                           select meta.Name).FirstOrDefault();
            return entidad;
        }

        public int EjecutarStoreProcedure(string nameStoredProc, ref object[] parametros)
        {
            /*
            var paramId = new SqlParameter
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "categoriaid",
                Direction=System.Data.ParameterDirection.Output
            };

            var paramNombre = new SqlParameter
            {
                DbType = System.Data.DbType.String,
                ParameterName = "nombre",                
            };

            var paramDescripcion = new SqlParameter
            {
                DbType = System.Data.DbType.String,
                ParameterName = "descripcion",                
            };
            // cuando no es una consulta el sp 
            // se ejecuta con el comando ExecuteSqlCommand
            var filas = db.Database.ExecuteSqlCommand("usp_CategoriaInsertar @categoriaid out,@nombre,@descripcion", paramId,paramNombre,paramDescripcion);

            //una vez ejecutado el store se pueden recuperar los valores de los parametros de salida
            var id = (int)paramId.Value;*/
            return contexto.ExecuteStoreCommand(nameStoredProc, parametros);
            //return db.Database.ExecuteSqlCommand(nombreStoredProc, parametros);
        }


        #endregion
    }
}
