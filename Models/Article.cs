using System;
using System.ComponentModel.DataAnnotations;

namespace Code1stUsersRoles.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Body { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ContributorUsername { get; set; }
    }
}