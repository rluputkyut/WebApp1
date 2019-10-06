using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserService.Models
{
	public class User
	{
        [Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Gender { get; set; }
		public string RegisteredDate { get; set; }
		public string EventDays { get; set; }
		public string AddationalRequest { get; set; }

	}

	public static class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new UserContext(
				serviceProvider.GetRequiredService<
					DbContextOptions<UserContext>>()))
			{
				// Look for any movies.
				if (context.Users.Any())
				{
					return;   // DB has been seeded
				}

				context.Users.AddRange(
					new User
					{
						Name="Child",
						Email = "childchild@mail.com",
						Gender="F",
						RegisteredDate = DateTime.Now.ToString("dd/MM/yyyy"),
						EventDays = "Day 1",
						AddationalRequest = "Test1"
					},
					new User
					{
						Name = "Ko",
						Email = "koko@mail.com",
						Gender = "M",
						RegisteredDate = DateTime.Now.ToString("dd/MM/yyyy"),
						EventDays = "Day 1, Day 2",
						AddationalRequest = "Test2"
					}

				);
				context.SaveChanges();
			}
		}
	}
}
