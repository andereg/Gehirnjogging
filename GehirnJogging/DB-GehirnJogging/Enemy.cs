//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB_GehirnJogging
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enemy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Enemy()
        {
            this.Levelinfos = new HashSet<Levelinfo>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Damage { get; set; }
        public string HP { get; set; }
        public string XP { get; set; }
        public string Coins { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Levelinfo> Levelinfos { get; set; }
    }
}
