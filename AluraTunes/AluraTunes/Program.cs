using AluraTunes;

//listar todos os gêneros que tenham a palavra rock
Console.WriteLine("Gêneros com Rock");

var generos = new List<Genero>
{
    new Genero{ Id = 1, Nome = "Rock"},
    new Genero{ Id = 2, Nome = "Reggae"},
    new Genero{ Id = 3, Nome = "Rock Progressivo"},
    new Genero{ Id = 4, Nome = "Punk Rock"},
    new Genero{ Id = 5, Nome = "Clássica"},
};

Console.WriteLine("Consulta usando o método antigo");
foreach (var genero in generos)
{
    if (genero.Nome.Contains("Rock"))
    {
        Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
    }
    
}

//select * from genero
var query = from g in generos
            where g.Nome.Contains("Rock")
            select g;

Console.WriteLine();

Console.WriteLine("Consulta usando LINQ - SQL");
foreach (var genero in query)
{
    Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
}

Console.WriteLine();

//LINQ = Language Integrated Query = Consulta Integrada a Linguagem
//Ele permite você usar o conhecimento de SQL para aplicar consultar parecidas em C#


//Listar músicas
Console.WriteLine("Músicas");

var musicas = new List<Musica>()
{

    new Musica{ Id = 1, Nome = "Sweet Chid O'Mine", GeneroId = 1},
    new Musica{ Id = 2, Nome = "I Shot The Sheriff", GeneroId = 2},
    new Musica{ Id = 3, Nome = "Danúbio Azul", GeneroId = 5},
};

Console.WriteLine("Consulta com LINQ");
var query2 = from m in musicas
             join g in generos on m.GeneroId equals g.Id
             select new { m, g };

foreach (var q in query2)
{
    Console.WriteLine("{0}\t{1}\t{2}", q.m.Id, q.m.Nome, q.g.Nome);
}

Console.WriteLine();
Console.WriteLine("Listar músicas cujo gênero tenha o nome Reggae");

var query3 = from m in musicas
            join g in generos on m.GeneroId equals g.Id
	    where g.Nome == "Reggae"
	    select m.Nome;

foreach (var q in query3)
{
    Console.WriteLine("{0}", q);
}

Console.ReadKey();

