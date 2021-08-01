namespace AnimalMaintenance.Pages
{
    using Managers;
    using Managers.DataTransferObjects;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class AddAnimalModel : PageModel
    {
        public AddAnimalModel(IAnimalMaintenanceManager animalMaintenanceManager)
        {
            AnimalMaintenanceManager = animalMaintenanceManager;
        }

        [BindProperty]
        public bool IsEdit { get; set; }

        private IAnimalMaintenanceManager AnimalMaintenanceManager { get; }

        [BindProperty]
        public Animal Animal { get; set; }

        public void OnGet(int id)
        {
            if (id != 0)
            {
                IsEdit = true;
                Animal = AnimalMaintenanceManager
                    .GetAnimal(id);
            }
        }

        public IActionResult OnPost()
        {
            if (IsEdit)
            {
                AnimalMaintenanceManager
                    .UpdateAnimal(Animal);

                return RedirectToPage("/Index");
            }

            AnimalMaintenanceManager
                .AddAnimal(Animal);

            return RedirectToPage("/Index");
        }
    }
}
