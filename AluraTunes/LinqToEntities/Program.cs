using LinqToEntities.Models;
using Microsoft.EntityFrameworkCore;

using (var contexto = new AluraTunesDbContext())
{
    //definicao consulta
    var query = from g in contexto.Generos
                select g;

    //imprimir no console
    foreach (var genero in query)
    {
        Console.WriteLine("{0}\t{1}", genero.GeneroId, genero.Nome);
    }

    Console.WriteLine();

    //Join de genero e musica
    var faixaEGenero = from g in contexto.Generos
                       join f in contexto.Faixas
                        on g.GeneroId equals f.GeneroId
                       select new { f, g };

    faixaEGenero = faixaEGenero.Take(10);

    //Console.WriteLine(faixaEGenero.ToQueryString());

    Console.WriteLine(faixaEGenero.ToList());

    foreach (var item in faixaEGenero)
    {
        Console.WriteLine("{0}\t{1}", item.f.Nome, item.g.Nome);
    }

    Console.WriteLine();

    //filtrar por nome de banda
    var textoBusca = "Led";

    var filtroNomeBanda = from a in contexto.Artista
                          join alb in contexto.Albums
                           on a.ArtistaId equals alb.ArtistaId
                          where a.Nome.Contains(textoBusca)
                          select new
                          {
                              NomeArtista = a.Nome,
                              NomeAlbum = alb.Titulo
                          };
    foreach (var item in filtroNomeBanda)
    {
        Console.WriteLine("{0}\t{1}", item.NomeArtista, item.NomeAlbum);
    }

    Console.WriteLine();

    var filtroNomeBanda2 = contexto.Artista.Where(a => a.Nome.Contains(textoBusca));

    //linq to entities sintaxe de método
    foreach (var nomeBanda in filtroNomeBanda2)
    {
        Console.WriteLine("{0}\t{1}", nomeBanda.ArtistaId, nomeBanda.Nome);
    }

    Console.WriteLine();

    var query2 = from alb in contexto.Albums
                 where alb.Artista.Nome.Contains(textoBusca)
                 select new 
                 {
                     NomeArtista = alb.Artista.Nome,
                     NomeAlbum = alb.Titulo
                 };

    foreach(var item in query2)
    {
        Console.WriteLine("{0}\t{1}", item.NomeArtista, item.NomeAlbum);
    }

    Console.ReadKey();
}