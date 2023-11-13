using System.Net.Http.Json;
using ShopOnline.Shared.Dtos;

namespace ShopOnline.Web.Services.Contracts;

public class ProductService : IProductService
{
    public HttpClient HttpClient { get; }

    public ProductService(HttpClient httpClient) => HttpClient = httpClient;

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        try
        {
            HttpResponseMessage response = await HttpClient.GetAsync("Products");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<ProductDto>();
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>() ?? Enumerable.Empty<ProductDto>();
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }
        catch (Exception)
        {
            // TODO: Log exception
            throw;
        }
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        try
        {
            HttpResponseMessage response = await HttpClient.GetAsync($"Products/{id}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default;
                }

                return await response.Content.ReadFromJsonAsync<ProductDto>();
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }
        catch (Exception)
        {
            // TODO: Log exception
            throw;
        }
    }
}
