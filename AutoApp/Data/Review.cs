//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoApp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdAuto { get; set; }
        public string DescriptionReview { get; set; }
    
        public virtual Auto Auto { get; set; }
        public virtual User User { get; set; }
    }
}
