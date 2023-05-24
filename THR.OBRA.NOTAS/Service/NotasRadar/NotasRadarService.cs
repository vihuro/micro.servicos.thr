using SharpCifs.Smb;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using THR.OBRA.NOTAS.Service.CustomException;
using THR.OBRA.NOTAS.Utils;
using THR.ObraNotas.DTO.NotaRadarDto;
using THR.ObraNotas.Interface;

namespace THR.OBRA.NOTAS.Service.NotasRadar
{
    public class NotasRadarService : INotaRADARService
    {
        private readonly FilePath _filePath;
        private readonly ReaderFile _readerFile;

        public NotasRadarService(FilePath filePath, 
                                 ReaderFile readerFile)
        {
            _filePath = filePath;
            _readerFile = readerFile;
        }

        public async Task<List<NotaTXTDto>> GetAll()
        {
            var list = new List<NotaTXTDto>();
            var filePath = _filePath.Caminho;

            try
            {
                using var leitor = _readerFile.GetFileReader(_filePath.Caminho);
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
            catch (Exception ex)
            {

                throw new MyException(ex.Message);
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
