﻿using LinqToEntities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

    foreach (var item in query2)
    {
        Console.WriteLine("{0}\t{1}", item.NomeArtista, item.NomeAlbum);
    }

    Console.WriteLine();
    Console.Clear();

    Console.WriteLine("Consulta refinada");

    //consulta faixas de musicas pelo nome do artista e titulo do album
    //se o titulo do album for fornecido vamos trazer a consulta filtrada por nome artista e nome album
    //se o nome do album não for fornecido, a gente pelo nome do artista

    GetFaixas(contexto, "Led", "");

    Console.WriteLine();

    GetFaixas(contexto, "Led", "Graffiti");

    Console.ReadKey();
}

void GetFaixas(AluraTunesDbContext contexto, string textoBusca, string buscaAlbum)
{
    var query3 = from f in contexto.Faixas
                 join alb in contexto.Albums on f.AlbumId equals alb.AlbumId
                 where f.Album.Artista.Nome.Contains(textoBusca)
                 //&& (!string.IsNullOrEmpty(buscaAlbum) ? f.Album.Titulo.Contains(buscaAlbum) : true)
                 orderby f.Album.Titulo, f.Nome descending
                 select new
                 {
                     NomeAlbum = alb.Titulo,
                     NomeFaixa = f.Nome,
                     NomeArtista = alb.Artista.Nome
                 };

    if (!string.IsNullOrEmpty(buscaAlbum))
    {
        query3 = query3.Where(q => q.NomeAlbum.Contains(buscaAlbum));
    }

    //query3 = query3.OrderBy(x => x.NomeAlbum).ThenByDescending(x => x.NomeFaixa);


    foreach (var item in query3)
    {
        Console.WriteLine("{0}\t{1}\t{2}", item.NomeFaixa.PadRight(40), item.NomeAlbum.PadRight(40), item.NomeArtista);
    }

    Console.WriteLine();

    //Fazendo contagem de contas faixas existem para determinado artista:
    var query4 = from f in contexto.Faixas
                 join alb in contexto.Albums on f.AlbumId equals alb.AlbumId
                 where f.Album.Artista.Nome == "Led Zeppelin"
                 select new
                 {
                     NomeFaixa = f.Nome,
                     NomeArtista = alb.Artista.Nome
                 };

    //var quantidade = query4.Count();

    //Console.WriteLine("Led Zeppelin tem {0} músicas no banco de dados", quantidade);

    //foreach (var item in query4)
    //{
    //    Console.WriteLine("{0}\t{1}", item.NomeFaixa.PadRight(30), item.NomeArtista.PadLeft(20));
    //}

    //var quantidade = contexto.Faixas.Include(x => x.Album).Where(x => x.Album.Artista.Nome == "Led Zeppelin")
    //    .Count();

    var quantidade = contexto.Faixas.Count(x => x.Album.Artista.Nome == "Led Zeppelin");

    Console.WriteLine("Led Zeppelin tem {0} músicas no banco de dados", quantidade);

    Console.WriteLine();
    Console.Clear();

    //Calcular o total de vendas de um determinado artista:
    var query5 = from inf in contexto.ItemNotaFiscals
                 join f in contexto.Faixas on inf.FaixaId equals f.FaixaId
                 where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                 select new
                 {
                     totalDoItem = inf.Quantidade * inf.PrecoUnitario
                 };

    //foreach (var item in query5)
    //{
    //    Console.WriteLine("{0}", item.totalDoItem);
    //}

    var totalDoArtista = query5.Sum(x => x.totalDoItem);

    Console.WriteLine("Led Zeppelin tem R${0} de vendas", totalDoArtista.ToString("c"));

    Console.WriteLine();

    //Listar os albuns mais vendidos de um determinado artista
    //var query6 = from inf in contexto.ItemNotaFiscals
    //             .Include(x => x.Faixa.Album)
    //             where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
    //             group inf by inf.Faixa.Album into agrupado
    //             select new
    //             {
    //                 NomeAlbum = agrupado.Key.Titulo,
    //                 TotalPorAlbum = agrupado.Sum(x => x.Quantidade * x.PrecoUnitario)
    //             };

    var query6 = contexto.ItemNotaFiscals
        .Include(x => x.Faixa.Album)
        .Where(x => x.Faixa.Album.Artista.Nome == "Led Zeppelin")
        .ToList();

    var agrupado = query6
        .GroupBy(x => x.Faixa.Album)
        .Select(x => new
        {
            NomeAlbum = x.Key.Titulo,
            TotalPorAlbum = x.Sum(x => x.Quantidade * x.PrecoUnitario)
        })
        .OrderByDescending(x => x.TotalPorAlbum);

    foreach (var item in agrupado)
    {
        Console.WriteLine("{0}\t{1}",
        item.NomeAlbum.PadRight(40), item.TotalPorAlbum.ToString("c"));
    }
    Console.WriteLine();
    //Valor da menor venda, da venda máxima e da venda média

    var maiorVenda = contexto.NotaFiscals.Max(x => x.Total);

    Console.WriteLine("O valor da maior venda é " + maiorVenda.ToString("c"));

    var menorVenda = contexto.NotaFiscals.Min(x => x.Total);

    Console.WriteLine("O valor da menor venda é " + menorVenda.ToString("c"));

    var mediaVendas = contexto.NotaFiscals.Average(x => x.Total);

    Console.WriteLine("O valor médio de venda é " + mediaVendas.ToString("c"));

    Console.WriteLine();

    //Trazendo todos os valores numa consulta só:

    var vendas = contexto.NotaFiscals
        .GroupBy(x => 1)
        .Select(x => new
        {
            VendasMaximas = x.Max(x => x.Total),
            VendasMinimas = x.Min(x => x.Total),
            VendasMedias = x.Average(x => x.Total)
        });

    foreach (var item in vendas)
    {
        Console.WriteLine("O valor da maior venda é " + item.VendasMaximas.ToString("c"));
        Console.WriteLine("O valor da menor venda é " + item.VendasMinimas.ToString("c"));
        Console.WriteLine("O valor médio de venda é " + item.VendasMedias.ToString("c"));
    }

    Console.Clear();
    Console.WriteLine();

    //Calcular a mediana das vendas ou notas fiscais

    var query7 = contexto.NotaFiscals.Select(x => x.Total);
    //decimal mediana = Mediana(query7);

    //Console.WriteLine("Mediana: {0}", mediana);

    Console.WriteLine();

    var vendaMediana = contexto.NotaFiscals.Mediana(x => x.Total);
    Console.WriteLine("Mediana: {0}", vendaMediana);

}

//Metodo extensao = metodo que vai complementar uma biblioteca já existente
public static class LinqExtensions
{
    public static decimal Mediana<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector)
    {
        var contagem = source.Count();

        //Seletor = é o campo que eu quero que seja realizada a função
        //Pega o seletor e compilar porque o seletor ainda não é uma função, mas uma definição de função
        var funcSelector = selector.Compile();

        var queryOrdenada = source.Select(funcSelector).OrderBy(x => x);

        //So da pra usar o skip apos consulta ordenada
        var elementoCentral_1 = queryOrdenada
            .Skip(contagem / 2)
            .First();

        var elementoCentral_2 = queryOrdenada
           .Skip((contagem - 1) / 2)
           .First();

        var mediana = (elementoCentral_1 + elementoCentral_2) / 2;
        return mediana;
    }
}