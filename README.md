# OnionCrafter.Specification

[![NuGet](https://img.shields.io/nuget/v/OnionCrafter.Specification.svg)](https://www.nuget.org/packages/OnionCrafter.Specification/)

![](https://github.com/Dtopiast/OnionCrafter.Base/blob/main/Images/Logo.png)

OnionCrafter.Specification es una librería de .NET 7 que proporciona una base sólida para la implementación del patrón de especificación de repositorio dentro de una arquitectura onion.

## Características

- Completamente compatible con el patrón de especificación de repositorio.
- Integración perfecta con OnionCrafter.Base, permitiendo una implementación eficiente de una arquitectura onion.
- Soporte para múltiples proveedores de base de datos.
- Fácil de usar y extender.

## Requisitos previos

Para utilizar OnionCrafter.Specification, es necesario tener instalada la versión 7 de .NET y OnionCrafter.Common.

## Instalación

Para instalar OnionCrafter.Specification, se puede utilizar el administrador de paquetes NuGet desde la consola de Visual Studio o mediante la línea de comandos de .NET:

```
PM> Install-Package OnionCrafter.Specification
```

## Uso

Para utilizar OnionCrafter.Specification, se debe heredar la interfaz `ISpecification` e implementar el método `Expression<Func<TEntity, bool>> IsSatisfiedBy()`.

```csharp
public class ProductByNameSpecification : ISpecification<Product>
{
    private readonly string _name;

    public ProductByNameSpecification(string name)
    {
        _name = name;
    }

    public Expression<Func<Product, bool>> IsSatisfiedBy()
    {
        return product => product.Name == _name;
    }
}
```

Después, se pueden utilizar las especificaciones creadas para consultar la base de datos mediante un repositorio que implemente la interfaz `IRepository`.

```csharp
public class ProductRepository : IRepository<Product>
{
    private readonly IDbContext _dbContext;

    public ProductRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Product> Get(ISpecification<Product> specification)
    {
        return _dbContext.Products.Where(specification.IsSatisfiedBy());
    }
}
```

## Contribuir

Si quieres contribuir a OnionCrafter.Specification, por favor, lee nuestras [pautas de contribución](CONTRIBUTING.md) antes de hacerlo.

## Licencia

OnionCrafter.Specification está bajo la licencia [Apache 2.0](LICENSE).
