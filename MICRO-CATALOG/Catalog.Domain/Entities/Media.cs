
using Spk.Catalog.Domain.Enums;

namespace Spk.Catalog.Domain.Entities {
    public class Media {
        public long MediaId { get; set; }
        public string FileName { get; set; }
        public string Source { get; set; }
        public string Caption { get; set; }
        public int? FileSize { get; set; }
        public MediaType MediaType { get; set; }
    }
}