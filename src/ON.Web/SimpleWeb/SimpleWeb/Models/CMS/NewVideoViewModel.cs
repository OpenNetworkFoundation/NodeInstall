﻿using ON.Authentication;
using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.CMS
{
    public class NewVideoViewModel
    {
        public NewVideoViewModel() { }

        public NewVideoViewModel(ONUser user)
        {
            Author = user.DisplayName;
        }

        [Required]
        [Display(Name = "Title")]
        [StringLength(100, ErrorMessage = "{0} length must be less than {1}.")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Subtitle")]
        [StringLength(100, ErrorMessage = "{0} length must be less than {1}.")]
        public string Subtitle { get; set; }

        [Display(Name = "Minimum subscription to view")]
        [DataType(DataType.Currency)]
        public uint Level { get; set; }

        [Display(Name = "Single purchase amount in cents")]
        public uint OneTimeAmountCents { get; set; }

        [Required]
        [Display(Name = "Author")]
        [StringLength(100, ErrorMessage = "{0} length must be less than {1}.")]
        public string Author { get; set; }

        [Display(Name = "Rumble Video Id")]
        [StringLength(100, ErrorMessage = "{0} length must be less than {1}.")]
        public string RumbleVideoId { get; set; }

        [Display(Name = "Youtube Video Id")]
        [StringLength(100, ErrorMessage = "{0} length must be less than {1}.")]
        public string YoutubeVideoId { get; set; }

        [Display(Name = "Body")]
        public string Body { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
