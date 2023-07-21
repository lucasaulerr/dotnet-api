using FilmsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPI.Data;

public class FilmeContext : DbContext
{
	public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
	{

	}
	public DbSet<Filme> Filmes { get; set; }
	public DbSet<Cinema> Cinemas { get; set; }
	public DbSet<Endereco> Enderecos { get; set; }
	public DbSet<Sessao> Sessao { get; set; }
}
