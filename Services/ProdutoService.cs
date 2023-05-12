using LojaDiversidadesFront.Models;
using LojaDiversidadesFront.Utils;
using Newtonsoft.Json;

namespace LojaDiversidadesFront.Services;
public class ProdutoService
{
    private HttpClient _httpClient;
    public ProdutoService() => _httpClient = Client.ClientConstructor();

    public async Task<List<Product>> Listar()
    {
        try
        {
            HttpResponseMessage data = await _httpClient.GetAsync("Produtos");

            return data.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<List<Product>>(data.Content.ReadAsStringAsync().Result)
                : new List<Product>();
        }
        catch (Exception ex)
        {
            ConsoleErrorMessage(ex);
            return new List<Product>();
        }
    }

    public async Task<bool> Incluir(Product produto)
    {
        try
        {
            Product p = await VerificarDisponibilidade(produto.Code);

            if (p.Code != string.Empty)
            {
                HttpResponseMessage retorno = await _httpClient.PostAsJsonAsync("Produtos", produto);
                return retorno.IsSuccessStatusCode;
            }
            else { return false; }
        }
        catch (Exception ex)
        {
            ConsoleErrorMessage(ex);
            return false;
        }
    }

    public async Task<bool> Alterar(Product produto)
    {
        try
        {
            Product p = await VerificarDisponibilidade(produto.Code);

            if (p.Code == string.Empty || p.Id == produto.Id)
            {
                HttpResponseMessage retorno = await _httpClient.PutAsJsonAsync("Produtos/" + produto.Id, produto);
                return retorno.IsSuccessStatusCode;
            }
            else { return false; }
        }
        catch (Exception ex)
        {
            ConsoleErrorMessage(ex);
            return false;
        }
    }

    public async Task<bool> Excluir(int id)
    {
        try
        {
            HttpResponseMessage retorno = await _httpClient.DeleteAsync("Produtos/" + id);
            return retorno.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            ConsoleErrorMessage(ex);
            return false;
        }
    }

    private async Task<Product> VerificarDisponibilidade(string codigo)
    {
        try
        {
            HttpResponseMessage data = await _httpClient.GetAsync("Produtos/Codigo=" + codigo);

            return data.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<Product>(data.Content.ReadAsStringAsync().Result)
                : new Product();
        }
        catch (Exception ex)
        {
            ConsoleErrorMessage(ex);
            return new Product();
        }
    }

    private static void ConsoleErrorMessage(Exception ex)
    {
        Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
    }
}