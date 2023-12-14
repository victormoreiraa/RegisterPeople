using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HttpClient _httpClient;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7033/api/"); 
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Person");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(jsonString);
                return View(persons);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person personViewModel)
        {
            if (ModelState.IsValid)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(personViewModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var response = await _httpClient.PostAsync("person", content)) 
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index"); 
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Erro ao cadastrar pessoa. Por favor, tente novamente mais tarde.");
                        return View(personViewModel);
                    }
                }
            }

            return View(personViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"Person/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var person = Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(jsonString);
                return View(person);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Person personViewModel)
        {
            if (ModelState.IsValid)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(personViewModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var response = await _httpClient.PutAsync($"Person/{id}", content)) 
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index"); 
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Erro ao atualizar pessoa. Por favor, tente novamente mais tarde.");
                        return View(personViewModel);
                    }
                }
            }

            return View(personViewModel);
        }
        

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var response = await _httpClient.GetAsync($"Person/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var person = JsonConvert.DeserializeObject<Person>(jsonString);
                return View(person);
            }
            else
            {
                return View("Error");
            }
        }


        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Person/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}

