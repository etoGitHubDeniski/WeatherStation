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
    
    public partial class Verification
    {
        public int Id { get; set; }
        public long Date { get; set; }
        public int IdDevice { get; set; }
        public long NextDate { get; set; }
        public int IdSuitability { get; set; }
        public decimal Cost { get; set; }
    
        public virtual Device Device { get; set; }
        public virtual Suitability Suitability { get; set; }
    }
}
