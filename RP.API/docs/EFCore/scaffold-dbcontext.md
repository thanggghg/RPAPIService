## 2. Scaffold Entities from the Database

The next step is to generate the entity classes and DbContext from your existing database schema using the `Scaffold-DbContext` command.

### Step 1: Run the Scaffold Command

    `dotnet ef dbcontext scaffold "YourConnectionString" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Data --context YourDbContextName --force` 

-   **YourConnectionString**: Replace this with the actual connection string to your SQL Server database.
-   **Microsoft.EntityFrameworkCore.SqlServer**: Specifies the database provider.
-   **--output-dir Models**: Specifies the directory to place the generated entity classes (in this case, inside the `Models` folder).
-   **--context-dir Data**: Specifies the directory to place the DbContext (in this case, inside the `Data` folder).
-   **--context YourDbContextName**: Sets the name of the generated DbContext class.
-   **--force**: Forces overwriting of the existing files if they already exist.

### Example:

    `dotnet ef dbcontext scaffold "Server=myServer;Database=myDb;User Id=myUser;Password=myPassword;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Data --context AppDbContext --force` 

This command will generate:

-   Entity classes based on your database tables in the `Models` folder.
-   A **DbContext** named `AppDbContext` in the `Data` folder.


`# Database First with Entity Framework Core and Repository Pattern

## Introduction

**Database First** approach in **Entity Framework Core** allows you to generate entity classes and a DbContext based on an existing database schema. This is particularly useful when you are working with legacy databases or databases managed outside your application.

This guide will cover how to:

1. Scaffold the entity and DbContext classes from an existing database.
2. Update entities when the database schema changes.
3. Implement the **Repository Pattern** to interact with your data.

---

## 1. Installing Entity Framework Core

Before you start, ensure you have installed **Entity Framework Core** in your project.

### Step 1: Install EF Core Packages

In the **.NET CLI**, run the following commands to install the necessary EF Core packages:

    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Design` 

-   **Microsoft.EntityFrameworkCore.SqlServer**: Adds support for SQL Server.
-   **Microsoft.EntityFrameworkCore.Design**: Provides tools for scaffolding the DbContext and entity classes.

----------

## 2. Scaffold Entities from the Database

The next step is to generate the entity classes and DbContext from your existing database schema using the `Scaffold-DbContext` command.

### Step 1: Run the Scaffold Command

    `dotnet ef dbcontext scaffold "YourConnectionString" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Data --context YourDbContextName --force` 

-   **YourConnectionString**: Replace this with the actual connection string to your SQL Server database.
-   **Microsoft.EntityFrameworkCore.SqlServer**: Specifies the database provider.
-   **--output-dir Models**: Specifies the directory to place the generated entity classes (in this case, inside the `Models` folder).
-   **--context-dir Data**: Specifies the directory to place the DbContext (in this case, inside the `Data` folder).
-   **--context YourDbContextName**: Sets the name of the generated DbContext class.
-   **--force**: Forces overwriting of the existing files if they already exist.

### Example:

    `dotnet ef dbcontext scaffold "Server=myServer;Database=myDb;User Id=myUser;Password=myPassword;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Data --context AppDbContext --force` 

This command will generate:

-   Entity classes based on your database tables in the `Models` folder.
-   A **DbContext** named `AppDbContext` in the `Data` folder.

----------

## 3. Updating Entities After Database Changes

If the database schema changes (e.g., new columns, tables, or relationships), you need to regenerate the entity classes and DbContext. You can simply rerun the `Scaffold-DbContext` command with the `--force` flag to update the entity classes.

### Step 1: Re-run the Scaffold Command

    `dotnet ef dbcontext scaffold "YourConnectionString" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Data --context YourDbContextName --force` 

This will update your existing entity classes and DbContext to reflect the latest database schema changes.

----------

## 4. Using the Repository Pattern

The **Repository Pattern** is a design pattern used to abstract the data access logic and promote separation of concerns. It hides the complexity of data access behind simple interfaces.

### Step 1: Create the Repository Interface

First, create a generic interface for the repository.

    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }` 

This interface defines the basic CRUD operations for any entity.

### Step 2: Implement the Generic Repository

Now, create the generic repository class that implements the `IRepository` interface.

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
    
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
    
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

### Step 3: Create a Specific Repository

You can create a specific repository for an entity by extending the generic `Repository` class.

    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsWithDetails();
    }
    
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    
        public async Task<IEnumerable<Product>> GetProductsWithDetails()
        {
            return await _context.Products
                .Include(p => p.Category) // Assuming there's a related Category entity
                .ToListAsync();
        }
    }

----------

## 5. Using the Repository in the Service Layer

Once the repository is set up, you can use it in your service layer to interact with the database.

### Step 1: Create a Service Interface and Implementation

    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
    
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
    
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }
    
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    
        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }
    
        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }
    
        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }

----------

## 6. Registering Repositories and Services in Dependency Injection

You need to register your repositories and services in the **Startup.cs** or **Program.cs** for dependency injection.

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
    
            services.AddControllers();
        }
    }

----------

## 7. Using Repositories in Controllers

Finally, you can use the repository or service in your controllers to handle requests.

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
    
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            await _productService.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }
    
            await _productService.UpdateProductAsync(product);
            return NoContent();
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }

----------

## Conclusion

Using **Database First** with **Entity Framework Core** provides a quick and efficient way to generate entities from an existing database. By implementing the **Repository Pattern**, you can cleanly separate your data access logic from your business logic, making
