using conSpektas.Data;
using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace conSpecktas.Model.Repositories.Conspects
{
    public class ConspectsRepository : IConspectsRepository
    {
        private readonly ConspectContext _context;

        public ConspectsRepository(ConspectContext context)
        {
            _context = context;
        }

        public Conspect GetById(int id)
        {
            return _context.Conspects.SingleOrDefault(c => c.Id == id);
        }

        public int UploadConspect(Conspect item)
        {
            _context.Conspects.Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        public List<Conspect> GetConspectsList(GetConspectsListPagedArgs args)
        {
            var list = _context.Conspects.AsQueryable();

            if (args.UserId.HasValue)
                list = list.Where(c => c.UserId == args.UserId.Value);

            if (args.CategoryId.HasValue)
            {
                var categoryIdsList = _context.ConspectsCategories
                    .Where(cat => cat.CategoryId == args.CategoryId.Value)
                    .Select(c => c.ConspectId)
                    .ToList();

                list = list.Where(c => categoryIdsList.Contains(c.Id));
            }

            if (!string.IsNullOrEmpty(args.Title?.Trim()))
                list = list.Where(c => c.Title.Contains(args.Title.Trim()));

            return list.Skip((args.PageNumber - 1) * args.PageNumber)
                .Take(args.PageSize)
                .ToList();
        }

        public void DeleteConspect(int conspectId)
        {
            var item = new Conspect { Id = conspectId };
            _context.Conspects.Attach(item);
            _context.Conspects.Remove(item);
            _context.SaveChanges();
        }

        public void UpdateConspect(Conspect conspect)
        {
            _context.Update(conspect);
            _context.SaveChanges();
        }
    }
}
