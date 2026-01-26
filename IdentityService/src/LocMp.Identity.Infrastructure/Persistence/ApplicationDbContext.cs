using Microsoft.EntityFrameworkCore;

namespace LocMp.Identity.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options);