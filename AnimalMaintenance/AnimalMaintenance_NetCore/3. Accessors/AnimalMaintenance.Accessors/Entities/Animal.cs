namespace AnimalMaintenance.Accessors.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;

    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(30)]
        public string AnimalType { get; set; }

        [NotNull]
        [MaxLength(50)]
        public string Breed { get; set; }

        [NotNull]
        [MaxLength(50)]
        public string Color { get; set; }

        [NotNull]
        public DateTime DateOfBirth { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string Name { get; set; }

        [AllowNull]
        public string IncomeType { get; set; }

        [AllowNull]
        public string SexUponIncome { get; set; }
        
        [AllowNull]
        public string OutcomeType { get; set; }

        [AllowNull]
        public string SexUponOutcome { get; set; }
    }
}