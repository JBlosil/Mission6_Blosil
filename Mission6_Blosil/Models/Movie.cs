using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Blosil.Models
{
    public class Movie
    {
        [Key] public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Range(1889, Int32.MaxValue, ErrorMessage = "Year must be greater than 1888.")]
        [Required(ErrorMessage = "Year is required.")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Edited is Required.")]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }

        [Required(ErrorMessage = "CopiedToPlex is required.")]
        public bool CopiedToPlex { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot be longer than 25 characters.")]
        public string? Notes { get; set; }

    }
}
