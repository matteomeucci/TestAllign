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
    
    public partial class AnalogChannelsScaling
    {
        public int ID { get; set; }
        public int MainConfiguration { get; set; }
        public string Set { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public double RawMin { get; set; }
        public double RawMax { get; set; }
        public string RawUnit { get; set; }
        public double EngMin { get; set; }
        public double EngMax { get; set; }
        public string EngUnit { get; set; }
        public int Decimals { get; set; }
        public double Filter { get; set; }
    
        public virtual MainConfigurations MainConfigurations { get; set; }
    }
}