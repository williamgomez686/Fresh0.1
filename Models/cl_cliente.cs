//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fresh0._1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cl_cliente
    {
        public string empcod { get; set; }
        public string clicod { get; set; }
        public string clinom { get; set; }
        public string cliapellido { get; set; }
        public string clidir { get; set; }
        public string cliemail { get; set; }
        public string clitel { get; set; }
        public string clicel1 { get; set; }
        public string clicel2 { get; set; }
        public Nullable<decimal> clidpi { get; set; }
        public Nullable<decimal> clinit { get; set; }
        public Nullable<System.DateTime> clifchalt { get; set; }
        public string cliusualt { get; set; }
        public string id_depcod { get; set; }
        public string id_muncod { get; set; }
        public string cliest { get; set; }
    
        public virtual cl_empresa cl_empresa { get; set; }
        public virtual cl_estado cl_estado { get; set; }
        public virtual cl_geo_departamentos cl_geo_departamentos { get; set; }
        public virtual cl_geo_municipios cl_geo_municipios { get; set; }
    }
}
