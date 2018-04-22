using Orchard.ContentManagement.MetaData;
using Orchard.Core.Common.Models;
using Orchard.Data.Migration;
using Orchard.LearnOrchard.FeaturedProduct.Models;
using Orchard.Widgets.Models;

namespace Orchard.LearnOrchard.FeaturedProduct {
    public class Migrations : DataMigrationImpl {

        public int Create()
        {
            ContentDefinitionManager.AlterTypeDefinition(
              "FeaturedProductWidget", cfg => cfg
                .WithSetting("Stereotype", "Widget")
                .WithPart(typeof(FeaturedProductPart).Name)
                .WithPart(typeof(CommonPart).Name)
                .WithPart(typeof(WidgetPart).Name));
            return 1;
        }

        public int UpdateFrom1()
        {
            SchemaBuilder.CreateTable(typeof(FeaturedProductPartRecord).Name,
              table => table
                .ContentPartRecord()
                .Column<bool>("IsOnSale"));
            return 2;
        }
    }
}