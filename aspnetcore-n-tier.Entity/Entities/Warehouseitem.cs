using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore_n_tier.Entity.Entities
{
    public class Warehouseitem
    {
        public int ID { get; set; }
        [Required]
        public string name { get; set; }
        public string SKUCode { get; set; }
        [Range(1, int.MinValue)]
        public int Qty { get; set; }
        [Required]
        public decimal CostPrice { get; set; }
        public decimal MSRPPrice { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse warehouse { get; set; }
    }
}
