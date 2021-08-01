namespace AnimalMaintenance.Pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    using Managers;
    using Managers.DataTransferObjects;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        public IndexModel(IAnimalMaintenanceManager animalMaintenanceManager)
        {
            AnimalMaintenanceManager = animalMaintenanceManager;
        }

        private IAnimalMaintenanceManager AnimalMaintenanceManager { get; }

        [BindProperty]
        public List<Animal> AllAnimals { get; set; }

        public void OnGet()
        {
            AllAnimals = AnimalMaintenanceManager
                .GetAnimals();
        }

        public IActionResult OnPostUpdate(int id)
        {
            return RedirectToPage("./AddEditAnimal", new { Id = id });
        }

        public IActionResult OnPostDelete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException("Cannot delete entity without an animal id.");
            }

            AnimalMaintenanceManager
                .DeleteAnimal(id);

            return RedirectToPage();
        }
    }
}
