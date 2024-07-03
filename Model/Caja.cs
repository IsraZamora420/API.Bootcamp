﻿using System;
using System.Collections.Generic;

namespace EjemploEntity2.Model;

public partial class Caja
{
    public double CajaId { get; set; }

    public string? CajaDescripcion { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
