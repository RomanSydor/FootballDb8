//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootballDb8.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class stadiums
    {
        public stadiums()
        {
            this.clubs = new HashSet<clubs>();
            this.gameschedule = new HashSet<gameschedule>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public Nullable<int> Capacity { get; set; }
        public string TypeOfLawn { get; set; }
        public Nullable<int> ClubOwner { get; set; }
    
        public virtual ICollection<clubs> clubs { get; set; }
        public virtual clubs clubs1 { get; set; }
        public virtual ICollection<gameschedule> gameschedule { get; set; }
    }
}