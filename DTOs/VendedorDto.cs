namespace EjemploEntity.DTOs
{
    public class VendedorDto
    {
        public int VendedorId { get; set; }

        public string? VendedorDescripcion { get; set; }

        public int EstadoId { get; set; }
        public string EstadoDescrip { get; set; }

        public DateTime? FechaHoraReg { get; set; }

    }
}
