namespace EjemploEntity.DTOs
{
    public class CajaDto
    {
        public int CajaId { get; set; }

        public string? CajaDescripcion { get; set; }

        public int EstadoId { get; set; }
        public string EstadoDescrip { get; set; }

        public DateTime? FechaHoraReg { get; set; }
    }
}