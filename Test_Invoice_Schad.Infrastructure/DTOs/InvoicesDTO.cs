using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Invoice_Schad.Infrastructure.DTOs
{
    public class InvoicesDTO
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string Customer { get; set; }

        public decimal TotalItbis { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }
        
        public List<InvoicesDetailsDTO> InvoicesDetails { get; set; }
    }
}
