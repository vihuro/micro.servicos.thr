using SharpCifs.Smb;
using System.Globalization;
using System.Text;
using THR.ObraNotas.DTO.NotaRadarDto;
using THR.ObraNotas.Interface;

namespace THR.OBRA.NOTAS.Service.NotasRadar
{
    public class NotasRadarService : INotaRADARService
    {
        public async Task<List<NotaTXTDto>> GetAll()
        {
            var list = new List<NotaTXTDto>();
            var filePath = "smb://192.168.2.24/reports/obra_bi_REL_teste.txt";
            var auth = new NtlmPasswordAuthentication("192.168.2.24", "thr", "thr1");
            using (var reader = new SmbFile(filePath, auth).GetInputStream())
            using (var leitor = new StreamReader(reader,
                                                    Encoding.GetEncoding("ISO=8859-1"), true))
            {
                await leitor.ReadLineAsync();
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split("|");
                    var verificacao = list.Where(x => x.NumeroNota == CustomReplace(valores[0]) &&
                                                  x.Cnpj == CustomReplace(valores[3]).Trim()).FirstOrDefault();
                    if (verificacao == null)
                    {
                        list.Add(NovaLinha(valores));
                        continue;
                    }
                    var parcela = AddParcela(CustomReplace(valores[5]), CustomReplace(valores[9]));
                    var produtoServico = AddProdutoServico(CustomReplace(valores[6]), CustomReplace(valores[8]));
                    if (parcela != null) verificacao.Parcelas.Add(parcela);
                    if (produtoServico != null) verificacao.ProdutoServico.Add(produtoServico);
                }
                return list;
            }
        }

        private NotaTXTDto NovaLinha(string[] valores)
        {
            var dto = new NotaTXTDto()
            {
                NumeroNota = CustomReplace(valores[0]),
                Fornecedor = CustomReplace(valores[1]),
                ValorTotalNota = decimal.Parse(CustomReplace(valores[2])).ToString("###,###.##"),
                Cnpj = CustomReplace(valores[3]).Trim(),
                DescricaoProdutoServico = CustomReplace(valores[4]),
                Parcelas = new List<ParcelasDto>(),
                ProdutoServico = new List<DescricaoProdutoServicoDto>()
            };
            var parcela = AddParcela(CustomReplace(valores[5]), CustomReplace(valores[9]));
            var produtoServico = AddProdutoServico(CustomReplace(valores[6]), CustomReplace(valores[8]));
            if(parcela != null) dto.Parcelas.Add(parcela);
            if(produtoServico != null) dto.ProdutoServico.Add(produtoServico);
            
            return dto;

        }

        private ParcelasDto AddParcela(string numeroParcela, string vencimento)
        {
            if (numeroParcela == string.Empty) return null;
            if (!DateTime.TryParseExact(vencimento, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataVencimento)) return null;

            return new ParcelasDto() { NumeroParcela = numeroParcela, Vencimento = dataVencimento.ToUniversalTime() };
        }
        private DescricaoProdutoServicoDto AddProdutoServico(string descricaoProduto, string complemento)
        {
            if (descricaoProduto == string.Empty) return null;
            return new DescricaoProdutoServicoDto() { DescricaoProduto = descricaoProduto, Complemento = complemento };
        }

        private string CustomReplace(string value)
        {
            return value.Replace("\"", "");
        }

        public Task<List<NotaTXTDto>> GetNotSaved()
        {
            throw new NotImplementedException();
        }
    }
}
