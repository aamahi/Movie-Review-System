using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace movietest1.Models
{
    public class Movie
    {
        [Key]
        public string key { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required,Display(Name = "Release Date"), DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Casts { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Industry { get; set; }

        [Required]
        public string NamePosition { get; set; }

        public string DownloadLink { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }
        [Required]
        public string image { get; set; }

    }
}