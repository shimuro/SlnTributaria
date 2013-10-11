using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trib.Datos.Entidad;
using System.Data.Objects;
using System.Data.Entity;
using System.Transactions;

namespace Trib.Aplicacion
{
    public class BLDeuda : BLGeneric<deuda>
    {
        private bd_tributarioEntities entity;

        private IQueryable<deuda> ListaBase()
        {
            entity = new bd_tributarioEntities();
            entity.deuda.MergeOption = MergeOption.NoTracking;
            IQueryable<deuda> query = this.entity.deuda;
            return query;
        }

        public List<deuda> deudaListarPaginadoBuscar(string buscarPor)
        {
            IQueryable<deuda> query = ListaBase();
            List<deuda> lstdeuda = new List<deuda>();

            query = query.Include("contribuyente");
            query = query.Include("documento");
            query = query.Include("tipopersona");

            if (string.IsNullOrEmpty(buscarPor) == false)
                query = query.Where(x => x.contribuyente.ruc.Contains(buscarPor.ToUpper()));


            lstdeuda = query.OrderBy(x => x.iddeuda).ToList();
            this.entity.Connection.Close();
            return lstdeuda;
        }
    }
}
