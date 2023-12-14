using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Por favor, insira um CPF válido no formato xxx.xxx.xxx-xx.")]
        public string CPF { get; set; }

        public string PhotoPath { get; set; }
    }
}
