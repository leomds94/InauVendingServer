using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InauVendingServer.Models
{
    public partial class Product {

        public Product()
        {
            this.ProductMachines = new List<ProductMachine>();
        }

        [Key]
        public int ProductId { get; set; }

        [DisplayName("Nome")]
        public string ProductName { get; set; }

        [DisplayName("Tipo")]
        public string ProductType { get; set; }

        [DisplayName("URL de imagem")]
        public string ProductImage { get; set; }

        [DisplayName("Produtos")]
        public List<ProductMachine> ProductMachines { get; set; }
    }
}
