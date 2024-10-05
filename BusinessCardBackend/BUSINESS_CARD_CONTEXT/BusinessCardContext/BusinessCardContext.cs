using BUSINESS_CARD_ENTITIES;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_CARD_CONTEXT
{
    public class BusinessCardContext : DbContext
    {
        public BusinessCardContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BusinessCard> BusinessCards { get; set; }
        
    }
}
