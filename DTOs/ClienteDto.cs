namespace EjemploEntity.DTOs
{
    public class ClienteDto
    {
        public class ClienteDTO
        {
            public double ClienteId { get; set; }

            public string? ClienteNombre { get; set; }

            public double? Cedula { get; set; }
            public int? EstadoId { get; set; }
            public string? EstadoDescrip { get; set; }
            public DateTime? FechaHoraReg { get; set; }

        }
    }
}
