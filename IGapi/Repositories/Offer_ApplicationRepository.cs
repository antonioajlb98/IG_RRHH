using IGapi.Context;
using IGapi.Models;
using Microsoft.EntityFrameworkCore;

namespace IGapi.Repositories
{
    public class Offer_ApplicationRepository
    {
        private readonly ApplicationDBContext db;

        public Offer_ApplicationRepository(ApplicationDBContext db)
        {
            this.db = db;
        }

        public bool Insert(Offer_ApplicationModel offer_aplicattion)
        {
            if (offer_aplicattion != null) 
            {
                try
                {
                    db.Orders.Add(offer_aplicattion);
                    db.SaveChanges();
                    return true;
                }catch(Exception ex)
                {
                    return false;
                }
            }
            return false;
        }

        public Offer_ApplicationModel Get(int id)
        {
            var aux = new Offer_ApplicationModel();
            if (db.Orders.FirstOrDefault(c => c.Id == id) != null)
            {
                db.Orders.Include(o => o.Candidate).FirstOrDefault(o => o.Id == id);
                db.Orders.Include(o => o.Offer).FirstOrDefault(o => o.Id == id);
                aux = db.Orders.FirstOrDefault(c => c.Id == id);
                
            }
            return aux;

        }
        public List<Offer_ApplicationModel> GetAll()
        {
            return db.Orders.ToList();
        }
    }
}
