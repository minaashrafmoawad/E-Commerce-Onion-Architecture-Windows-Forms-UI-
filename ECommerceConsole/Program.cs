using Application.Contract;
using Application.Dtos;
using Application.Mapping;
using Application.Services;
using Applications.DTOs;
using Autofac;
using ECommerceWinForms;
using Models;
using System;
using System.Linq;

namespace ECommerceConsole
{
    class Program
    {
        private static IContainer _container;
        private static UserDTO _currentUser;

        static void Main(string[] args)
        {
            
            _container = AutofacConfig.Configure();
            MapsterConfig.Configure();

            
            SeedTestData();

            
            while (true)
            {
                if (_currentUser == null)
                {
                    ShowLoginMenu();
                }
                else if (_currentUser.Role == "Admin")
                {
                    ShowAdminMenu(); 
                }
                else
                {
                    ShowClientMenu();
                }
            }
        }

        static void SeedTestData()
        {
            try
            {
                Console.WriteLine("Starting SeedTestData...");
                using (var scope = _container.BeginLifetimeScope())
                {
                    var categoryRepo = scope.Resolve<ICategoryRepository>();
                    var productRepo = scope.Resolve<IProductRepository>();
                    var adminService = scope.Resolve<IAdminService>(); 

                 
                    Console.WriteLine("Checking for admin user...");
                    var adminExists = adminService.GetAllAdmins().Any();
                    if (!adminExists)
                    {
                        Console.WriteLine("No admin found. Creating admin user...");
                        var adminDto = new UserDTO
                        {
                            Username = "admin2",
                            Email = "admin@example.com",
                            FirstName = "Admin",
                            LastName = "User",
                            Password = "admin123",
                            Role = "Admin"
                        };
                        adminService.CreateAdmin(adminDto); 
                        Console.WriteLine("Admin user created.");
                    }

                  
                    Console.WriteLine("Checking if categories exist...");
                    var categories = categoryRepo.GetAll().ToList();
                    Console.WriteLine($"Found {categories.Count} categories.");

                    if (!categories.Any())
                    {
                        Console.WriteLine("No categories found. Seeding categories...");
                        var electronics = new Category { Name = "Electronics", Description = "Electronic gadgets" };
                        var clothing = new Category { Name = "Clothing", Description = "Apparel" };

                        Console.WriteLine("Creating Electronics category...");
                        categoryRepo.Create(electronics);
                        Console.WriteLine("Creating Clothing category...");
                        categoryRepo.Create(clothing);
                        Console.WriteLine("Saving categories...");
                        categoryRepo.SaveChanges();
                        Console.WriteLine("Categories saved.");
                    }

                    
                    Console.WriteLine("Checking if products exist...");
                    var products = productRepo.GetAll().ToList();
                    Console.WriteLine($"Found {products.Count} products.");

                    if (!products.Any())
                    {
                        Console.WriteLine("No products found. Seeding products...");
                        var electronics = categoryRepo.GetByName("Electronics") ?? new Category { Name = "Electronics", Description = "Electronic gadgets" };
                        var clothing = categoryRepo.GetByName("Clothing") ?? new Category { Name = "Clothing", Description = "Apparel" };

                        if (electronics.CategoryID == 0) categoryRepo.Create(electronics);
                        if (clothing.CategoryID == 0) categoryRepo.Create(clothing);
                        if (electronics.CategoryID == 0 || clothing.CategoryID == 0) categoryRepo.SaveChanges();

                        var electronicsId = categoryRepo.GetByName("Electronics")?.CategoryID;
                        var clothingId = categoryRepo.GetByName("Clothing")?.CategoryID;

                        if (electronicsId == null || clothingId == null)
                        {
                            Console.WriteLine("Error: Failed to retrieve CategoryID values.");
                            return;
                        }

                        Console.WriteLine("Creating products...");
                        productRepo.Create(new Product
                        {
                            Name = "Smartphone",
                            Description = "Latest model smartphone",
                            Price = 699.99m,
                            UnitsInStock = 50,
                            CategoryID = electronicsId.Value,
                            ImagePath = null
                        });
                        productRepo.Create(new Product
                        {
                            Name = "T-Shirt",
                            Description = "Cotton T-Shirt",
                            Price = 19.99m,
                            UnitsInStock = 100,
                            CategoryID = clothingId.Value,
                            ImagePath = null
                        });
                        Console.WriteLine("Saving products...");
                        productRepo.SaveChanges();
                        Console.WriteLine("Products saved.");
                    }
                }
                Console.WriteLine("SeedTestData completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SeedTestData: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            }
        }

        static void ShowLoginMenu()
        {
            Console.WriteLine("\n=== E-Commerce Console App ===");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Register();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        static void ShowClientMenu()
        {
            Console.WriteLine($"\n=== Welcome, {_currentUser.Username} ===");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. View Product Details");
            Console.WriteLine("3. Add to Cart");
            Console.WriteLine("4. View Cart");
            Console.WriteLine("5. Modify Cart");
            Console.WriteLine("6. Submit Order");
            Console.WriteLine("7. View Order History");
            Console.WriteLine("8. View Account Details");
            Console.WriteLine("9. Edit Account Details");
            Console.WriteLine("10. Logout");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ViewProducts();
                    break;
                case "2":
                    ViewProductDetails();
                    break;
                case "3":
                    AddToCart();
                    break;
                case "4":
                    ViewCart();
                    break;
                case "5":
                    ModifyCart();
                    break;
                case "6":
                    SubmitOrder();
                    break;
                case "7":
                    ViewOrderHistory();
                    break;
                case "8":
                    ViewAccountDetails();
                    break;
                case "9":
                    EditAccountDetails();
                    break;
                case "10":
                    _currentUser = null;
                    Console.WriteLine("Logged out successfully.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        static void ShowAdminMenu() 
        {
            Console.WriteLine($"\n=== Admin Panel, {_currentUser.Username} ===");
            Console.WriteLine("1. View All Categories"); // Req 02
            Console.WriteLine("2. Add Category"); // Req 03
            Console.WriteLine("3. Edit Category"); // Req 04
            Console.WriteLine("4. Delete Category"); // Req 05
            Console.WriteLine("5. View All Products"); // Req 06
            Console.WriteLine("6. Add Product"); // Req 07
            Console.WriteLine("7. Edit Product"); // Req 08
            Console.WriteLine("8. Delete Product"); // Req 09
            Console.WriteLine("9. View Orders"); // Req 10
            Console.WriteLine("10. Approve Order"); // Req 11
            Console.WriteLine("11. Deny Order"); // Req 12
            Console.WriteLine("12. View All Clients"); // Req 13
            Console.WriteLine("13. Activate Client"); // Req 14
            Console.WriteLine("14. Deactivate Client"); // Req 15
            Console.WriteLine("15. Add Admin User"); // Req 16
            Console.WriteLine("16. View All Admins"); // Req 17
            Console.WriteLine("17. Manage Admin User"); // Req 18
            Console.WriteLine("18. Logout");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ViewAllCategories();
                    break;
                case "2":
                    AddCategory();
                    break;
                case "3":
                    EditCategory();
                    break;
                case "4":
                    DeleteCategory();
                    break;
                case "5":
                    ViewAllProducts();
                    break;
                case "6":
                    AddProduct();
                    break;
                case "7":
                    EditProduct();
                    break;
                case "8":
                    DeleteProduct();
                    break;
                case "9":
                    ViewOrders();
                    break;
                case "10":
                    ApproveOrder();
                    break;
                case "11":
                    DenyOrder();
                    break;
                case "12":
                    ViewAllClients();
                    break;
                case "13":
                    ActivateClient();
                    break;
                case "14":
                    DeactivateClient();
                    break;
                case "15":
                    AddAdminUser();
                    break;
                case "16":
                    ViewAllAdmins();
                    break;
                case "17":
                    ManageAdminUser();
                    break;
                case "18":
                    _currentUser = null;
                    Console.WriteLine("Logged out successfully.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        static void Register()
        {
            try
            {
                Console.WriteLine("\n=== Register ===");
                Console.Write("Username: ");
                var username = Console.ReadLine();
                Console.Write("Password: ");
                var password = Console.ReadLine();
                Console.Write("Email: ");
                var email = Console.ReadLine();
                Console.Write("First Name: ");
                var firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                var lastName = Console.ReadLine();

                using (var scope = _container.BeginLifetimeScope())
                {
                    var userService = scope.Resolve<IUserService>();
                    var user = new User
                    {
                        Username = username,
                        Password = password,
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        Role = UserRole.Client
                    };

                    var userDto = userService.Register(user);
                    Console.WriteLine($"Registration successful! User ID: {userDto.UserID}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void Login()
        {
            try
            {
                Console.WriteLine("\n=== Login ===");
                Console.Write("Username: ");
                var username = Console.ReadLine();
                Console.Write("Password: ");
                var password = Console.ReadLine();

                using (var scope = _container.BeginLifetimeScope())
                {
                    var userService = scope.Resolve<IUserService>();
                    _currentUser = userService.Login(username, password);
                    Console.WriteLine("Login successful!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewProducts()
        {
            try
            {
                Console.WriteLine("\n=== Product List ===");
                using (var scope = _container.BeginLifetimeScope())
                {
                    var productService = scope.Resolve<IProductService>();
                    var products = productService.GetAllProducts();
                    foreach (var product in products)
                    {
                        Console.WriteLine($"ID: {product.ProductID}, Name: {product.Name}, Price: ${product.Price}, Stock: {product.UnitsInStock}, Category: {product.CategoryName}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewProductDetails()
        {
            try
            {
                Console.WriteLine("\n=== View Product Details ===");
                Console.Write("Enter Product ID: ");
                if (int.TryParse(Console.ReadLine(), out int productId))
                {
                    using (var scope = _container.BeginLifetimeScope())
                    {
                        var productService = scope.Resolve<IProductService>();
                        var product = productService.GetProductById(productId);
                        Console.WriteLine($"ID: {product.ProductID}");
                        Console.WriteLine($"Name: {product.Name}");
                        Console.WriteLine($"Description: {product.Description}");
                        Console.WriteLine($"Price: ${product.Price}");
                        Console.WriteLine($"Stock: {product.UnitsInStock}");
                        Console.WriteLine($"Category: {product.CategoryName}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Product ID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void AddToCart()
        {
            try
            {
                Console.WriteLine("\n=== Add to Cart ===");
                Console.Write("Enter Product ID: ");
                if (int.TryParse(Console.ReadLine(), out int productId))
                {
                    Console.Write("Enter Quantity: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        using (var scope = _container.BeginLifetimeScope())
                        {
                            var cartService = scope.Resolve<ICartService>();
                            cartService.AddToCart(_currentUser.UserID, productId, quantity);
                            Console.WriteLine("Product added to cart successfully!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Product ID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewCart()
        {
            try
            {
                Console.WriteLine("\n=== Shopping Cart ===");
                using (var scope = _container.BeginLifetimeScope())
                {
                    var cartService = scope.Resolve<ICartService>();
                    var cartItems = cartService.GetCartItems(_currentUser.UserID);
                    if (!cartItems.Any())
                    {
                        Console.WriteLine("Your cart is empty.");
                        return;
                    }

                    foreach (var item in cartItems)
                    {
                        Console.WriteLine($"CartItem ID: {item.CartItemID}, Product: {item.ProductName}, Quantity: {item.Quantity}, Price: ${item.Price}, Total: ${item.TotalPrice}");
                    }
                    Console.WriteLine($"Cart Total: ${cartService.GetCartTotal(_currentUser.UserID)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ModifyCart()
        {
            try
            {
                Console.WriteLine("\n=== Modify Cart ===");
                ViewCart();
                Console.Write("Enter CartItem ID to modify/remove (or 0 to cancel): ");
                if (int.TryParse(Console.ReadLine(), out int cartItemId) && cartItemId != 0)
                {
                    Console.Write("Enter new quantity (0 to remove): ");
                    if (int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        using (var scope = _container.BeginLifetimeScope())
                        {
                            var cartService = scope.Resolve<ICartService>();
                            if (quantity == 0)
                            {
                                cartService.RemoveCartItem(cartItemId);
                                Console.WriteLine("Item removed from cart.");
                            }
                            else
                            {
                                cartService.UpdateCartItem(cartItemId, quantity);
                                Console.WriteLine("Cart updated successfully.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void SubmitOrder()
        {
            try
            {
                Console.WriteLine("\n=== Submit Order ===");
                using (var scope = _container.BeginLifetimeScope())
                {
                    var orderService = scope.Resolve<IOrderService>();
                    var order = orderService.CreateOrder(_currentUser.UserID);
                    Console.WriteLine($"Order created successfully! Order ID: {order.OrderID}, Total: ${order.TotalAmount}, Status: {order.Status}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewOrderHistory()
        {
            try
            {
                Console.WriteLine("\n=== Order History ===");
                using (var scope = _container.BeginLifetimeScope())
                {
                    var orderService = scope.Resolve<IOrderService>();
                    var orders = orderService.GetUserOrders(_currentUser.UserID);
                    if (!orders.Any())
                    {
                        Console.WriteLine("No orders found.");
                        return;
                    }

                    foreach (var order in orders)
                    {
                        Console.WriteLine($"Order ID: {order.OrderID}, Date: {order.OrderDate}, Total: ${order.TotalAmount}, Status: {order.Status}");
                        foreach (var detail in order.OrderDetails)
                        {
                            Console.WriteLine($"  - Product: {detail.ProductName}, Quantity: {detail.Quantity}, Price: ${detail.Price}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewAccountDetails()
        {
            try
            {
                Console.WriteLine("\n=== Account Details ===");
                using (var scope = _container.BeginLifetimeScope())
                {
                    var userService = scope.Resolve<IUserService>();
                    var user = userService.GetUserById(_currentUser.UserID);
                    Console.WriteLine($"Username: {user.Username}");
                    Console.WriteLine($"Email: {user.Email}");
                    Console.WriteLine($"First Name: {user.FirstName}");
                    Console.WriteLine($"Last Name: {user.LastName}");
                    Console.WriteLine($"Role: {user.Role}");
                    Console.WriteLine($"Active: {user.IsActive}");
                    Console.WriteLine($"Date Created: {user.DateCreated}");
                    Console.WriteLine($"Last Login: {user.LastLoginDate}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void EditAccountDetails()
        {
            try
            {
                Console.WriteLine("\n=== Edit Account Details ===");
                using (var scope = _container.BeginLifetimeScope())
                {
                    var userService = scope.Resolve<IUserService>();
                    var current = userService.GetUserById(_currentUser.UserID);
                    Console.Write($"New Username ({current.Username}): ");
                    var username = Console.ReadLine();
                    if (string.IsNullOrEmpty(username)) username = current.Username;

                    Console.Write("New Password (leave blank to keep current): ");
                    var password = Console.ReadLine();

                    Console.Write($"New Email ({current.Email}): ");
                    var email = Console.ReadLine();
                    if (string.IsNullOrEmpty(email)) email = current.Email;

                    Console.Write($"New First Name ({current.FirstName}): ");
                    var firstName = Console.ReadLine();
                    if (string.IsNullOrEmpty(firstName)) firstName = current.FirstName;

                    Console.Write($"New Last Name ({current.LastName}): ");
                    var lastName = Console.ReadLine();
                    if (string.IsNullOrEmpty(lastName)) lastName = current.LastName;

                    var user = new User
                    {
                        UserID = current.UserID,
                        Username = username,
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        Role = current.Role == "Client" ? UserRole.Client : UserRole.Admin,
                        Password = password
                    };

                    var updatedUser = userService.UpdateUser(user);
                    _currentUser = updatedUser;
                    Console.WriteLine("Account updated successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    
        static void ViewAllCategories()
        {
            try
            {
                Console.WriteLine("\n=== All Categories ===");
                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    var categories = adminService.GetAllCategories();
                    if (!categories.Any())
                    {
                        Console.WriteLine("No categories found.");
                        return;
                    }
                    foreach (var category in categories)
                    {
                        Console.WriteLine($"ID: {category.CategoryID}, Name: {category.Name}, Description: {category.Description}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void AddCategory() 
        {
            try
            {
                Console.WriteLine("\n=== Add Category ===");
                Console.Write("Name: ");
                var name = Console.ReadLine();
                Console.Write("Description: ");
                var description = Console.ReadLine();

                var categoryDto = new CategoryDTO
                {
                    Name = name,
                    Description = description
                };

                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    var createdCategory = adminService.AddCategory(categoryDto);
                    Console.WriteLine($"Category added successfully! Category ID: {createdCategory.CategoryID}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void EditCategory() 
        {
            try
            {
                Console.WriteLine("\n=== Edit Category ===");
                ViewAllCategories();
                Console.Write("Enter Category ID: ");
                if (!int.TryParse(Console.ReadLine(), out int categoryId))
                {
                    Console.WriteLine("Invalid category ID.");
                    return;
                }

                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    var category = adminService.GetAllCategories().FirstOrDefault(c => c.CategoryID == categoryId);
                    if (category == null)
                    {
                        Console.WriteLine("Category not found.");
                        return;
                    }

                    Console.Write($"New Name ({category.Name}): ");
                    var name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name)) name = category.Name;

                    Console.Write($"New Description ({category.Description}): ");
                    var description = Console.ReadLine();
                    if (string.IsNullOrEmpty(description)) description = category.Description;

                    var categoryDto = new CategoryDTO
                    {
                        CategoryID = categoryId,
                        Name = name,
                        Description = description
                    };

                    adminService.UpdateCategory(categoryDto);
                    Console.WriteLine("Category updated successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeleteCategory() 
        {
            try
            {
                Console.WriteLine("\n=== Delete Category ===");
                ViewAllCategories();
                Console.Write("Enter Category ID: ");
                if (!int.TryParse(Console.ReadLine(), out int categoryId))
                {
                    Console.WriteLine("Invalid category ID.");
                    return;
                }

                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    adminService.DeleteCategory(categoryId);
                    Console.WriteLine("Category deleted successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewAllProducts() 
        {
            try
            {
                Console.WriteLine("\n=== All Products ===");
                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    var products = adminService.GetAllProducts();
                    if (!products.Any())
                    {
                        Console.WriteLine("No products found.");
                        return;
                    }
                    foreach (var product in products)
                    {
                        Console.WriteLine($"ID: {product.ProductID}, Name: {product.Name}, Price: ${product.Price}, Stock: {product.UnitsInStock}, Category: {product.CategoryName}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void AddProduct() 
        {
            try
            {
                Console.WriteLine("\n=== Add Product ===");
                Console.Write("Name: ");
                var name = Console.ReadLine();
                Console.Write("Description: ");
                var description = Console.ReadLine();
                Console.Write("Price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    Console.WriteLine("Invalid price.");
                    return;
                }
                Console.Write("Units in Stock: ");
                if (!int.TryParse(Console.ReadLine(), out int unitsInStock))
                {
                    Console.WriteLine("Invalid stock quantity.");
                    return;
                }
                Console.Write("Category ID: ");
                if (!int.TryParse(Console.ReadLine(), out int categoryId))
                {
                    Console.WriteLine("Invalid category ID.");
                    return;
                }
                Console.Write("Image Path (optional): ");
                var imagePath = Console.ReadLine();

                var productDto = new ProductDTO
                {
                    Name = name,
                    Description = description,
                    Price = price,
                    UnitsInStock = unitsInStock,
                    CategoryID = categoryId,
                    ImagePath = string.IsNullOrEmpty(imagePath) ? null : imagePath
                };

                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    var createdProduct = adminService.AddProduct(productDto);
                    Console.WriteLine($"Product added successfully! Product ID: {createdProduct.ProductID}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void EditProduct() 
        {
            try
            {
                Console.WriteLine("\n=== Edit Product ===");
                ViewAllProducts();
                Console.Write("Enter Product ID: ");
                if (!int.TryParse(Console.ReadLine(), out int productId))
                {
                    Console.WriteLine("Invalid product ID.");
                    return;
                }

                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    var product = adminService.GetAllProducts().FirstOrDefault(p => p.ProductID == productId);
                    if (product == null)
                    {
                        Console.WriteLine("Product not found.");
                        return;
                    }

                    Console.Write($"New Name ({product.Name}): ");
                    var name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name)) name = product.Name;

                    Console.Write($"New Description ({product.Description}): ");
                    var description = Console.ReadLine();
                    if (string.IsNullOrEmpty(description)) description = product.Description;

                    Console.Write($"New Price ({product.Price}): ");
                    var priceInput = Console.ReadLine();
                    decimal price = string.IsNullOrEmpty(priceInput) ? product.Price : decimal.Parse(priceInput);

                    Console.Write($"New Units in Stock ({product.UnitsInStock}): ");
                    var stockInput = Console.ReadLine();
                    int unitsInStock = string.IsNullOrEmpty(stockInput) ? product.UnitsInStock : int.Parse(stockInput);

                    Console.Write($"New Category ID ({product.CategoryID}): ");
                    var categoryInput = Console.ReadLine();
                    int categoryId = string.IsNullOrEmpty(categoryInput) ? product.CategoryID : int.Parse(categoryInput);

                    Console.Write($"New Image Path ({product.ImagePath}): ");
                    var imagePath = Console.ReadLine();
                    if (string.IsNullOrEmpty(imagePath)) imagePath = product.ImagePath;

                    var productDto = new ProductDTO
                    {
                        ProductID = productId,
                        Name = name,
                        Description = description,
                        Price = price,
                        UnitsInStock = unitsInStock,
                        CategoryID = categoryId,
                        ImagePath = imagePath
                    };

                    adminService.UpdateProduct(productDto);
                    Console.WriteLine("Product updated successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeleteProduct() 
        {
            try
            {
                Console.WriteLine("\n=== Delete Product ===");
                ViewAllProducts();
                Console.Write("Enter Product ID: ");
                if (!int.TryParse(Console.ReadLine(), out int productId))
                {
                    Console.WriteLine("Invalid product ID.");
                    return;
                }

                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    adminService.DeleteProduct(productId);
                    Console.WriteLine("Product deleted successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewOrders() 
        {
            try
            {
                Console.WriteLine("\n=== View Orders ===");
                Console.Write("Enter status to filter (Pending, Approved, Denied, Shipped, or blank for all): ");
                var status = Console.ReadLine();
                if (string.IsNullOrEmpty(status)) status = null;

                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    var orders = adminService.GetAllOrders(status);
                    if (!orders.Any())
                    {
                        Console.WriteLine("No orders found.");
                        return;
                    }

                    foreach (var order in orders)
                    {
                        Console.WriteLine($"Order ID: {order.OrderID}, User ID: {order.UserID}, Date: {order.OrderDate}, Total: ${order.TotalAmount}, Status: {order.Status}");
                        foreach (var detail in order.OrderDetails)
                        {
                            Console.WriteLine($"  - Product: {detail.ProductName}, Quantity: {detail.Quantity}, Price: ${detail.Price}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ApproveOrder() 
        {
            try
            {
                Console.WriteLine("\n=== Approve Order ===");
                ViewOrders();
                Console.Write("Enter Order ID to approve: ");
                if (!int.TryParse(Console.ReadLine(), out int orderId))
                {
                    Console.WriteLine("Invalid order ID.");
                    return;
                }

                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    adminService.UpdateOrderStatus(orderId, "Approved");
                    Console.WriteLine("Order approved successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DenyOrder() 
        {
            try
            {
                Console.WriteLine("\n=== Deny Order ===");
                ViewOrders();
                Console.Write("Enter Order ID to deny: ");
                if (!int.TryParse(Console.ReadLine(), out int orderId))
                {
                    Console.WriteLine("Invalid order ID.");
                    return;
                }

                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    adminService.UpdateOrderStatus(orderId, "Denied");
                    Console.WriteLine("Order denied successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewAllClients() 
        {
            try
            {
                Console.WriteLine("\n=== All Clients ===");
                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    var clients = adminService.GetAllClients();
                    if (!clients.Any())
                    {
                        Console.WriteLine("No clients found.");
                        return;
                    }
                    foreach (var client in clients)
                    {
                        Console.WriteLine($"ID: {client.UserID}, Username: {client.Username}, Email: {client.Email}, Active: {client.IsActive}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ActivateClient() 
        {
            try
            {
                Console.WriteLine("\n=== Activate Client ===");
                ViewAllClients();
                Console.Write("Enter Client ID to activate: ");
                if (!int.TryParse(Console.ReadLine(), out int userId))
                {
                    Console.WriteLine("Invalid client ID.");
                    return;
                }

                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    adminService.ActivateUser(userId);
                    Console.WriteLine("Client activated successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeactivateClient() 
        {
            try
            {
                Console.WriteLine("\n=== Deactivate Client ===");
                ViewAllClients();
                Console.Write("Enter Client ID to deactivate: ");
                if (!int.TryParse(Console.ReadLine(), out int userId))
                {
                    Console.WriteLine("Invalid client ID.");
                    return;
                }

                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    adminService.DeactivateUser(userId);
                    Console.WriteLine("Client deactivated successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void AddAdminUser() 
        {
            try
            {
                Console.WriteLine("\n=== Add Admin User ===");
                Console.Write("Username: ");
                var username = Console.ReadLine();
                Console.Write("Password: ");
                var password = Console.ReadLine();
                Console.Write("Email: ");
                var email = Console.ReadLine();
                Console.Write("First Name: ");
                var firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                var lastName = Console.ReadLine();

                var userDto = new UserDTO
                {
                    Username = username,
                    Password = password,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Role = "Admin"
                };

                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>(); // Use IAdminService
                    var createdAdmin = adminService.CreateAdmin(userDto);
                    Console.WriteLine($"Admin user added successfully! User ID: {createdAdmin.UserID}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewAllAdmins() 
        {
            try
            {
                Console.WriteLine("\n=== All Admins ===");
                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    var admins = adminService.GetAllAdmins();
                    if (!admins.Any())
                    {
                        Console.WriteLine("No admins found.");
                        return;
                    }
                    foreach (var admin in admins)
                    {
                        Console.WriteLine($"ID: {admin.UserID}, Username: {admin.Username}, Email: {admin.Email}, Active: {admin.IsActive}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ManageAdminUser() 
        {
            try
            {
                Console.WriteLine("\n=== Manage Admin User ===");
                ViewAllAdmins();
                Console.Write("Enter Admin ID: ");
                if (!int.TryParse(Console.ReadLine(), out int userId))
                {
                    Console.WriteLine("Invalid admin ID.");
                    return;
                }

                Console.Write("Activate (y/n): ");
                var activateInput = Console.ReadLine()?.ToLower();
                bool activate = activateInput == "y";

                using (var scope = _container.BeginLifetimeScope())
                {
                    var adminService = scope.Resolve<IAdminService>();
                    adminService.ManageAdminUser(userId, activate);
                    Console.WriteLine($"Admin user {(activate ? "activated" : "deactivated")} successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}