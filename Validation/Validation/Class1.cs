using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Core.Interface.Validation;
using Core.DomainModel;
using Core.Interface.Service;

namespace Validation.Validation
{
    public class ContactValidator : IContactValidator
    {

        public Contact VName(Contact c)
        {
            if (String.IsNullOrEmpty(c.Name) || c.Name.Trim() == "")
            {
                c.Errors.Add("Name", "Tidak boleh kosong");
            }
            return c;
        }

        public Contact VAddress(Contact c)
        {
            if (String.IsNullOrEmpty(c.Address) || c.Address.Trim() == "")
            {
                c.Errors.Add("Address", "Tidak boleh kosong");
            }
            return c;
        }

        public Contact VHasPurchaseOrder(Contact c, IPurchaseOrderService _pos)
        {
            IList<PurchaseOrder> polist = _pos.GetObjectsByContactId(c.Id);
            if (polist.Any())
            {
                c.Errors.Add("PurchaseOrders", "Tidak boleh ada yang terasosiakan dengan kontak");
            }
            return c;
        }

        public Contact VHasPurchaseReceival(Contact c, IPurchaseReceivalService _prs)
        {
            IList<PurchaseReceival> prlist = _prs.GetObjectsByContactId(c.Id);
            if (prlist.Any())
            {
                c.Errors.Add("PurchaseRecievals", "Tidak boleh ada yang terasosiakan dengan kontak");
            }
            return c;
        }

        public Contact VHasSalesOrder(Contact c, ISalesOrderService _sos)
        {
            IList<SalesOrder> solist = _sos.GetObjectsByContactId(c.Id);
            if (solist.Any())
            {
                c.Errors.Add("SalesOrders", "Tidak boleh ada yang terasosiakan dengan kontak");
            }
            return c;
        }

        public Contact VHasDeliveryOrder(Contact c, IDeliveryOrderService _dos)
        {
            IList<DeliveryOrder> dolist = _dos.GetObjectsByContactId(c.Id);
            if (dolist.Any())
            {
                c.Errors.Add("DeliveryOrder", "Tidak boleh ada yang terasosiakan dengan kontak");
            }
            return c;
        }

        public Contact VCreateObject(Contact c)
        {
            VName(c);
            VAddress(c);
            return c;
        }

        public Contact VUpdateObject(Contact c)
        {
            VName(c);
            VAddress(c);
            return c;
        }

        public Contact VDeleteObject(Contact c, IPurchaseOrderService _pos, IPurchaseReceivalService _prs,
                                ISalesOrderService _sos, IDeliveryOrderService _dos)
        {
            VHasPurchaseOrder(c, _pos);
            VHasPurchaseReceival(c, _prs);
            VHasSalesOrder(c, _sos);
            VHasDeliveryOrder(c, _dos);
            return c;
        }

        public bool ValidCreateObject(Contact c)
        {
            VCreateObject(c);
            return isValid(c);
        }

        public bool ValidUpdateObject(Contact c)
        {
            c.Errors.Clear();
            VUpdateObject(c);
            return isValid(c);
        }

        public bool ValidDeleteObject(Contact c, IPurchaseOrderService _pos, IPurchaseReceivalService _prs,
                        ISalesOrderService _sos, IDeliveryOrderService _dos)
        {
            c.Errors.Clear();
            VDeleteObject(c, _pos, _prs, _sos, _dos);
            return isValid(c);
        }

        public bool isValid(Contact obj)
        {
            bool isValid = !obj.Errors.Any();
            return isValid;
        }

        public string PrintError(Contact obj)
        {
            string erroroutput = "";
            KeyValuePair<string, string> first = obj.Errors.ElementAt(0);
            erroroutput += first.Key + "," + first.Value;
            foreach (KeyValuePair<string, string> pair in obj.Errors.Skip(1))
            {
                erroroutput += Environment.NewLine;
                erroroutput += pair.Key + "," + pair.Value;
            }
            return erroroutput;
        }

    }
}
