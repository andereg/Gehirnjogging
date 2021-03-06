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
    
    public partial class Charakter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Charakter()
        {
            this.Inventars = new HashSet<Inventar>();
            this.Savegames = new HashSet<Savegame>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> HP { get; set; }
        public Nullable<int> Damage { get; set; }
        public Nullable<int> Luck { get; set; }
        public Nullable<int> Stage { get; set; }
        public Nullable<int> SolveTime { get; set; }
        public Nullable<int> Assets { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventar> Inventars { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Savegame> Savegames { get; set; }
    }
}
