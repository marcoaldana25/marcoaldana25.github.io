namespace AnimalMaintenance.Managers.DataTransferObjects
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Animal
    {
        public int Id { get; set; }

        [Display(Name="Animal Type")]
        public string AnimalType { get; set; }

        [Display(Name="Breed")]
        public string Breed { get; set; }

        [Display(Name="Color")]
        public string Color { get; set; }

        [Display(Name="Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name="Animal Name")]
        public string Name { get; set; }

        [Display(Name="Income Type")]
        public string IncomeType { get; set; }

        [Display(Name="Sex Upon Income")]
        public string SexUponIncome { get; set; }

        [Display(Name="Outcome Type")]
        public string OutcomeType { get; set; }

        [Display(Name="Sex Upon Outcome")]
        public string SexUponOutcome { get; set; }
    }
}