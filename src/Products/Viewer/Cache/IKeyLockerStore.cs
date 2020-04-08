namespace GroupDocs.Total.WebForms.Products.Viewer.Cache
{
    interface IKeyLockerStore
    {
        object GetLockerFor(string key);
    }
}
