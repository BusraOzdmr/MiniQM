using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Model
{
    public class MaterialInput:BaseEntity
    {
        public int? OrderTypeId { get; set; }
        public virtual OrderType OrderType { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
        public decimal? Cost { get; set; } // Kalem
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public decimal? InputAmount { get; set; } //Giriş miktarı
        public decimal? SampleAmount { get; set;  } // numune miktarı
        public MaterialQuality MaterialQuality { get; set; }
        public decimal? Returned { get; set; } //geri gönderilen
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } //Tedarikçi
        public int StockLocationId { get; set; }
        public virtual StockLocation StockLocation { get; set; }
        public bool Checked { get; set; }
        public QualityControlStatus QualityControlStatus { get; set; }
    }
}
