//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherStation.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Device
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Device()
        {
            this.Verification = new HashSet<Verification>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string InventoryNumber { get; set; }
        public decimal Price { get; set; }
        public int IdStatus { get; set; }
        public int IdState { get; set; }
        public int IdDepartment { get; set; }
    
        public virtual Departament Departament { get; set; }
        public virtual State State { get; set; }
        public virtual Status Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verification> Verification { get; set; }
    }
}
