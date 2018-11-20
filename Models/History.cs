using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace GithubUserSearch.Models
{
    public class History
    {
        [Display(Name ="Git Id")]
        public int userId { get; set; }
        [Display(Name ="Git Username")]
        public string userName { get; set; }
        [Display(Name ="Login")]
        public string userLogin { get; set; }
        [Display(Name ="Location")]
        public string userLocation { get; set; }
        [Display(Name ="Followers")]
        public int userFollowers { get; set; }
        [Display(Name ="HtmlUrl")]
        public string userHtmlUrl { get; set; }
        [Display(Name ="Blog")]
        public string userBlog { get; set; }
        [Display(Name ="Company")]
        public string userCompany { get; set; }
        [Display(Name ="AvartarUrl")]
        public string userAvatar { get; set; }
        public DateTime searchDate { get; set; }

        
    }
}