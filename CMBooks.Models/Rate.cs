//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMBooks.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rate
    {
        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid BookId { get; set; }
        public int Rate1 { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
