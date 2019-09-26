namespace AllMusic_DLL.BO
{
    public class DiscoBO
    {
        public int idDisco { get; set; }
        public string Nombre { get; set; }
        public string Año { get; set; }
        public int TotalPistas { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }
        public int idGenero { get; set; }
        public int idDisquera { get; set; }
        public int idArtista { get; set; }
    }
}
