//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alarms
    {
        public int ID { get; set; }
        public int MainConfiguration { get; set; }
        public string Set { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
    
        public virtual MainConfigurations MainConfigurations { get; set; }
    }
}
