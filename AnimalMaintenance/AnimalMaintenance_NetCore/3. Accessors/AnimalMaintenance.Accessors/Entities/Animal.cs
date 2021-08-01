namespace AnimalMaintenance.Accessors.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AnimalType { get; set; }

        public string Breed { get; set; }

        public string Color { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Name { get; set; }

        public string IncomeType { get; set; }

        public string SexUponIncome { get; set; }
        
        public string OutcomeType { get; set; }

        public string SexUponOutcome { get; set; }
    }
}