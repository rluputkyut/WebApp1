using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserService.Models;

namespace WebUserService
{
	public class UserContext : DbContext
	{
		public UserContext(DbContextOptions<UserContext> options)
			: base(options)
		{
		}

		public DbSet<User> Users { get; set; }
	}
}
