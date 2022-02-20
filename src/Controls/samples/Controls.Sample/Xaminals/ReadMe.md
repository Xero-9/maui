# Xaminals .Net Maui Sample

This is an updated version of the Xamarin.Forms `Shell` sample `Xaminals`. It was updated to work with .Net Maui and highlight using a custom `RouteFactory` to take advantage of dependency injection. The project uses two constants `ENABLE_DI_CHANGES` and `USE_PARTIAL_DI`, they can be enabled by uncommenting out the `<DefineConstants>` elements that are commented out in the `Directory.Build.props` file in the base directory. 

Using `ENABLE_DI_CHANGES` enables changing the default route factory to use a custom route factory that uses constructor inject for all the views created even the ones defined as a `DataTemplate` on a shell page.

Using `USE_PARTIAL_DI` enables using the custom route factory but without changing the default route factory, this makes any view defined on a shell page as a `DataTemplate` will not be created from the dependency container so constructor injection is unavailable.

If no constant is used then the sample will not use a custom route factory.