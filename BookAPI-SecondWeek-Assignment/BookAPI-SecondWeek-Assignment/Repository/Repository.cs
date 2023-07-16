using BookAPI_SecondWeek_Assignment.Data;
using Microsoft.EntityFrameworkCore;

namespace BookAPI_SecondWeek_Assignment.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext applicationContext;
        private readonly DbSet<T> table;
        public Repository(ApplicationContext _applicationContext) { 
            applicationContext = _applicationContext;
            table = applicationContext.Set<T>();
        }
        public void Create(T entity)
        {
            table.Add(entity);
            applicationContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = table.Find(id);
            table.Remove(entity);
            applicationContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            applicationContext.Entry(entity).State = EntityState.Modified;
            applicationContext.SaveChanges();
        }
    }
}
