using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice_Schad.Core.Models;

namespace Test_Invoice_Schad.Infrastructure.DTOs
{
    public class InvoicesDetailsDTO
    {
        public int InvoicesId { get; set; } 

        public int Qty { get; set; }

        public decimal Price { get; set; }

        public decimal TotalItbis { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }        
    }
}
