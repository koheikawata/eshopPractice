# eshopPractice
## Step 1
Use In memory database and display the front page

### Root directory
- `Program.cs`
- `Startup.cs`
- `Constants.cs`

### wwwroot
- `content/site.css`

### Pages
- `Index.cshtml`
- `Index.cshtml.cs`
- `_ViewImports.cshtml`
- `_ViewStart.cshtml`
- `Shared/_Layout.cshtml`
- `Shared/_product.cshtml`
- `Shared/_pagination.cshtml`

### ApplicationCore
- `CatalogSettings.cs`
- `Entities/BaseEntity.cs`
- `Entities/CatalogBrand.cs`
- `Entities/CatalogItem.cs`
- `Entities/CatalogType.cs`
- `Interfaces/IAggregateRoot.cs`
- `Interfaces/IAsyncRepository.cs`
- `Interfaces/IUriComposer.cs`
- `Services/UriComposer.cs`
- `Specifications/CatalogFilterPaginatedSpecification.cs`
- `Specifications/CatalogFilterSpecification.cs`

### Interfaces
- `ICatalogItemViewModelService.cs`
- `ICatalogViewModelService.cs`

### Services
- `CachedCatalogVIewModelService.cs`
- `CatalogItemViewModelService.cs`
- `CatalogViewModelService.cs`

### ViewModels
- `CatalogIndexViewModel.cs`
- `CatalogItemViewModel.cs`
- `PaginationInfoViewModel.cs`

### Infrastructure
- `Data/CatalogContext.cs`
- `Data/CatalogContextSeed.cs`
- `Data/EfRepository.cs`

### Extensions
- `CacheHelpers.cs`

## Step 2
Basket, Checkout, Success

```
Install-Package Ardalis.GuardClauses -Version 3.1.0
```

### Pages
- `Basket/BasketItemViewModel.cs`
- `Basket/BasketViewModel.cs`
- `Basket/Index.cshtml`
- `Basket/Index.cshtml.cs`
- `Basket/Checkout.cshtml`
- `Basket/Checkout.cshtml.cs`
- `Basket/Success.cshtml`
- `Basket/Success.cshtml.cs`
- `Shared/_LoginPartial.cshtml`
- `Shared/Components/Basket/Default.cshtml`
- `Shared/Components/Basket.cs`

### Interfaces
- `IBasketViewModelService.cs`

### ApplicationCore
- `Interfaces/IBasketService.cs`
- `Interfaces/IAppLogger.cs`
- `Entities/BasketAggregate/Basket.cs`
- `Services/BasketService.cs`
- `Specificaitons/BasketWithItemsSpecification.cs`
- `Specifications/CatalogItemsSpecificaiton.cs`
- `Exceptions/GuardExtensions.cs`
- `Exceptions/BasketNotFoundException.cs`
- `Exceptions/EmptyBasketOnCheckoutException.cs`

### Infrastructure
- `Logging/LoggerAdapter.cs`

### Services
- `BasketViewModelService.cs`

### ViewModels
- `BasketComponentViewmodel.cs`

## Step 3
Login, Identity

```
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -Version 5.0.3
Install-Package Microsoft.AspNetCore.Identity.UI -Version 5.0.3
```

### ApplicationCore
- `Constants/AuthorizationConstants.cs`

### Infrastructure
- `Identity/ApplicationUser.cs`
- `Identity/AppIdentityDbContext.cs`
- `Identity/AppIdentityDbContextSeed.cs`

### Areas
- `Identity/Pages/Account/Login.cshtml`
- `Identity/Pages/Account/Login.cshtml.cs`
- `Identity/Pages/_ViewImports.cshtml`
- `Identity/Pages/_ViewStart.cshtml`

### BlazorShared
- `Authorization/Constants.cs`
