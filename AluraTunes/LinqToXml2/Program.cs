using System.Xml.Linq;
using System.Linq;

//Para acessar um arquivo xml temos que acessar uma biblioteca própria do NET
XElement root = XElement.Load(@"C:\projetos\AluraTunes\AluraTunes\LinqToXml2\Data\AluraTunes.xml");

//Definir consulta linq que acesse o arquivo

var queryXML = 
    from g in root.Element("Generos").Elements("Genero")
    select g;

foreach(var genero in queryXML)
{
    Console.WriteLine("{0}\t{1}", genero.Element("GeneroId").Value, genero.Element("Nome").Value);
}