
namespace Spk.Catalog.Domain.Entities {
    public class ProductMedia {
        public long ProductId { get; set; }
        public long MediaId { get; set; }
        public int DisplayOrder { get; set; }

        public Product Product { get; set; }
        public Media Media { get; set; }
    }
}