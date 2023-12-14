using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Person
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }

        [JsonProperty("email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
        public string Email { get; set; }

        [JsonProperty("cpf")]
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Por favor, insira um CPF válido no formato xxx.xxx.xxx-xx.")]
        public string CPF { get; set; }

        [JsonProperty("photoPath")]
        [Display(Name = "Caminho da Foto")]
        public string PhotoPath { get; set; } 

    }
}
