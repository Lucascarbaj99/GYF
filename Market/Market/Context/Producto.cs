using System;
using System.Collections.Generic;
using Test.Helpers.Enums;

namespace Market.Context;

public partial class Producto
{
    public int Id { get; set; }

    public int Tipo { get; set; }

    public int Precio { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
