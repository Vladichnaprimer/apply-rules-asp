//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplyNureRulesApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Content
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgURL { get; set; }
        public int AdminId { get; set; }
        public int CategoryId { get; set; }
    
        public virtual User User { get; set; }
        public virtual UserCategory UserCategory { get; set; }
    }
}
