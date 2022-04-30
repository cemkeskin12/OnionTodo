using Microsoft.EntityFrameworkCore;
using OT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Application.Interfaces.Context
{
    public interface IAppDbContext
    {
        DbSet<Article> Articles { get; set; }
    }
}
