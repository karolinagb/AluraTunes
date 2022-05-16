using AluraTunes;

//listar todos os gêneros que tenham a palavra rock
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

Console.ReadKey();

