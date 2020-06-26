namespace ProyectoFinal.Model
{
    public class Usuario
    {
        public int UsuarioId { get; set; }   
        public string UserName { get; set; }
        public bool Enabled { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
    }
}