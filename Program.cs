//Biblioteca utilizada: CsvHelper
//https://www.nuget.org/packages/CsvHelper/

using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;

LerCSVComClasse();
//LerCSVComDynamic();

Console.WriteLine("Digite [enter] para finalizar");
Console.ReadLine();

static void LerCSVComClasse()
{
    var path = Path.Combine(Environment.CurrentDirectory,
    "Entrada",
    "novos-usuarios.csv");

    //Nova instância da classe FileInfo
    var fi = new FileInfo(path);

    if(!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe"); //Nova instância da classe
                                        //FileNotFoundException

    //Nova instância da classe StreamReader  
    //using pois StreamReader é disposable           
    using var sr = new StreamReader(fi.FullName); 
                                            
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);

    using var csvReader = new CsvReader(sr,csvConfig);

    //Lê as linhas do arquivo Produtos.csv
    var registros = csvReader.GetRecords<Usuario>();

    foreach(var registro in registros)
    {
        Console.WriteLine($"nome:{registro.Nome}");
        Console.WriteLine($"email:{registro.Email}");
        Console.WriteLine($"telefone:{registro.Telefone}");
        Console.WriteLine("-----------------------");
    }
}

static void LerCSVComDynamic()
{
    var path = Path.Combine(Environment.CurrentDirectory,
    "Entrada",
    "Produtos.csv");

    //Nova instância da classe FileInfo
    var fi = new FileInfo(path);

    if(!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe"); //Nova instância da classe
                                        //FileNotFoundException

    //Nova instância da classe StreamReader  
    //using pois StreamReader é disposable           
    using var sr = new StreamReader(fi.FullName); 
                                            
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);

    using var csvReader = new CsvReader(sr,csvConfig);

    //Lê as linhas do arquivo Produtos.csv
    var registros = csvReader.GetRecords<dynamic>();

    foreach(var registro in registros)
    {
        Console.WriteLine($"nome:{registro.Produto}");
        Console.WriteLine($"marca:{registro.Marca}");
        Console.WriteLine($"preço:{registro.Preco}");
        Console.WriteLine("-----------------------");
    }
}
