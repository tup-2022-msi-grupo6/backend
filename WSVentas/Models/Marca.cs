using System;
using System.Collections.Generic;
namespace WSVentas.Models { public partial class Marca { public Marca() { Producto = new HashSet<Producto>(); } public int IdMarca { get; set; } public string Descripcion { get; set; } public virtual ICollection<Producto> Producto { get; set; } } }