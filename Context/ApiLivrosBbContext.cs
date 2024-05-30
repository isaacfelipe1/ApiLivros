using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLivros.Context
{
    public class ApiLivrosBbContext:DbContext
    
    {
            public ApiLivrosBbContext(DbContextOptions<ApiLivrosBbContext> options) : base(options){

            }
            public DbSet<Livros> Livros { get; set; }
            }
    
    }
