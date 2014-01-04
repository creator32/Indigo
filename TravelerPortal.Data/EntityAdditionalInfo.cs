namespace TravelerPortal.Data
{
    public partial class Article : IHasContentPages { }
    public partial class News : IHasContentPages { }
    public partial class Travel : IHasContentPages { }
    public partial class SoulTravelEntities
    {
        static SoulTravelEntities()
        {
            //is needed for EF6
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }
    }
}
