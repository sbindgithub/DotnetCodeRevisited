//GET /api/products/page/2/size/10


[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public ProductsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("page/{pageNumber}/size/{pageSize}")]
    public async Task<IActionResult> GetProducts(int pageNumber, int pageSize)
    {
        if (pageNumber <= 0 || pageSize <= 0)
            return BadRequest("Invalid pagination parameters");

        var products = new List<Product>();

        using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            await con.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("GetPagedProducts", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        products.Add(new Product
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"])
                        });
                    }
                }
            }
        }

        return Ok(products);
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}