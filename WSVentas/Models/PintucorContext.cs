using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WSVentas.Models
{
    public partial class PintucorContext : DbContext
    {
        public PintucorContext()
        {
        }

        public PintucorContext(DbContextOptions<PintucorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barrio> Barrio { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Envio> Envio { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Estante> Estante { get; set; }
        public virtual DbSet<FormaPago> FormaPago { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Seccion> Seccion { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<TipoPintura> TipoPintura { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NG9QUH4\\SQLEXPRESS;Database=Pintucor;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barrio>(entity =>
            {
                entity.HasKey(e => e.IdBarrio)
                    .HasName("pk_id_b");

                entity.ToTable("barrio");

                entity.Property(e => e.IdBarrio).HasColumnName("id_barrio");

                entity.Property(e => e.IdLocalidad).HasColumnName("id_localidad");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Barrio)
                    .HasForeignKey(d => d.IdLocalidad)
                    .HasConstraintName("fk_id_l");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("pk_id_cliente");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdBarrio).HasColumnName("id_barrio");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.IdBarrioNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdBarrio)
                    .HasConstraintName("fk_id_b");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.IdColor)
                    .HasName("pk_color");

                entity.ToTable("color");

                entity.Property(e => e.IdColor).HasColumnName("id_color");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(e => e.NroFac)
                    .HasName("pk_nroF");

                entity.ToTable("detalle_venta");

                entity.Property(e => e.NroFac)
                    .HasColumnName("nroFac")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CodigoProducto).HasColumnName("codigo_producto");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Descuento).HasColumnName("descuento");

                entity.Property(e => e.ImporteBruto).HasColumnName("importe_bruto");

                entity.Property(e => e.Impuesto).HasColumnName("impuesto");

                entity.Property(e => e.PrecioUnitario).HasColumnName("precio_unitario");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.CodigoProductoNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.CodigoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cod");

                entity.HasOne(d => d.NroFacNavigation)
                    .WithOne(p => p.DetalleVenta)
                    .HasForeignKey<DetalleVenta>(d => d.NroFac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_nroF");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("pk_id_empleado");

                entity.ToTable("empleado");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cargo)
                    .HasColumnName("cargo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_usuario");
            });

            modelBuilder.Entity<Envio>(entity =>
            {
                entity.HasKey(e => e.IdEnvio)
                    .HasName("pk_id_envio");

                entity.ToTable("envio");

                entity.Property(e => e.IdEnvio).HasColumnName("id_envio");

                entity.Property(e => e.CodigoProducto).HasColumnName("codigo_producto");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.HasOne(d => d.CodigoProductoNavigation)
                    .WithMany(p => p.Envio)
                    .HasForeignKey(d => d.CodigoProducto)
                    .HasConstraintName("fk_codigo_producto");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Envio)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("fk_id_cliente");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Envio)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("fk_id_estado");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("pk_id_estado");

                entity.ToTable("estado");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estante>(entity =>
            {
                entity.HasKey(e => e.IdEstante)
                    .HasName("pk_id_e");

                entity.ToTable("estante");

                entity.Property(e => e.IdEstante).HasColumnName("id_estante");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdSeccion).HasColumnName("id_seccion");

                entity.HasOne(d => d.IdSeccionNavigation)
                    .WithMany(p => p.Estante)
                    .HasForeignKey(d => d.IdSeccion)
                    .HasConstraintName("fk_id_s");
            });

            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.HasKey(e => e.IdFormaPago)
                    .HasName("id_forma_pago");

                entity.ToTable("forma_pago");

                entity.Property(e => e.IdFormaPago).HasColumnName("id_forma_pago");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad)
                    .HasName("pk_id_l");

                entity.ToTable("localidad");

                entity.Property(e => e.IdLocalidad).HasColumnName("id_localidad");

                entity.Property(e => e.IdProvincia).HasColumnName("id_provincia");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Localidad)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("fk_id_p");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("pk_marca");

                entity.ToTable("marca");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("pk_cod_p");

                entity.ToTable("producto");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Acabado)
                    .HasColumnName("acabado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.IdColor).HasColumnName("id_color");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.IdSector).HasColumnName("id_sector");

                entity.Property(e => e.IdTipoPintura).HasColumnName("id_tipo_pintura");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Tamaño).HasColumnName("tamaño");

                entity.Property(e => e.TipoProducto)
                    .HasColumnName("tipo_producto")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdColorNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdColor)
                    .HasConstraintName("fk_color");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("fk_marca");

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("fk_s");

                entity.HasOne(d => d.IdTipoPinturaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdTipoPintura)
                    .HasConstraintName("fk_id_t");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("pk_id");

                entity.ToTable("provincia");

                entity.Property(e => e.IdProvincia).HasColumnName("id_provincia");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("pk_rol");

                entity.ToTable("rol");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seccion>(entity =>
            {
                entity.HasKey(e => e.IdSeccion)
                    .HasName("pk_id_s");

                entity.ToTable("seccion");

                entity.Property(e => e.IdSeccion).HasColumnName("id_seccion");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.HasKey(e => e.IdSector)
                    .HasName("pk_id_sector");

                entity.ToTable("sector");

                entity.Property(e => e.IdSector).HasColumnName("id_sector");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdEstante).HasColumnName("id_estante");

                entity.HasOne(d => d.IdEstanteNavigation)
                    .WithMany(p => p.Sector)
                    .HasForeignKey(d => d.IdEstante)
                    .HasConstraintName("fk_id_e");
            });

            modelBuilder.Entity<TipoPintura>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("pk_id_tipo");

                entity.ToTable("tipo_pintura");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.TipoPintura1)
                    .HasColumnName("tipoPintura")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("pk_usuario");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("fk_rol");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.NroFac)
                    .HasName("pk_nroFac");

                entity.ToTable("venta");

                entity.Property(e => e.NroFac).HasColumnName("nroFac");

                entity.Property(e => e.FechaVenta)
                    .HasColumnName("fecha_venta")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.IdEnvio).HasColumnName("id_envio");

                entity.Property(e => e.IdFormaPago).HasColumnName("id_forma_pago");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("fk_id_c");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("fk_id_empleado");

                entity.HasOne(d => d.IdEnvioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdEnvio)
                    .HasConstraintName("fk_id_env");

                entity.HasOne(d => d.IdFormaPagoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdFormaPago)
                    .HasConstraintName("fk_id_forma_pago");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
