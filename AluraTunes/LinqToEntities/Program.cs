using LinqToEntities.Models;

using (var contexto = new AluraTunesDbContext())
{
    //definicao consulta
    var query = from g in contexto.Generos
                select g;

    //imprimir no console
    foreach (var genero in query)
    {
        Console.WriteLine("{0}\t{1}",genero.GeneroId, genero.Nome) ;
    }

    Console.ReadKey();
}