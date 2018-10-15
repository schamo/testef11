using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TestEf11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SeedData();

            using (var context = new MyDbContext())
            {
                var canReadCount = context.Parents
                    .Include(p => p.Children)
                    .Count(p => CanRead(p));
                Console.WriteLine("Using CanRead method:" + canReadCount);
            }

            using (var context = new MyDbContext())
            {
                var canReadCount = context.Parents
                    .Include(p => p.Children)
                    .Where(GetCanReadExpression())
                    .Count();
                Console.WriteLine("Using CanRead expression: " + canReadCount);
            }

            using (var context = new MyDbContext())
            {
                var canReadCount = context.Parents
                    .Include(p => p.Children)
                    .Where(p => CanRead(p))
                    .ToList()
                    .Count;
                Console.WriteLine("Using CanRead method with ToList: " + canReadCount);
            }

            Console.ReadKey();
        }

        private static bool CanRead(ParentEntity entity)
        {
            return entity?.Children != null && entity.Children.Any(c => c.CanRead);
        }

        private static Expression<Func<ParentEntity, bool>> GetCanReadExpression()
        {
            return p => p.Children.Any(c => c.CanRead);
        }

        private static void SeedData()
        {
            using (var myContext = new MyDbContext())
            {
                if (!myContext.Parents.Any())
                {
                    var parents = new List<ParentEntity>
                    {
                        new ParentEntity
                        {
                            Name = "Object1",
                            Children = new List<ChildEntity>
                            {
                                new ChildEntity
                                {
                                    CanRead = true
                                },
                                new ChildEntity
                                {
                                    CanRead = false
                                }
                            }
                        },
                        new ParentEntity
                        {
                            Name = "Object2",
                            Children = new List<ChildEntity>
                            {
                                new ChildEntity
                                {
                                    CanRead = false
                                },
                                new ChildEntity
                                {
                                    CanRead = false
                                }
                            }
                        }
                    };
                    myContext.AddRange(parents);
                    myContext.SaveChanges();
                }
            }
        }
    }
}
