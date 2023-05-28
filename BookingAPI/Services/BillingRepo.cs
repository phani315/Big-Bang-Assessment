using BookingAPI.Models;
using System.Diagnostics;
using BookingAPI.Interfaces;

namespace BookingAPI.Services
{
    public class BillingRepo : IRepo<int, Billing>
    {

        private BookingContext _context;

        public BillingRepo(BookingContext context)
        {
            _context = context;
        }


        public Billing Add(Billing item)
        {
            try
            {
                _context.Billings.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(item);
            }
            return null;
        }


        public ICollection<Billing> GetAll()
        {
            try
            {
                var billings = _context.Billings.ToList();
                if (billings.Count > 0)
                {
                    return billings;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }
        public Billing Get(int Id)

        {
            Billing Billing = new Billing();
            try
            {
                Billing = _context.Billings.SingleOrDefault(p => p.BillingId == Id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return Billing;

        }

        public Billing Delete(int Id)
        {
            Billing item = Get(Id);
            try
            {
                _context.Billings.Remove(item);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return item;
        }

        public Billing Update(Billing item)
        {
            Billing billing = _context.Billings.SingleOrDefault(p => p.BillingId == item.BillingId);
            if (billing != null)
            {
                billing.BillingId = item.BillingId;
                billing.CustomerId = item.CustomerId;
               billing.TotalPrice=item.TotalPrice; 
                billing.BookingId = item.BookingId;
                billing.PaymentStatus = item.PaymentStatus;


                _context.SaveChanges();
            }
            return billing;
        }


    }

}
