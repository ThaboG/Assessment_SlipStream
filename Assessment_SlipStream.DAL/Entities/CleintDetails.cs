using Assessment_SlipStream.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assessment_SlipStream.DAL.Entities
{
    public class Clients
    {
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Name")]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Surname")]
        public string Lastname { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Gender Alias(if Other)")]
        public string GenderName { get; set; }
        [Required]
        [MaxLength(13)]
        [Display(Name = "ID No.")]
        public string IDNumber { get; set; }
        [Required]
        [MaxLength(250)]
        [Display(Name = "Residential Address")]
        public string ResidentailAddress { get; set; }
        [Display(Name = "Work Address")]
        public string WorkAddress { get; set; }
        [Display(Name = "Postal Address")]
        public string PostalAddres { get; set; }
        [Required]
        [MaxLength(13)]
        [Display(Name = "Mobile No.")]
        public string CellNumber { get; set; }
        [Display(Name = "Work No.")]
        public string WorkNumber { get; set; }

    }
}
