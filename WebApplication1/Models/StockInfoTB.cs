//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StockInfoTB
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string company { get; set; }
        public Nullable<int> Available_Quantity { get; set; }
        public Nullable<int> Prize { get; set; }
    }
}
