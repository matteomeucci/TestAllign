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
    
    public partial class TestCompositionPropertiesValues
    {
        public int ID { get; set; }
        public int TestComposition { get; set; }
        public int TestCompositionProperty { get; set; }
        public bool BoolValue { get; set; }
        public int IntValue { get; set; }
        public double DoubleValue { get; set; }
        public string StringValue { get; set; }
        public byte[] GraphValue { get; set; }
    
        public virtual TestCompositionProperties TestCompositionProperties { get; set; }
        public virtual TestCompositions TestCompositions { get; set; }
    }
}