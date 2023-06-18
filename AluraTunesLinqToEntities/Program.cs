using AluraTunesLinqToEntities.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using ZXing;

namespace AluraTunes
{
    class Program
    {
        private const string Imagens = "Imagens";

        static void Main(string[] args)
        {
            //using (var contexto = new AluraTunesEntities())
            //{
            #region MAXMINAVG
            // MAX(), MIN(), AVG()

            //contexto.Database.Log = Console.WriteLine;

            //var maiorVenda = contexto.NotasFiscais.Max(nf => nf.Total);
            //var menorVenda = contexto.NotasFiscais.Min(nf => nf.Total);
            //var vendaMedia = contexto.NotasFiscais.Average(nf => nf.Total);

            //Console.WriteLine("A maior venda é de R${0}", maiorVenda);
            //Console.WriteLine("A menor venda é de R${0}", menorVenda);
            //Console.WriteLine("A venda média é de R${0}", vendaMedia);

            //var vendas = (from nf in contexto.NotasFiscais
            //             group nf by 1 into agrupado
            //             select new
            //             { 
            //                maiorVenda = agrupado.Max(nf => nf.Total),
            //                menorVenda = agrupado.Min(nf => nf.Total),
            //                vendaMedia = agrupado.Average(nf => nf.Total)
            //             }).Single();

            //Console.WriteLine("A maior venda é de R${0}", vendas.maiorVenda);
            //Console.WriteLine("A menor venda é de R${0}", vendas.menorVenda);
            //Console.WriteLine("A venda média é de R${0}", vendas.vendaMedia);
            #endregion MAXMINAVG

            #region LinQ1
            //LINQ 1
            //            var vendaMedia = contexto.NotasFiscais.Average(nf => nf.Total);

            //            Console.WriteLine("Venda Média: {0}", vendaMedia);
            //            //Venda Média: 5.651941

            //            var query =
            //            from nf in contexto.NotasFiscais
            //            select nf.Total;
            //            decimal mediana = Mediana(query);

            //            Console.WriteLine("Mediana: {0}", mediana);

            //            var vendaMediana = contexto.NotasFiscais.Mediana(nf => nf.Total);

            //            Console.WriteLine("Mediana (com método de extensão): {0}", vendaMediana);

            //            Console.ReadKey();

            //        }


            //    }

            //    private static decimal Mediana(IQueryable<decimal> query)
            //    {
            //        var contagem = query.Count();

            //        var queryOrdenada = query.OrderBy(total => total);

            //        var elementoCentral_1 =
            //            queryOrdenada.Skip(contagem / 2).First();

            //        var elementoCentral_2 =
            //            queryOrdenada.Skip((contagem - 1) / 2).First();


            //        var mediana = (elementoCentral_1 + elementoCentral_2) / 2;
            //        return mediana;
            //    }
            //}

            //static class LinqExtension
            //{
            //    public static decimal Mediana<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector)
            //    {
            //        var contagem = source.Count();

            //        var funcSelector = selector.Compile();

            //        var queryOrdenada = source.Select(funcSelector).OrderBy(total => total);

            //        var elementoCentral_1 =
            //            queryOrdenada.Skip(contagem / 2).First();

            //        var elementoCentral_2 =
            //            queryOrdenada.Skip((contagem - 1) / 2).First();


            //        var mediana = (elementoCentral_1 + elementoCentral_2) / 2;
            //        return mediana;
            #endregion LinQ1

            #region LinQ2  

            #region PAGINAÇÃO

            // PAGINAÇÃO

            //const int TAMANHO_PAGINA = 10;

            //        var numeroNotasFiscais = contexto.NotasFiscais.Count();
            //        var numeroPaginas = Math.Ceiling((decimal)numeroNotasFiscais) / TAMANHO_PAGINA;

            //        for (var p = 1; p < numeroPaginas; p++)
            //        {
            //            ImprimirPagina(TAMANHO_PAGINA, contexto, p);
            //        }             

            //        Console.ReadKey();


            //    }
            //}

            //private static void ImprimirPagina(int TAMANHO_PAGINA, AluraTunesEntities contexto, int numeroPagina)
            //{
            //    var query =
            //    from nf in contexto.NotasFiscais
            //    orderby nf.NotaFiscalId
            //    select new
            //    {
            //        Numero = nf.NotaFiscalId,
            //        Data = nf.DataNotaFiscal,
            //        Cliente = nf.Cliente.PrimeiroNome + "" + nf.Cliente.Sobrenome,
            //        Total = nf.Total
            //    };


            //    int numeroDePulos = (numeroPagina - 1) * TAMANHO_PAGINA;

            //    query = query.Skip(numeroDePulos);

            //    query = query.Take(TAMANHO_PAGINA);

            //    Console.WriteLine();
            //    Console.WriteLine("Número da Página: {0}", numeroPagina);

            //    foreach (var nf in query)
            //    {
            //        Console.WriteLine("{0}\t{1},\t{2},\t{3}", nf.Numero, nf.Data, nf.Cliente, nf.Total);
            //    }
            //}
            #endregion PAGINAÇÃO

            #region VENDAS ACIMA DA MÉDIA
            //RELATÓRIO COM VENDAS ACIMA DA MÉDIA
            //var queryMedia = contexto.NotasFiscais.Average(n => n.Total);

            //var query =
            //from nf in contexto.NotasFiscais
            //where nf.Total > queryMedia
            //orderby nf.Total descending
            //select new
            //{
            //    Numero = nf.NotaFiscalId,
            //    Data = nf.DataNotaFiscal,
            //    Cliente = nf.Cliente.PrimeiroNome + " " + nf.Cliente.Sobrenome,
            //    Valor = nf.Total
            //};

            //foreach (var notafiscal in query) 
            //{
            //    Console.WriteLine("{0}\t{1},\t{2},\t{3}", 
            //        notafiscal.Numero, 
            //        notafiscal.Data, 
            //        notafiscal.Cliente, 
            //        notafiscal.Valor);
            //}

            //Console.WriteLine("A média seria {0}", queryMedia);
            //Console.ReadKey();
            #endregion VENDAS ACIMA DA MÉDIA

            #region RELATÓRIO COM PRODUTO MAIS VENDIDO
            //RELATÓRIO COM O PRODUTO MAIS VENDIDO
            //var faixasQuery =
            //from f in contexto.Faixas
            //where f.ItemNotaFiscals.Count() > 0
            //let TotalDeVendas = f.ItemNotaFiscals.Sum(inf => inf.Quantidade * inf.PrecoUnitario)
            //orderby TotalDeVendas descending
            //select new
            //{
            //    f.FaixaId,
            //    f.Nome,
            //    Total = TotalDeVendas
            //};


            //var produtoMaisVendido = faixasQuery.First();

            //Console.WriteLine("{0}\t{1}\t{2}", produtoMaisVendido.FaixaId, produtoMaisVendido.Nome, produtoMaisVendido.Total);

            //var query =
            //from inf in contexto.ItemsNotaFiscal
            //where inf.FaixaId == produtoMaisVendido.FaixaId
            //select new
            //{
            //    NomeCliente = inf.NotaFiscal.Cliente.PrimeiroNome + " " + inf.NotaFiscal.Cliente.Sobrenome,
            //};

            //foreach ( var cliente in query )
            //{
            //    Console.WriteLine(cliente.NomeCliente);
            //}

            //Console.ReadKey();

            #endregion RELATÓRIO COM PRODUTO MAIS VENDIDO

            #region ANÁLISE DE AFINIDADE
            // ANÁLISE DE AFINTDADE: quem comprou um item, tbm comprou outros
            //    var nomeDaMusica = "Smells Like Teen Spirit";

            //using (var contexto = new AluraTunesEntities())
            //{
            //    var faixaIds =
            //    contexto.Faixas.Where(f => f.Nome == nomeDaMusica).Select(f => f.FaixaId);

            //    var query =
            //    from comprouItem in contexto.ItemsNotaFiscal
            //    join comprouTambem in contexto.ItemsNotaFiscal
            //        on comprouItem.NotaFiscalId equals comprouTambem.NotaFiscalId
            //    where faixaIds.Contains(comprouItem.FaixaId)
            //        && comprouItem.Faixa != comprouTambem.Faixa
            //    select comprouTambem;

            //    foreach (var item in query)
            //    {
            //        Console.WriteLine("{0}\t{1}", item.NotaFiscalId, item.Faixa.Nome);
            //    }
            //}

            #endregion ANÁLISE DE AFINIDADE

            #region RELATÓRIO COM ANIVERSARIANTES DO MÊS
            //var mesAniversario = 1;

            //while (mesAniversario <= 12)
            //{

            //    Console.WriteLine("Mês: {0}", mesAniversario);

            //    var lista =
            //    (from f in contexto.Funcionarios
            //    where f.DataNascimento.Value.Month == mesAniversario
            //    orderby f.DataNascimento.Value.Month, f.DataNascimento.Value.Day
            //    select f).ToList();

            //    mesAniversario++;

            //    foreach (var f in lista)
            //    {
            //        Console.WriteLine("{0:dd/MM}\t{1} {2}", f.DataNascimento, f.PrimeiroNome, f.Sobrenome);
            //    }
            //}
            //Console.ReadKey();


            #endregion RELATÓRIO COM ANIVERSARIANTES DO MÊS

            #region QRCode
            //var barcodeWriter = new BarcodeWriter();
            //barcodeWriter.Format = BarcodeFormat.QR_CODE;
            //barcodeWriter.Options = new ZXing.Common.EncodingOptions
            //{
            //    Width = 100,
            //    Height = 100,
            //};

            //if (!Directory.Exists(Imagens))
            //    Directory.CreateDirectory(Imagens);

            //using (var contexto = new AluraTunesEntities())
            //{
            //    var queryFaixas =
            //    from f in contexto.Faixas
            //    select f;

            //    var listaFaixas = queryFaixas.ToList();

            //    Stopwatch stopwatch = Stopwatch.StartNew();

            //    var queryCodigos =
            //    listaFaixas
            //    .AsParallel()
            //    .Select(f => new
            //    {
            //        Arquivo = string.Format("{0}\\{1}.jpg", Imagens, f.FaixaId),
            //        Imagem = barcodeWriter.Write(string.Format("aluratunes.com/faixa/{0}", f.FaixaId))
            //    });

            //    int contagem = queryCodigos.Count();

            //    stopwatch.Stop();

            //    Console.WriteLine("Códigos gerados: {0} em {1} segundos", 
            //        contagem, stopwatch.ElapsedMilliseconds / 1000.0); //2.6s com AsParallel -> 1.0s

            //    stopwatch = Stopwatch.StartNew();

            //    //foreach (var item in queryCodigos)
            //    //{
            //    //    item.Imagem.Save(item.Arquivo, ImageFormat.Jpeg);
            //    //}

            //    queryCodigos.ForAll(item => item.Imagem.Save(item.Arquivo, ImageFormat.Jpeg));

            //    stopwatch.Stop();

            //    Console.WriteLine("Códigos salvos em arquivos: {0} em {1} segundos",
            //        contagem, stopwatch.ElapsedMilliseconds / 1000.0); // foreach 5s // ForAll 4.5s


            //    Console.ReadKey();
            //}


            #endregion QRCode

            #region RELATÓRIO DE VENDAS AGRUPADO POR ANO E MÊS

            int clienteId = 17;

            using (var contexto = new AluraTunesEntities())
            {
                var vendasPorCliente =
                from v in contexto.ps_Vendas_Por_Cliente(clienteId)
                group v by new { v.DataNotaFiscal.Year, v.DataNotaFiscal.Month }
                    into agrupado
                orderby agrupado.Key.Year, agrupado.Key.Month
                select new 
                { 
                    Ano = agrupado.Key.Year,
                    Mes = agrupado.Key.Month,
                    Total = agrupado.Sum(t => t.Total)                
                };

                foreach (var item in vendasPorCliente)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", item.Ano, item.Mes, item.Total);

                }
            }

            Console.ReadKey();

            # endregion RELATÓRIO DE VENDAS AGRUPADO POR ANO E MÊS

            #endregion LinQ2


            // }
        }

    }

}




