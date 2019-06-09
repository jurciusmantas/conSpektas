using conSpektas.Data;
using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;
using Microsoft.EntityFrameworkCore;
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
            var list = _context.Conspects
                .AsQueryable();

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
                .Select(x => new Conspect
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    ParentId = x.ParentId,
                    Inserted = x.Inserted,
                    Rating = x.Rating,
                    User = new User
                    {
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                        UserName = x.User.UserName,
                    },
                    Comments = x.Comments.Select(c => new Comment
                    {
                        Content = c.Content,
                        Rating = c.Rating,
                        User = new User
                        {
                            FirstName = c.User.FirstName,
                            LastName = c.User.LastName,
                            UserName = c.User.LastName,
                        }
                    }).ToList(),
                })
                .ToList();
        }

        public void DeleteConspect(Conspect conspect)
        {
            _context.Remove(conspect);
            _context.SaveChanges();
        }

        public void UpdateConspect(Conspect conspect)
        {
            _context.Update(conspect);
            _context.SaveChanges();
        }

        public Conspect GetByIdFull(int id)
        {
            return _context.Conspects
                .Where(c => c.Id == id)
                .Include("Categories")
                .Include("Ratings")
                .Include("Comments")
                .SingleOrDefault();
        }
    }
}
