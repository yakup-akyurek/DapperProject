using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.CategoryDto;

namespace DapperProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly DapperContext _context;

        public CategoryRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";//SQL query to insert a new category
            var parameters = new DynamicParameters();//Dapper DynamicParameters to hold the parameters
            parameters.Add("CategoryName", createCategoryDto.CategoryName);//Add parameter for CategoryName
            var connection = _context.CreateConnection();//Create a database connection
            await connection.ExecuteAsync(query, parameters);//Execute the query asynchronously
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "DELETE FROM Categories WHERE CategoryId = @CategoryId";//SQL query to delete a category by id
            var parameters = new DynamicParameters();//Dapper DynamicParameters to hold the parameters
            parameters.Add("CategoryId", id);//Add parameter for Id
            var connection = _context.CreateConnection();//Create a database connection
            await connection.ExecuteAsync(query, parameters);//Execute the query asynchronously
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "SELECT * FROM Categories";//SQL query to get all categories
            var connection = _context.CreateConnection();//Create a database connection
            var values = await connection.QueryAsync<ResultCategoryDto>(query);//Execute the query asynchronously and map results to ResultCategoryDto
            return values.ToList();
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            string query = "SELECT * FROM Categories WHERE CategoryId = @CategoryId";//SQL query to get a category by id
            var parameters = new DynamicParameters();//Dapper DynamicParameters to hold the parameters
            parameters.Add("CategoryId", id);//Add parameter for Id
            var connection = _context.CreateConnection();//Create a database connection
            var values= await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query);//Execute the query asynchronously and map result to GetByIdCategoryDto
            return values;

        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId";//SQL query to update a category
            var parameters = new DynamicParameters();//Dapper DynamicParameters to hold the parameters
            parameters.Add("CategoryId", updateCategoryDto.CategoryId);//Add parameter for CategoryId
            parameters.Add("CategoryName", updateCategoryDto.CategoryName);//Add parameter for CategoryName
            var connection = _context.CreateConnection();//Create a database connection
            await connection.ExecuteAsync(query, parameters);//Execute the query asynchronously
        }
    }
}
