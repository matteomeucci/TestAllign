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
    
    public partial class TestCompositions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestCompositions()
        {
            this.TestCompositionPropertiesValues = new HashSet<TestCompositionPropertiesValues>();
        }
    
        public int ID { get; set; }
        public int Test { get; set; }
        public int Index { get; set; }
        public int TestPhase { get; set; }
        public bool SelectedDefault { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestCompositionPropertiesValues> TestCompositionPropertiesValues { get; set; }
        public virtual TestPhases TestPhases { get; set; }
        public virtual Tests Tests { get; set; }
    }
}
